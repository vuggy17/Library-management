using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.controller
{
    class NewBook
    {
        private static Book instance;
        public static int num; 
        public static Book getInstance(int id, string title, string subject, string author, DateTime dateTime, int numCopy)
        {
            if (instance == null)
            {
                instance = new Book(id, title, subject,  author, dateTime);
                num = numCopy;
            }
            return instance;
        }

        public static void resetInstance()
        {
            instance = null;
            num = 0;
        }
        private NewBook() { }
    }
}
