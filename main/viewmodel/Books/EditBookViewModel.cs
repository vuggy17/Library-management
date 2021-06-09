using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using main.controller;
using System.Windows;
using main.layout.Book.Forms;
using main.viewmodel.form;

namespace main.viewmodel.features
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
        private void updateBook(Book book)
        {
            dataLoadFromDB.updateBook(book);
            update();
        }
    }
}
