using LibraryManagement.layout.HomeAndFeature.form;
using LibraryManagement.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryManagement.viewmodel.features
{
    class ReturnBookViewModel: BaseViewModel
    {
        private ObservableCollection<BookToShow> lendingBookItems;

        public ObservableCollection<BookToShow> LendingBookItems
        {
            get => getLendingBookItems();
        }
        public ICommand Return { get; set; }

        private Account account; 
        public ReturnBookViewModel(Account account)
        {
            lendingBookItems = new ObservableCollection<BookToShow>();
            ReturnBookForm.returnUpdateBook += ReturnBookForm_returnUpdateBook;
            this.account = account;
          

        }
        private ObservableCollection<BookToShow> getLendingBookItems()
        {
            return convertBookItemToShow(account);
        }

        private void ReturnBookForm_returnUpdateBook()
        {
            OnPropertyChanged("LendingBookItems");
            
        }

        private ObservableCollection<BookToShow> convertBookItemToShow(Account account)
        {
            if (account != null)
            {
                ObservableCollection<BookToShow> bookToShows = new ObservableCollection<BookToShow>();                
                foreach (var bookItem in account.getLendingBookItems())
                {
                    bookToShows.Add(new BookToShow(bookItem.id, bookItem.getBookInfor(), (DateTime)bookItem.dueDate, bookItem.lendingStatus));
                }
                return bookToShows;
            }
            return new ObservableCollection<BookToShow>();

        }

    }
}

