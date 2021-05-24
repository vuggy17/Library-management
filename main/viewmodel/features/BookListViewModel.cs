using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.viewmodel.features
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
            List<Book> filter = new List<Book>();
            filter.Add(new Book(1, "Hoàng tử bé", "novel", "13/5/2021", "Tiếng Việt", 230, 85, "Sách rất hay"));
            filter.Add(new Book(1, "Hoàng tử ổm", "novel", "13/5/2021", "Tiếng Việt", 230, 85, "Sách rất hay"));
            filter.Add(new Book(1, "Hoàng tử mập", "novel", "13/5/2021", "Tiếng Việt", 230, 85, "Sách rất hay"));
            filter.Add(new Book(1, "Hoàng tử thông minh", "novel", "13/5/2021", "Tiếng Việt", 230, 85, "Sách rất hay"));
            LstBookItem = filter;
        }
    }
}
