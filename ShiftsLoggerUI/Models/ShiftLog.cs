namespace ShiftsLoggerAPI.Models;

public class ShiftLog
{
    public int Id { get; set; }
    public string? EmployeeName { get; set; }
    public DateTime ShiftStart { get; set; }
    public DateTime ShiftEnd { get; set; }
}
