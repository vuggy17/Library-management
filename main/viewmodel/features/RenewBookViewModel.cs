using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using main.layout.HomeAndFeature.form;
using main.model;
using main.viewmodel.features;

namespace main.viewmodel.features
{
    class RenewBookViewModel: BaseViewModel
    {        
        private ObservableCollection<BookToShow> lendingBookItems;



        public ObservableCollection<BookToShow> LendingBookItems
        {
            get => getLendingBookItems();           
        }
        public ICommand Renew { get; set; }
        private Account account;
        public RenewBookViewModel( Account account)
        {
            lendingBookItems = new ObservableCollection<BookToShow>();
            RenewForm.returnUpdateBook += ReturnBookForm_returnUpdateBook;
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
