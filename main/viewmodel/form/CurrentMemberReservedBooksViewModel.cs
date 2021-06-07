using main.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.MessageBox;

namespace main.viewmodel.form
{
    class CurrentMemberReservedBooksViewModel: BaseViewModel
    {
       
        public ObservableCollection<BookToShow> ConfirmBooks { get; set; }
        public ICommand Delete { get; set; }
        public ICommand AddToCheckOut { get; set; }
        public BookToShow SelectedItem { get; set; }

        public static event AddReadyReservedBookToCheckOut addToCheckOut;
        public CurrentMemberReservedBooksViewModel(List<BookItem> bookItems)
        {
            ConfirmBooks = new ObservableCollection<BookToShow>();
            ConfirmBooks = ConvertBookItemsToBookToReserve(bookItems);
            foreach(var book in ConfirmBooks)
            {
                switch (book.lendingStatus)
                {
                    case "Available":
                        book.lendingStatus = "Ready";
                        break;
                    case "Reserved":
                        book.lendingStatus = "Ready";
                        break;
                    case "Loaned":
                        book.lendingStatus = "Waiting";
                        break;
                    case "Lost":
                        book.lendingStatus = "Error";
                        break;
                }
            }
            Delete = new RelayCommand<object>((p) => { return true; }, (p) => { removeSeletedItem(); });
            AddToCheckOut = new RelayCommand<object>((p) => { return true; }, (p) => {if(SelectedItem!=null) addReadyReservedBookToCheckOut(SelectedItem); });


        }
        private void addReadyReservedBookToCheckOut(BookToShow selectedItem)
        {
            addToCheckOut(selectedItem);
            ConfirmBooks.Remove(selectedItem);
        }
        private void removeSeletedItem()
        {
            BookToShow temp = SelectedItem;
            MessageBoxResult dialogResult = MessageBox.Show("Ensure that you want to delete this item from member reserved list! It can't be undo", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if(dialogResult == MessageBoxResult.OK)
            {
                ConfirmBooks.Remove(temp);
            }
            else
            {
                return;
            }
            
        }
        private ObservableCollection<BookToShow> ConvertBookItemsToBookToReserve(List<BookItem> bookItems)
        {
             ObservableCollection<BookToShow> result = new ObservableCollection<BookToShow>();
             foreach (var book in bookItems)
             {               
                 result.Add(new BookToShow(book.id.ToString(), book.getBookInfor(), book.dueDate, book.lendingStatus));
             }
             return result;            
        }
    }
}
