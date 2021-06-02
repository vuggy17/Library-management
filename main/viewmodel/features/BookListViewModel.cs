using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public BookListViewModel(List<Book> dataset)
        {
            LstBookItem = dataset;
        }
    }
}
