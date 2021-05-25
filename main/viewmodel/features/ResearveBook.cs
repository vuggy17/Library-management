using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.viewmodel.features
{
    class ResearveBookViewModel: BaseViewModel
    {
        List<Book> listBookReserve = new List<Book>();
        public List<Book> ListBookReserve { get => listBookReserve; set => listBookReserve = value; }



        public ResearveBookViewModel()
        {
            List<Book> fillter = new List<Book>();
            fillter.Add(new Book(1, "Hoàng tử bé", "novel", "13/5/2021", "Tiếng Việt", 230, "", "Sách rất hay"));
            fillter.Add(new Book(1, "Hoàng tử ổm", "novel", "13/5/2021", "Tiếng Việt", 230, "", "Sách rất hay"));
            fillter.Add(new Book(1, "Hoàng tử mập", "novel", "13/5/2021", "Tiếng Việt", 230, "", "Sách rất hay"));
            fillter.Add(new Book(1, "Hoàng tử thông minh", "novel", "13/5/2021", "Tiếng Việt", 230, "", "Sách rất hay"));
            ListBookReserve = fillter;
        }
    }
}
