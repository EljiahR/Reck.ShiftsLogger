using ShiftsLoggerUI;
using Spectre.Console;

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
            break;
        case MenuOptions.DeleteShift:
            break;
    }
} while (menuOption != MenuOptions.Exit);
