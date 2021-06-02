using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace main.viewmodel.features
{
    class LibrarianIconNavigationViewModel: BaseViewModel
    {
        public ICommand openLibrarianBar { get; set; }

        public static event LibrarianBarHandler updatebar;

        public LibrarianIconNavigationViewModel()
        {
            openLibrarianBar = new RelayCommand<object>((p) => { return true; }, (p) => { updatebar();});
           
        }
    }
    
}
