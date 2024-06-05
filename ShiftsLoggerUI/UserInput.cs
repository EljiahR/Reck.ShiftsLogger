using ShiftsLoggerAPI.Models;
using Spectre.Console;

namespace ShiftsLoggerUI;

internal class UserInput
{
    public static void AddShift()
    {
        Console.Clear();
        ShiftLog newShift = new();
        newShift.EmployeeName = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter employee name:"));
        Console.Clear();
        Console.WriteLine(newShift.EmployeeName);
        newShift.ShiftStart = AnsiConsole.Prompt(
            new TextPrompt<DateTime>("Enter time shift started(YYYY-MM-DDhh:mm or hh:mm for today):")
            .ValidationErrorMessage("[red]Invalid format[/]")
            .Validate(Validation.Time)
            );
        do
        {
            Console.Clear();
            if (newShift.ShiftEnd < newShift.ShiftStart) Console.WriteLine("Shift end cannot be before start");
            Console.WriteLine($"{newShift.EmployeeName}\n\tStart Time: {newShift.ShiftStart}");
            newShift.ShiftEnd = AnsiConsole.Prompt(
                new TextPrompt<DateTime>("Enter time shift ended(YYYY-MM-DDhh:mm or just hh:mm for today):")
                .ValidationErrorMessage("[red]Invalid format[/]")
                .Validate(Validation.Time)
                );
        } while (newShift.ShiftEnd < newShift.ShiftStart);
        
    }
}
