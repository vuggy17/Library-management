using main.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.model
{
    public class Book
    {
        #region properties
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _title;

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _subject;

        public string subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        //number of pages
        private string _author;

        public string author
        {
            get { return _author; }
            set { _author = value; }
        }
        private DateTime _pubdate;

        public DateTime pubDate
        {
            get { return _pubdate; }
            set { _pubdate = value; }
        }
        public string PubDateToShow
        {
            get => _pubdate.ToShortDateString();            
        }
        public int AvalableCopies
        {
            get => getAvailableCopies(id);
        }
        private int _totalCopies;

        public int TotalCopies
        {
            get => getTotalCopies(id);
            set
            {
                _totalCopies = value;
            }
        }
        private double _price;

        public double price
        {
            get { return _price; }
            set { _price = value; }
        }
        #endregion
        public Book( Book book) {
            this.id = book.id;
            this.price = book.price;
            this.author = book.author;
            this.title = book.title;
            this.subject = book.subject;
            this.pubDate = book.pubDate;
        }
        #region method
        public Book(int id, string title, string author, DateTime pubDate, double price) {

            this.price = price;
            this.id = id;           
            this.author = author;
            this.title = title;
            this.subject = subject;
            this.pubDate = pubDate;
        }
        DataLoadFromDB dataLoadFromDB = DataLoadFromDB.getIntance();
        private int getTotalCopies(int id)
        {
            int totalCopies = 0;
            List<BookItem> bookItems = new List<BookItem>();
            bookItems = dataLoadFromDB.getBookItems();
            foreach (var bookItem in bookItems)
            {
                if (bookItem.info == id)
                {
                    totalCopies++;
                }
            }
            return totalCopies;
        }

        private int getAvailableCopies(int id)
        {
            int availableCopies = 0;
                List<BookItem> bookItems = new List<BookItem>();
                bookItems = dataLoadFromDB.getBookItems();
            foreach (var bookItem in bookItems)
            {
                if (bookItem.info == id && bookItem.lendingStatus == enums.LendingStatus.AVAI)
                {
                    availableCopies++;
                }
            }
            return availableCopies;
        }
        public List<BookItem> getAllBookItems()
        {

            List<BookItem> bookItems = new List<BookItem>();            
            foreach (var bookItem in dataLoadFromDB.getBookItems())
            {
                if (bookItem.info == id)
                {
                    bookItems.Add(bookItem);
                }
            }
            return bookItems;
        }

        #endregion
    }
}
