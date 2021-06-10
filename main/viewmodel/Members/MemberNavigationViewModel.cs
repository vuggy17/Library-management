using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace main.viewmodel.Members
{
    class MemberNavigationViewModel:BaseViewModel
    {
        public ICommand ActiveList { get; set; }
        public ICommand BlackList { get; set; }       


        public static event ChangePageHandler ChangePage;

        public MemberNavigationViewModel()
        {
            ActiveList = new RelayCommand<object>((p) => { return true; }, (p) => { ChangePage("ActiveList"); });
            BlackList = new RelayCommand<object>((p) => { return true; }, (p) => { ChangePage("BlackList"); });
            
        }
    }
}
