using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using main.controller;
using System.Windows;

namespace main.viewmodel.features
{
    public class EditBookViewModel: BaseViewModel
    {
        public Book bookToShow { get; set; }

        private DataLoadFromDB dataLoadFromDB = DataLoadFromDB.getIntance(); 
        public ICommand editBookCommand { get; set; }
        
        public ICommand RemoveBookItems { get; set; }
        public ICommand AddNewBookItem { get; set; }

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
            bookToShow = book;
            TotalCopies = book.TotalCopies;
            editBookCommand = new RelayCommand<object>((p) => { return true; }, (p) => { updateBook(book); });
            AddNewBookItem = new RelayCommand<object>((p) => { return true; }, (p) => { addNewBookItem(book); });
            RemoveBookItems = new RelayCommand<object>((p) => { return true; }, (p) => { removeBookItems(book); });

        }
        private void updateBook(Book book)
        {
           
        }
        private void removeBookItems(Book book)
        {
          

        }

        private void addNewBookItem(Book book)
        {
            
        }
    }
}
