using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.controller
{
    class ListAllBook
    {
        private static List<Book> instance;
        private ListAllBook() { }

        public static List<Book> getInstance()
        {
            if (instance == null)
            {
                instance = new List<Book>();
                return instance;
            }
            else return instance;
        }

        public static void addNewBook(Book newBook)
        {
            if (instance == null)
            {
                instance = new List<Book>();
                instance.Add(newBook);
            }    
            else
            {
                instance.Add(newBook);
            }    
        }
        
        public static void deleteBookAt(int index)
        {
            if (instance != null)
            {
                instance.RemoveAt(index);
            }    
        }    

        public static void editBookAt(int index, Book newInfo)
        {

        }
    }
}
