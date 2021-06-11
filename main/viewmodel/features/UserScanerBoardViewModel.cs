using main.controller;
using main.layout.HomeAndFeature.components;
using main.layout.HomeAndFeature.form;
using main.model;
using main.model.enums;
using main.model.form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace main.model.features
{
    class UserScanerBoardViewModel: BaseViewModel
    {
        

        private List<Account> allAccounts;
      
        private Account targetAccount;
        public Account TargetAccount { get => targetAccount; set { targetAccount = value; currentMember.setAccount(targetAccount); } }

        private List<BookItem> reserveBookItems;
        
        public bool haveAvailableBookItem
        {
            get => checkAvaiBook();
        }
        private bool checkAvaiBook()
        {
            if (reserveBookItems != null)
            {
                foreach(var book in reserveBookItems)
                {
                    if (book.lendingStatus == LendingStatus.AVAI||book.lendingStatus ==LendingStatus.RESV)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private CurrentMember currentMember;

        public String Name { get; set; }

        public String ID { get; set; }

        public String BorrowBook { get; set; }

        public String OverDue { get; set; }


        private Boolean userView;

        public ICommand SeeFullUserInfo { get; set; }

        public ICommand CancelMember { get; set; }

        public ICommand getReservedBooks { get; set; }

        public static event UpdateLendingBookList updateLedingBookList;





        public Boolean UserView
        {
            get => userView;
            set
            {
                userView = value;
                OnPropertyChanged("UserView");
            }

        }
        DataLoadFromDB dataLoadFromDB = DataLoadFromDB.getIntance();

        public UserScanerBoardViewModel()
        {
            allAccounts = new List<Account>();
            allAccounts = dataLoadFromDB.getAllMembers();
            currentMember = CurrentMember.getInstance();
            UserView = false;
            SeeFullUserInfo = new RelayCommand<object>((p) => { return true; }, (p) => { showFullUserInfor(TargetAccount); });
            CancelMember = new RelayCommand<object>((p) => { return true; }, (p) => { hideUserInfo(); });
            getReservedBooks = new RelayCommand<Object>((p) => true, (p) => { showCurrentMemberReservedBooks(); });
            CheckOutConfirm.ClearInfo += hideUserInfo;
            ReserveConfirm.ClearInfo += hideUserInfo;
            ReturnBookForm.returnUpdateMember += updateUI;
        }

        private void showCurrentMemberReservedBooks()
        {
            CurrentMemberReserverBooks current = new CurrentMemberReserverBooks(TargetAccount.getReservedBookItem());
            current.Show();
        }

        private void hideUserInfo()
        {
            targetAccount = null;
            currentMember.setAccount(null);
            updateLedingBookList(TargetAccount);
            UserView = false;
        }
        private void showFullUserInfor(Account account)
        {
            ReturnFullInfor returnFullInfor = new ReturnFullInfor(account);
            returnFullInfor.Show();
        }

        string searchKeyword = "";
        public string SearchKeyword
        {
            get => searchKeyword;
            set
            {               
                searchKeyword = value;               
                OnPropertyChanged("SearchKeyword");                
                if (searchUserById(searchKeyword)) {
                    updateUI();
                }
            }
        }
        private Boolean searchUserById(string searchKeyId)
        {
            for( int i = 0; i< allAccounts.Count; i++)
            {
                if(searchKeyId.Trim() == allAccounts[i].id.ToString())
                {
                    TargetAccount = allAccounts[i];                    
                    return true;
                }
            }
            return false;
        }

        private void updateUI()
        {
            Name = TargetAccount.info.name;

            OnPropertyChanged("Name");
            ID = "ID: " + TargetAccount.id.ToString();
            OnPropertyChanged("ID");
            BorrowBook = "Borrowed books: " + TargetAccount.totalBookLoan.ToString() + "/5";
            OnPropertyChanged("BorrowBook");
            OverDue = "Over due: " + TargetAccount.TotalOverDueBook.ToString();
            OnPropertyChanged("OverDue");

            //Lấy image user and set here
            searchKeyword = "";
            UserView = true;
            TargetAccount.loadLendingBookItems();
            TargetAccount.loadReservedBookItem();
            updateLedingBookList(TargetAccount);
            reserveBookItems = TargetAccount.getReservedBookItem();
            OnPropertyChanged("haveAvailableBookItem");
        }
    }
}
