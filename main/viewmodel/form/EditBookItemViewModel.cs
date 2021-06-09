using main.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using main.controller;

namespace main.viewmodel.form
{
    class EditBookItemViewModel: BaseViewModel
    {
        DataLoadFromDB data = DataLoadFromDB.getIntance();


        public String Id { get; set; }
        public BookItem SelectedItem { get; set; }

        public int TotalItems { get; set; }
        private int numOfCopy;
        public int NumOfCopy {
            get
            {
                return numOfCopy;
            }
            set 
            {
                if(value > 50)
                {
                    numOfCopy = 50;
                }
                else
                if (value < 1)
                {
                    numOfCopy = 1;
                }
                else
                {
                    numOfCopy = value;                    
                }
                OnPropertyChanged("NumOfCopy");
            }
        }
        public ObservableCollection<BookItem> ListBookItems { get; set; }
        public static event updateBookListHandeler update;

        public ICommand Delete { get; set; }
        public ICommand AddItems { get; set; }

        public EditBookItemViewModel(Book book)
        {
            this.Id = book.id.ToString();
            this.ListBookItems = getBookItemsToShow(book);
            TotalItems = ListBookItems.Count;
            NumOfCopy = 1;
            Delete = new RelayCommand<object>((p) => { return true; }, (p) => { removeSeletedItem(); });
            AddItems = new RelayCommand<object>((p) => { return true; }, (p) => { addItem(book); });
        }
        private bool checkIfIdExist(Book book, int id)
        {
            foreach(var bookItem in book.getAllBookItems())
            {
                if(id == bookItem.id)
                {
                    return true;
                }
            }
            return false;
        }
        private void addItemToListBook(Book book)
        {
            int id = book.id;
            for (int i = 0; i < NumOfCopy; i++)
            {
                id++;
                if (!checkIfIdExist(book, id))
                {
                    data.addNewBookItem(new BookItem(id, book.id, model.enums.LendingStatus.AVAI, new DateTime()));
                    ListBookItems = getBookItemsToShow(book);
                    TotalItems = ListBookItems.Count;
                    OnPropertyChanged("TotalItems");
                    OnPropertyChanged("ListBookItems");
                    update();
                }
                else
                {
                    i--;
                }
            }
        }
        private void addItem(Book book)
        {
            if(numOfCopy > 9)
            {
                MessageBoxResult dialogResult = MessageBox.Show("Ensure that you want to add " + NumOfCopy.ToString() + " copies of this book!!!", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (dialogResult == MessageBoxResult.OK)
                {
                    addItemToListBook(book);
                }
                else
                {
                    return;
                }
            }
            else
            {
                addItemToListBook(book);
            }
            

        }

        private void removeSeletedItem()
        {
            if(SelectedItem.lendingStatus == model.enums.LendingStatus.AVAI)
            {
                BookItem ItemToDelete = SelectedItem;
                MessageBoxResult dialogResult = MessageBox.Show("Ensure that you want to delete this items! It can't be recover", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (dialogResult == MessageBoxResult.OK)
                {
                    data.deleteBookItems(ItemToDelete);
                    ListBookItems.Remove(ItemToDelete);
                    TotalItems = ListBookItems.Count;
                    OnPropertyChanged("TotalItems");
                    update();
                }
                else
                {
                    return;
                }               
            }
            else
            {
                MessageBox.Show("You can only remove book returned to library", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private ObservableCollection<BookItem> getBookItemsToShow(Book book)
        {
            ObservableCollection<BookItem> bookToShows = new ObservableCollection<BookItem>();
            foreach (var bookItem in book.getAllBookItems())
            {
                bookToShows.Add(bookItem);
            }
            return bookToShows;
        }
        private static readonly Regex _regex = new Regex("[^0-9]+"); //regex that matches disallowed text
        private bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
    }
}
