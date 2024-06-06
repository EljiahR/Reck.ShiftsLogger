namespace ShiftsLoggerUI;

internal class MenuOptions
{
    public const string AddNewShift = "Add New Shift";
    public const string ViewEditShift = "View/Edit Shifts";
    public const string Exit = "Exit";
    public const string GoBack = "Go back";
    public const string Edit = "Edit";
    public const string Delete = "Delete";

    public static readonly string[] MainMenu = [AddNewShift, ViewEditShift, Exit];
    public static readonly string[] SubMenu = [Edit, Delete, GoBack];
}
