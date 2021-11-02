using LibraryManagement.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibraryManagement.controller;
using System.Windows;
using LibraryManagement.layout.Book.Forms;
using LibraryManagement.viewmodel.form;

namespace LibraryManagement.viewmodel.features
{
    public class EditBookViewModel: BaseViewModel
    {
        public Book bookToShow { get; set; }

        private DataLoadFromDB dataLoadFromDB = DataLoadFromDB.getIntance(); 
        public ICommand saveCommand { get; set; }

        public ICommand editBookItem { get; set; }

        public static event updateBookListHandeler update;


        private int _toTalCopies;
        public int TotalCopies 
        {
            get => _toTalCopies;
            set
            {
                _toTalCopies = value;
                OnPropertyChanged("TotalCopies");
            }
        }

        public EditBookViewModel(Book book)
        {
            bookToShow = new model.Book(book);
            TotalCopies = bookToShow.TotalCopies;
            saveCommand = new RelayCommand<object>((p) => { return true; }, (p) => { updateBook(bookToShow); });
            editBookItem = new RelayCommand<object>((p) => { return true; }, (p) => { EditBookItemFormShow(bookToShow); });
            EditBookItemViewModel.update += EditBookItemViewModel_update;


        }

        private void EditBookItemViewModel_update()
        {
            TotalCopies = bookToShow.TotalCopies;
            update();
        }

        private void EditBookItemFormShow(Book book)
        {
            EditBookItemForm editBookItem = new EditBookItemForm(book);
            editBookItem.Show();
        }
        private bool updateBook(Book book)
        {
            var name = book.title;
            var author = book.author;
            var price = book.price;
            var publishDate = book.pubDate;
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(author) || Double.IsNaN(price) || price > 0)
                return false;
                
            dataLoadFromDB.updateBook(book);
            update();
            return true;
        }
    }
}
