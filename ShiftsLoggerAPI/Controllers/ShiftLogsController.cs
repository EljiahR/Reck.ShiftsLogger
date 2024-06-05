using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShiftsLoggerAPI.Models;

namespace ShiftsLoggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftLogsController : ControllerBase
    {
        private readonly ShiftLogContext _context;

        public ShiftLogsController(ShiftLogContext context)
        {
            _context = context;
        }

        // GET: api/ShiftLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShiftLog>>> GetShiftLogs()
        {
            return await _context.ShiftLogs.ToListAsync();
        }

        // GET: api/ShiftLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShiftLog>> GetShiftLog(int id)
        {
            var shiftLog = await _context.ShiftLogs.FindAsync(id);

            if (shiftLog == null)
            {
                return NotFound();
            }

            return shiftLog;
        }

        // PUT: api/ShiftLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShiftLog(int id, ShiftLog shiftLog)
        {
            if (id != shiftLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(shiftLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftLogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShiftLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShiftLog>> PostShiftLog(ShiftLog shiftLog)
        {
            _context.ShiftLogs.Add(shiftLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShiftLog", new { id = shiftLog.Id }, shiftLog);
        }

        // DELETE: api/ShiftLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShiftLog(int id)
        {
            var shiftLog = await _context.ShiftLogs.FindAsync(id);
            if (shiftLog == null)
            {
                return NotFound();
            }

            _context.ShiftLogs.Remove(shiftLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShiftLogExists(int id)
        {
            return _context.ShiftLogs.Any(e => e.Id == id);
        }
    }
}
