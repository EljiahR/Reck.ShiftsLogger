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

    }
} while (menuOption != MenuOptions.Exit);
