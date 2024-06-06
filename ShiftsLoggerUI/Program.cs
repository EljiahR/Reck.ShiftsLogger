using ShiftsLoggerUI;
using Spectre.Console;
using System.Configuration;

string? menuOption;
do
{
    menuOption = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("Main Menu")
        .PageSize(MenuOptions.MainMenu.Count())
        .AddChoices(MenuOptions.MainMenu));

    switch(menuOption)
    {
        case MenuOptions.AddNewShift:
            Menu.AddShift();
            break;
        case MenuOptions.ViewEditShift:
            await Menu.ViewShifts();
            break;
    }
} while (menuOption != MenuOptions.Exit);
