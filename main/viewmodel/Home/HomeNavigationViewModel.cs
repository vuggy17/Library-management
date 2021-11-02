using LibraryManagement.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagement.viewmodel
{
    class HomeNavigationViewModel: BaseViewModel
    {
        public ICommand Books { get; set; }
        public ICommand Members { get; set; }
        public ICommand Home { get; set; }


        public static event ChangePageHandler ChangePage;

        public HomeNavigationViewModel()
        {
            Books = new RelayCommand<object>((p) => { return true; }, (p) => { ChangePage("Books"); });
            Members = new RelayCommand<object>((p) => { return true; }, (p) => { ChangePage("Members"); });
            Home = new RelayCommand<object>((p) => { return true; }, (p) => { ChangePage("Home"); });           
        }
    }
}
