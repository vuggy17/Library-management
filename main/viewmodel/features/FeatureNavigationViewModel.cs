using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace main.model.features
{
    class FeatureNavigationViewModel: BaseViewModel
    {
        public ICommand ReturnBook { get; set; }
        public ICommand RenewBook { get; set; }
        public ICommand ReserveBook { get; set; }
        public ICommand CheckOutBook { get; set; }


        public static event ChangePageHandler ChangePage;

        public FeatureNavigationViewModel()
        {        
            
            ReturnBook = new RelayCommand<object>((p) => { return true; }, (p) => { ChangePage("ReturnBook"); });
            RenewBook = new RelayCommand<object>((p) => { return true; }, (p) => { ChangePage("RenewBook"); });
            ReserveBook = new RelayCommand<object>((p) => { return true; }, (p) => { ChangePage("ReserveBook"); });
            CheckOutBook = new RelayCommand<object>((p) => { return true; }, (p) => { ChangePage("CheckOutBook"); });            
        }
     
    }
}
