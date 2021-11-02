using LibraryManagement.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.controller
{
    class CurrentStaff
    {
        private static Staff instance;

        private CurrentStaff() { }

        public static Staff getIntance()
        {
            if(instance == null)
            {
                instance = new Staff();
            }
            return instance;
        }
        public static void setCurrentStaff(Staff staff)
        {
            instance = staff;
        }
    }
}
