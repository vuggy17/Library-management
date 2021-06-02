using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.model.features
{
    class ResearveBookViewModel: BaseViewModel
    {
        List<Book> listBookReserve = new List<Book>();
        public List<Book> ListBookReserve { get => listBookReserve; set => listBookReserve = value; }



        public ResearveBookViewModel()
        {
        }
    }
}
