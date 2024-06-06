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
            UserInput.AddShift();
            break;
        case MenuOptions.ViewEditShift:
            await UserInput.EditShift();
            break;
        case MenuOptions.DeleteShift:
            break;
    }
} while (menuOption != MenuOptions.Exit);
