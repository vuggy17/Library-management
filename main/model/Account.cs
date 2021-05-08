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
        private string _password;

        public string password
        {
            get { return _password; }
            set { _password = value; }
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
            get { return _totalBookLoan; }
            set { _totalBookLoan = value; }
        }
        #endregion

        #region method
        public Account() { }
        public Account(string name, string address, string email, string phone, int accountId, string password, AccountStatus accountStatus, DateTime DOMemberShip, int totalBookLoan)
        {
            this.info = new Person(name, address, email, phone);
            this.id = accountId;
            this.password = password;
            this.status = accountStatus;
            this.DOMemberShip = DOMemberShip;
            this.totalBookLoan = totalBookLoan;
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
