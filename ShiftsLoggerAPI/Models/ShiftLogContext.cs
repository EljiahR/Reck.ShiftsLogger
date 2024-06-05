using Microsoft.EntityFrameworkCore;

namespace ShiftsLoggerAPI.Models;

public class ShiftLogContext : DbContext
{
    public ShiftLogContext(DbContextOptions<ShiftLogContext> options) 
        : base(options) { }

    public DbSet<ShiftLog> ShiftLogs { get; set; } = null;
}
