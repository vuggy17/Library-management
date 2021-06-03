using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace main.viewmodel.features
{
    class LoginViewModel: BaseViewModel
    {
        public ICommand loginCommand { get; set; }

        public static event LoginHandler login;

        public LoginViewModel()
        {
            loginCommand = new RelayCommand<object>((p) => { return true; }, (p) => { login(); });
        }
    }
}
