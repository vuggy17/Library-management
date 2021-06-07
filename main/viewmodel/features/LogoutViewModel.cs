using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace main.viewmodel.features
{
    class LogoutViewModel: BaseViewModel
    {
        public ICommand logoutCommand { get; set; }

        public static event LogoutHandler logout;

        public LogoutViewModel()
        {
            logoutCommand = new RelayCommand<object>((p) => { return true; }, (p) => { logout(); });
        }
    }
}
