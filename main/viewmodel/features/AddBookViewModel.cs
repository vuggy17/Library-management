using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace main.viewmodel.features
{
    class AddBookViewModel: BaseViewModel
    {
        public ICommand addBookCommand { get; set; }

        public static event AddBookHandler addBook;

        public AddBookViewModel()
        {
            addBookCommand = new RelayCommand<object>((p) => { return true; }, (p) => { addBook(); });
        }
    }
}
