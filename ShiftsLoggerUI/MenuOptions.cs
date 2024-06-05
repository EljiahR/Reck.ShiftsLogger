using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsLoggerUI
{
    internal class MenuOptions
    {
        public static readonly string AddNewShift = "Add New Shift";
        public static readonly string ViewEditShift = "View/Edit Shifts";
        public static readonly string DeleteShift = "Delete Existing Shift";
        public static readonly string Exit = "Exit";


        public static readonly string[] MainMenu = [AddNewShift, ViewEditShift, DeleteShift, Exit];
    }
}
