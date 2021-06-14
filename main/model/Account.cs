using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using main.controller;
using main.model.enums;

namespace main.model
{
   public class Account
    {
        #region properties
        const int MAX_LENDING_DAY = 10;
        const int MAX_BOOK_LOAN = 5;
        private int _id;
        Db db = Db.getInstace();
        DataLoadFromDB data = DataLoadFromDB.getIntance();

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
       

        private AccountStatus _status;

        public AccountStatus status
        {
            get { return _status; }
            set 
            { 
                _status = value;
                db.updateAccount(this);
            }
        }
        // as person in database
        private Person _info;

        public Person info
        {
            get { return _info; }
            set { _info = value; }
        }
        // as dateofmembership in database
        private DateTime _DOMemberShip;  

        public DateTime DOMemberShip
        {
            get { return _DOMemberShip; }
            set { _DOMemberShip = value; }
        }
        private int _totalBookLoan;

        public int totalBookLoan
        {
            get { return getLendingBookItems().Count; }
            set 
            {
                _totalBookLoan = value;
                db.updateAccount(this);
            }
        }

        

        public int TotalOverDueBook
        {
            get => getTotalOverDueBook();
        }

        private List<BookItem> lendingBookItems;


        private List<BookItem> reserveBookItems;
        


        #endregion

        #region method
        public Account() { }
        public Account(string name, string address, string email, string phone, AccountStatus accountStatus, DateTime DOMemberShip, int totalBookLoan)
        {
            lendingBookItems = new List<BookItem>();
            reserveBookItems = new List<BookItem>();
            this.info = new Person(name, address, email, phone);
            
           
            this.status = accountStatus;
            this.DOMemberShip = DOMemberShip;           
        }
        public Account buildWithId(int id)
        {
            this.id = id;
            return this;
        }
        public int getTotalOverDueBook()
        {
            int count = 0;
            DateTime dateTime = DateTime.Now.Date;
            foreach(var book in lendingBookItems)
            {
                if(book.dueDate < dateTime)
                {
                    count++;
                }
            }
            return count;
        }
        public List<BookItem> getLendingBookItems()
        {
            loadLendingBookItems();
            return lendingBookItems;
        }
        public bool addNewBookToLendingList(BookItem book)
        {
            if (db.addNewBookToLendingList(this, book, CurrentStaff.getIntance()))
            {
                lendingBookItems.Add(book);
                db.updateAccount(this);
                return true;
            }
            else
            {
                MessageBox.Show("System error, please wait a minute then try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
           

        }
        public bool addNewBookToReservedBookList(BookItem book)
        {
            if (db.addNewBookToReserveList(this, book))
            {
                reserveBookItems.Add(book);
                return true;
            }
            else
            {
                MessageBox.Show("System error, please wait a minute then try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public void removeBookToLendingBookList(BookItem book)
        {
            if( db.RemoveLending(this, book))
            {
                foreach (var bookItem in lendingBookItems)
                {
                    if (bookItem.id == book.id)
                    {
                        lendingBookItems.Remove(bookItem);
                        db.updateAccount(this);
                        return;
                    }
                }                
            }
            else
            {
                MessageBox.Show("System error, please wait a minute then try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private DataLoadFromDB dataLoadFromDB = DataLoadFromDB.getIntance();
        
        public bool removeBookToReserveBookList(BookItem book, string status)
        {            
            if(db.updateReserveList(this,book, status))
            {
                DateTime bordate = (DateTime)book.bordate;
                DateTime dueDate = (DateTime)book.dueDate;
                if ((dueDate - bordate).TotalDays > 10)
                {
                    book.lendingStatus = model.enums.LendingStatus.RENEWED;
                }
                if (book.lendingStatus == model.enums.LendingStatus.RESV)
                {
                    book.lendingStatus = model.enums.LendingStatus.LOANED;
                }
                if (book.lendingStatus == model.enums.LendingStatus.READY)
                {
                    book.lendingStatus = model.enums.LendingStatus.AVAI;
                }

                data.updateBookItem(book);
                reserveBookItems.Remove(book);
               return true;              
                       
            }
            else
            {
                MessageBox.Show("System error, please wait a minute then try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return false;
           
            
        }
        
        public List<BookItem> getReservedBookItem()
        {
            loadReservedBookItem();
            return reserveBookItems;
        }
        public void loadReservedBookItem()
        {
            List<int> idBookLending = db.loadReserveList(this);
            reserveBookItems = new List<BookItem>();
            foreach ( var value in idBookLending)
            {
                BookItem temp = dataLoadFromDB.findBookItemByID(value);
                reserveBookItems.Add(temp);

            }
                       
        }
        
        public void loadLendingBookItems()
        {
            List<BookItem> lendingBooksID = db.loadLendingBookList(this);
            lendingBookItems = new List<BookItem>();
            foreach (var value in lendingBooksID)
            {
                BookItem temp = dataLoadFromDB.findBookItemByID(value.id);
                temp.bordate = value.bordate;
                temp.dueDate = value.dueDate;
                lendingBookItems.Add(temp);    
                
            }    
        }
       
       
        #endregion
    //test region

        public Account(Person p)
        {
            this.info = p;
        }
    }
}
