using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LibraryManagement.controller;
using LibraryManagement.model.enums;

namespace LibraryManagement.model
{
    // for unique book
    public class BookItem
    {
        #region Properties
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        

        private DateTime? _dueDate;

        public DateTime? dueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }

        private DateTime _purchase;

        public DateTime purchase
        {
            get { return _purchase; }
            set { _purchase = value; }
        }

        private DateTime? _bordate;

        public DateTime? bordate
        {
            get { return _bordate; }
            set { _bordate = value; }
        }
        private int _info;

        public int info
        {
            get { return _info; }
            set { _info = value; }
        }
        private double _price;

        public double price
        {
            get { return _price; }
            set { _price = value; }
        }
        private LendingStatus _lendingStatus;

        public LendingStatus lendingStatus
        {
            get { return _lendingStatus; }
            set { _lendingStatus = value; }
        }

       

        public Book BookInfo;

        #endregion
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        //this contructor is use for clone book item from db
        public BookItem(int id, int info, LendingStatus lending)
        {
            this.id = id;
            this.info = info;
            this.lendingStatus = lending;
            this.dataLoadFromDB = DataLoadFromDB.getIntance();
            if (getBookInfor() != null)
            {
                BookInfo = getBookInfor();
            }
           
            
        }
        public BookItem(int id, LendingStatus lending, int info)
        {
            this.id = id;
            this.info = info;
            this.lendingStatus = lending;

        }
        public BookItem (int id, DateTime bordate, DateTime dueDate)
        {
            this.id = id;
            this.bordate = bordate;
            this.dueDate = dueDate;
        }
        DataLoadFromDB dataLoadFromDB;
        public Book getBookInfor()
        {
            foreach (var book in dataLoadFromDB.getBooks())
            {
                if (this.info == book.id)
                {
                    return book;
                }
            }
            return null;
        }
    }
}
