﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using main.model.enums;

namespace main.model
{
   public class Account
    {
        #region properties
        const int MAX_LENDING_DAY = 10;
        const int MAX_BOOK_LOAN = 5;
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
       

        private AccountStatus _status;

        public AccountStatus status
        {
            get { return _status; }
            set { _status = value; }
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
            set { _totalBookLoan = value; }
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
        public Account(string name, string address, string email, string phone, int accountId, AccountStatus accountStatus, DateTime DOMemberShip, int totalBookLoan)
        {
            lendingBookItems = new List<BookItem>();
            reserveBookItems = new List<BookItem>();
            this.info = new Person(name, address, email, phone);
            this.id = accountId;
           
            this.status = accountStatus;
            this.DOMemberShip = DOMemberShip;           
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
            
            return lendingBookItems;
        }
        public void addNewBookToLendingList(BookItem book)
        {
            lendingBookItems.Add(book);
        }
        public void addNewBookToReservedBookList(BookItem book)
        {
            reserveBookItems.Add(book);
        }
        public void removeBookToLendingBookList(BookItem book)
        {
            lendingBookItems.Remove(book);
        }
        public void removeBookToReserveBookList(BookItem book)
        {
            reserveBookItems.Remove(book);
        }
        
        public List<BookItem> getReservedBookItem()
        {          
            return reserveBookItems;
        }
        public void loadReservedBookItem()
        {
            //Load reserved book item in db
                       
        }
        public void loadLendingBookItems()
        {
            //Load lending book item
              
        }
        public bool resetPassword() { return true; }
        public bool changeInfo(Person input)
        {
            this.info.modifyInfo(input);
            Console.WriteLine(this.info.name);
            return true;
        }
        #endregion
    //test region

        public Account(Person p)
        {
            this.info = p;
        }
    }
}
