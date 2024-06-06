using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsLoggerUI
{
    internal class UserInput
    {
        public static string GetName()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>("Enter employee name:"));
        }
        public static DateTime GetDate()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<DateTime>("Enter time shift started(YYYY-MM-DDhh:mm or hh:mm for today):")
                .ValidationErrorMessage("[red]Invalid format[/]")
                .Validate(Validation.Time)
                );
        }
    }
}
