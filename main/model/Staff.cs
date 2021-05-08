using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.model
{
    class Staff:Account
    {
        #region properties
        #region id
        //dung dung vo :v
        //private int _id;

        //public int id
        //{
        //    get { return _id; }
        //    set { _id = value; }
        //}
        //private int _info;

        //public int info
        //{
        //    get { return _info; }
        //    set { _info = value; }
        //} 
        #endregion
        private Account _account;

        public Account account
        {
            get { return _account; }
            set { _account = value; }
        }

        private bool _idAdmin;

        public bool isAdmin
        {
            get { return _idAdmin; }
            set { _idAdmin = value; }
        }
        #endregion

        #region method
        public Staff(bool isAdmin, Account accountInfo)
        {
            this.account = accountInfo;
            this.isAdmin = isAdmin;
        }
        public bool addMember() { return true; }
        public bool deleteMember() { return true; }
        public bool blockMember() { return true; }
        public bool unBlockMember() { return true; }
        public bool addBook() { return true; }
        public bool modifyBook() { return true; }
        public bool deleteBook() { return true; }
        public bool addBookItem(Book item) { return true; }
        public bool deleteBookItem(Book item) { return true; }
        public bool modifyBookItem(Book item) { return true; }


        #endregion
    }
}
