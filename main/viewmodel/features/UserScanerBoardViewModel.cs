using main.controller;
using main.layout.HomeAndFeature.components;
using main.model;
using main.model.enums;
using main.viewmodel.form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace main.viewmodel.features
{
    class UserScanerBoardViewModel: BaseViewModel
    {
        string searchKeyword = "";

        private List<Account> allAccounts;
      
        private Account targetAccount;
        public Account TargetAccount { get => targetAccount; set => targetAccount = value; }

        public String Name { get; set; }

        public String ID { get; set; }

        public String BorrowBook { get; set; }

        public String OverDue { get; set; }


        private Boolean userView;

        public ICommand SeeFullUserInfo { get; set; }

        public ICommand CancelMember { get; set; }



        public Boolean UserView
        {
            get => userView;
            set
            {
                userView = value;
                OnPropertyChanged("UserView");
            }

        }


        public UserScanerBoardViewModel()
        {
            allAccounts = new List<Account>();
            allAccounts = DataLoadFromDB.getAllMembers();
            UserView = false;
            SeeFullUserInfo = new RelayCommand<object>((p) => { return true; }, (p) => { showFullUserInfor(TargetAccount); });
            CancelMember = new RelayCommand<object>((p) => { return true; }, (p) => { hideUserInfo(); });

        }
        private void hideUserInfo()
        {
            targetAccount = null;
            UserView = false;
        }
        private void showFullUserInfor(Account account)
        {
            ReturnFullInfor returnFullInfor = new ReturnFullInfor(account);
            returnFullInfor.Show();
        }


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
            OverDue = "Over due: " + 5.ToString();
            OnPropertyChanged("OverDue");
            //Lấy image user and set here
            searchKeyword = "";
            UserView = true;
        }
    }
}
