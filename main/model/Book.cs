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
        #endregion

        #region method
        public Book(int id, string title, string subject, string author, DateTime pubDate) {
            this.id = id;          
            this.author = author;
            this.title = title;
            this.subject = subject;
            this.pubDate = pubDate;
        }

        #endregion
    }
}
