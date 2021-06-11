using main.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace main.viewmodel.features
{
    class ReturnBookViewModel: BaseViewModel
    {
        private ObservableCollection<BookToShow> lendingBookItems;

        public ObservableCollection<BookToShow> LendingBookItems
        {
            get => lendingBookItems;
        }
        public ICommand Return { get; set; }
        public ReturnBookViewModel(Account account)
        {
            lendingBookItems = new ObservableCollection<BookToShow>();
            if (account != null)
            {
                lendingBookItems = convertBookItemToShow(account);
            }

        }

        private ObservableCollection<BookToShow> convertBookItemToShow(Account account)
        {
            ObservableCollection<BookToShow> bookToShows = new ObservableCollection<BookToShow>();
            foreach (var bookItem in account.getLendingBookItems())
            {
                bookToShows.Add(new BookToShow(bookItem.id, bookItem.getBookInfor(), bookItem.dueDate, bookItem.lendingStatus));
            }
            return bookToShows;
        }

    }
}

