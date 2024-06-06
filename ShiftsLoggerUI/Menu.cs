using ShiftsLoggerUI.Models;
using Spectre.Console;

namespace ShiftsLoggerUI;

internal class Menu
{
    public static async Task AddShift()
    {
        Console.Clear();
        ShiftLog newShift = new();
        newShift.EmployeeName = UserInput.GetName();
        Console.Clear();
        Console.WriteLine(newShift.EmployeeName);
        newShift.ShiftStart = UserInput.GetDate();
        do
        {
            Console.Clear();
            if (newShift.ShiftEnd < newShift.ShiftStart) Console.WriteLine("Shift end cannot be before start");
            Console.WriteLine($"{newShift.EmployeeName}\n\tStart Time: {newShift.ShiftStart}");
            newShift.ShiftEnd = UserInput.GetDate();
        } while (newShift.ShiftEnd < newShift.ShiftStart);

        Console.Clear();
        Console.WriteLine($"{newShift.EmployeeName}\n\tStart Time: {newShift.ShiftStart}\n\tEnd Time: {newShift.ShiftEnd}");
        if (AnsiConsole.Confirm("Are you sure you want to post this shift?"))
        {
            try
            {
                await APICalls.PostShiftAsync(newShift);
                Console.WriteLine($"{newShift.EmployeeName}'s shift was successfully posted");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            catch (Exception ex) 
            {
                Console.Error.WriteLine(ex.ToString());
                Console.WriteLine("Shift not posted. Press Enter to return to menu...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
    public static async Task ViewShifts()
    {
        Console.Clear();
        try
        {
            List<ShiftLog> shifts = await APICalls.GetShiftsAsync();
            //foreach (ShiftLog shift in shifts) { Console.WriteLine(shift.EmployeeName); }
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select a shift to edit")
                .PageSize(15)
                .AddChoices<string>(shifts.Select(s => $"{s.Id} {s.EmployeeName} {s.ShiftStart.ToString("yyyy-MM-dd")}"))
                .AddChoices(MenuOptions.GoBack)
                );
            if(option != MenuOptions.GoBack)
            {
                ShiftLog selectedShift = shifts.FirstOrDefault(s => s.Id == int.Parse(option.Split(" ")[0]));
                Console.Clear();
                Console.WriteLine($"{selectedShift.EmployeeName}\n\tStart: {selectedShift.ShiftStart}\n\tEnd: {selectedShift.ShiftEnd}");
                var subMenuOption = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Choose an option")
                    .PageSize(3)
                    .AddChoices(MenuOptions.SubMenu));
                switch(subMenuOption)
                {
                    case MenuOptions.Edit:
                        await EditShift(selectedShift);
                        break;
                    case MenuOptions.Delete:
                        await DeleteShift(selectedShift);
                        break;
                }
            }
        }
        catch (Exception ex) 
        {
            Console.Error.WriteLine(ex.ToString());
            Console.WriteLine("Error retrieving shifts. Press Enter to return to menu...");
            Console.ReadLine();
            Console.Clear();
        }
        
    }

    private static async Task EditShift(ShiftLog shift)
    {
        string? option;
        do
        {
            Console.Clear();
            Console.WriteLine($"{shift.EmployeeName}\n\tStart: {shift.ShiftStart}\n\tEnd: {shift.ShiftEnd}");
            option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select an attribute to edit, submit current changes, or go back")
                .PageSize(MenuOptions.EditMenu.Count())
                .AddChoices(MenuOptions.EditMenu));
            switch(option)
            {
                case MenuOptions.Name:
                    shift.EmployeeName = UserInput.GetName();
                    break;
                case MenuOptions.Start:
                    shift.ShiftStart = UserInput.GetDate();
                    break;
                case MenuOptions.End:
                    do
                    {
                        if (shift.ShiftEnd < shift.ShiftStart) Console.WriteLine("Shift cannot end before it starts");
                        shift.ShiftEnd = UserInput.GetDate();
                    } while (shift.ShiftEnd < shift.ShiftStart);
                    break;
            }
        } while (option != MenuOptions.GoBack && option != MenuOptions.Submit);
        if(option == MenuOptions.Submit)
        {
            try
            {
                await APICalls.PutShiftAsync(shift);
                Console.Clear();
                Console.WriteLine("Shift successfully updated");
            } catch(Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                Console.WriteLine("Error udpated shift");
            }
        }
    }

    private static async Task DeleteShift(ShiftLog shift)
    {
        if(AnsiConsole.Confirm("Are you sure you want to delete this shift?"))
        {
            try
            {
                await APICalls.DeleteShiftAsync(shift);
                Console.WriteLine("Shift successfully delete");
            }
            catch (Exception ex) 
            { 
                Console.Error.WriteLine(ex.ToString());
                Console.WriteLine("Encounter error while deleted shift");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
