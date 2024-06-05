using Spectre.Console;

namespace ShiftsLoggerUI
{
    internal class Validation
    {
        public static ValidationResult Time(DateTime time)
        {
            return time > DateTime.Now ?
                ValidationResult.Error("[yellow]Time cannot be in future[/]")
                : ValidationResult.Success();
        }
    }
}
