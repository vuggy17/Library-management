using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.model.features
{
    class BookListViewModel:BaseViewModel
    {
        List<Book> lstBookItem = new List<Book>();

        public List<Book> LstBookItem
        {
            get => lstBookItem;
            set => lstBookItem = value;
        }

        public BookListViewModel()
        {
            //List<Book> filter = new List<Book>();
            //filter.Add(new Book(1, "Hoàng tử bé","novel", "13/6/2021", "Tiếng Việt", 230, "Tân", "Sách rất hay"));
            //filter.Add(new Book(1, "Hoàng tử ốm","novel", "13/1/2001", "Tiếng Việt", 230, "Khang", "Sách rất hay"));
            //filter.Add(new Book(1, "Hoàng tử mập", "novel", "23/5/2002", "Tiếng Việt", 230, "Duy", "Sách rất hay"));
            //filter.Add(new Book(1, "Hoàng tử thông minh", "novel", "28/5/2016", "Tiếng Việt", 230, "Athur", "Sách rất hay"));
            //for (int i =0; i< filter.Count; i++)
            //{
            //    filter[i].author = "Author(s): " + filter[i].author;
            //    filter[i].publisher = "Publication date:" + filter[i].publisher;
            //}    
            //LstBookItem = filter;
        }
    }
}
