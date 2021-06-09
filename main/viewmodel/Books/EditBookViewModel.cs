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
        public Book bookToShow { get; set; }
        public ICommand editBookCommand { get; set; }
        
        public ICommand RemoveBookItems { get; set; }
        public ICommand AddNewBookItem { get; set; }

        public static event EditBookHandler editBook;

        public EditBookViewModel(Book book)
        {
            bookToShow = book;
            editBookCommand = new RelayCommand<object>((p) => { return true; }, (p) => { editBook(book); });
            AddNewBookItem = new RelayCommand<object>((p) => { return true; }, (p) => { addNewBookItem(book); });
            RemoveBookItems = new RelayCommand<object>((p) => { return true; }, (p) => { removeBookItems(book); });

        }

        private void removeBookItems(Book book)
        {
            //remover book item ondb
        }

        private void addNewBookItem(Book book)
        {
            //Add new book item ondb
        }
    }
}
