using main.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace main.model
{
    public class BookToReserve: BaseViewModel
    {
        int availableCopies;
        int count;
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
        private string _author;

        public string author
        {
            get { return _author; }
            set { _author = value; }
        }

        private string _pubdate;

        public string pubDate
        {
            get { return _pubdate; }
            set { _pubdate = value; }
        }
        public int AvalableCopies
        {
            get => availableCopies;
        }
        public int Count
        {
            get => count;
            set  
            { 
                count = value;
                OnPropertyChanged("Count");
            }
        }
        public string ContentButton { get; set; }

        private bool addAble;
        public bool AddAble
        {
            get => addAble;
            set
            {
                addAble = value;
                if (value == false)
                {
                    ContentButton = "Added";                   
                }
                else
                {
                    ContentButton = "Add";
                }
                OnPropertyChanged("ContentButton");
                OnPropertyChanged("AddAble");

            }
        }
        private Book info;

        public BookToReserve(Book bookInfo)
        {
            this.info = new Book(bookInfo);
            this.availableCopies= getAvailableCopies(bookInfo);
            if(this.availableCopies == 0)
            {
                this.count = 0;
            }
            else
            {
                this.count = 1;
            }
            this.id = bookInfo.id;
            this.title = bookInfo.title;
            this.author = bookInfo.author;
            this.pubDate = bookInfo.pubDate.ToShortDateString();
            this.AddAble = true;
            this.image = bookInfo.image;

        }
        public BitmapImage image { get; set; }
        public Book toBook()
        {
            return new Book(info);
        }
        DataLoadFromDB dataLoadFromDB = DataLoadFromDB.getIntance();
        private int getAvailableCopies(Book bookInfo)
        {
            int availableCopies = 0;
            if (bookInfo != null)
            {
                List<BookItem> bookItems = new List<BookItem>();
                bookItems = dataLoadFromDB.getBookItems();
                foreach(var bookItem in bookItems)
                {
                    if(bookItem.info == bookInfo.id && (bookItem.lendingStatus == enums.LendingStatus.LOANED || bookItem.lendingStatus == enums.LendingStatus.RENEWED) )
                    {
                        availableCopies++;
                    }
                }
            }
            return availableCopies;
        }
        
    }
}
