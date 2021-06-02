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
        private string _publisher;

        public string publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }
        private string _lang;

        public string lang
        {
            get { return _lang; }
            set { _lang = value; }
        }
        //number of pages
        private int _pageNum;

        public int pageNum
        {
            get { return _pageNum; }
            set { _pageNum = value; }
        }
        //author id
        private string _author;

        public string author
        {
            get { return _author; }
            set { _author = value; }
        }
        private string _description;

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion

        #region method
        public Book(int id, string title, string subject, string publisher, string lang, int pageNum, string author, string description) {
            this.id = id;
            this.pageNum = pageNum;
            this.author = author;
            this.title = title;
            this.subject = subject;
            this.publisher = publisher;
            this.lang = lang;
            this.description = description;
        }

        #endregion
    }
}
