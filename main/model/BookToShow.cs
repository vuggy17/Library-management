using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.model
{
    public class BookToShow //Kieu de binding
    {
        string id;
        string name;
        public string Id { get => id; set { id = value; } }
        public String Name { get => name; set { name = value; } }

        public BookToShow(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
