using main.controller;
using main.model;
using main.model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        private Boolean fullInforView;

        public Boolean FullInfoView {
            get => fullInforView;
            set
            {
                fullInforView = value;
                OnPropertyChanged("FullInfoView");
            }
       
        }

        private Boolean userImageView;

        public Boolean UserImageView
        {
            get => userImageView;
            set
            {
                userImageView = value;
                OnPropertyChanged("UserImageView");
            }

        }


        public UserScanerBoardViewModel()
        {
            allAccounts = new List<Account>();
            allAccounts = DataLoadFromDB.getAllMembers();
            FullInfoView = false;
            UserImageView = false;
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
            FullInfoView = true;
            userImageView = true;
        }
    }
}
