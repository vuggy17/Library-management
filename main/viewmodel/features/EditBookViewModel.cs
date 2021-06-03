using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace main.viewmodel.features
{
    public class EditBookViewModel: BaseViewModel
    {
        public ICommand editBookCommand { get; set; }

        public static event EditBookHandler editBook;

        public EditBookViewModel()
        {
            editBookCommand = new RelayCommand<object>((p) => { return true; }, (p) => { editBook(new int()); });
        }
    }
}
