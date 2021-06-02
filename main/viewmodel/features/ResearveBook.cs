using main.controller;
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
        private List<Book> listBookReserve = new List<Book>();
        public List<Book> ListBookReserve
        { 
            get => listBookReserve; 
            set => listBookReserve = value;
        }
        private String searchKey;

        public String SearchKey
        {
            get => searchKey;
            set
            {
                searchKey = value;
                OnPropertyChanged("SearchKey");
                OnPropertyChanged("ListBookReserve");
            }
        }

        public ResearveBookViewModel()
        {
            listBookReserve = DataLoadFromDB.getBooks();            
        }

    }
}
