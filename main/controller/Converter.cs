using main.model;
using main.model.enums;
using System;
using System.Windows.Media.Imaging;

namespace main.controller
{
    public class Converter
    {
        #region properties
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _address;

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _email;

        public string email
        {
            get { return _email; }
            set
            {
                //if (validateEmail(value))
                _email = value;
                //else thow err
            }
        }
        private string _phone;

        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        private int _bookNumber;

        public int bookNumber
        {
            get { return _bookNumber; }
            set { _bookNumber = value; }
        }
        private int _overDue;

        public int overDue
        {
            get { return _overDue; }
            set { _overDue = value; }
        }
        private AccountStatus _status;

        public AccountStatus status
        {
            get { return _status; }
            set { _status = value; }
        }
        private BitmapImage _imgSrc;

        public BitmapImage imgSrc
        {
            get { return _imgSrc; }
            set { _imgSrc = value; }
        }
        private int _id;
        public int id
        {
            get => _id;
            set => _id = value;
        }
        public BitmapImage imagePath
        {
            get;
            set;
        }



        #endregion

        public Converter()
        {
        }
        
        public Converter buildWithAccount(Account account)
        {
            this.id = account.id;
            this.name = account.info.name;
            this.address = account.info.address;
            this.email = account.info.email;
            this.phone = account.info.phone;
            this.status = account.status;
            this.bookNumber = account.totalBookLoan;
            this.overDue = account.TotalOverDueBook;
            this.imagePath = account.info.image;
            return this;
        }
        
        

       
    }
}
