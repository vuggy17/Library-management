using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace main.viewmodel.Books
{
    class DeleteBookViewModel: BaseViewModel
    {
        public ICommand deleteBookCommand { get; set; }

        public static event DeleteBookHandler deleteBook;

        public DeleteBookViewModel(Book book)
        {
            deleteBookCommand = new RelayCommand<object>((p) => { return true; }, (p) => { deleteBook(book); });
        }
    }
}
