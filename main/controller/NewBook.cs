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
        public static Book getInstance(int id, string title, string subject, string publicsher, string lang, int pageNum, string author, string description)
        {
            if (instance == null)
            {
                instance = new Book(id, title, subject, publicsher, lang, pageNum, author, description);
            }
            return instance;
        }
        private NewBook() { }
    }
}
