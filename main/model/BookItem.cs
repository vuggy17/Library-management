using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using main.model.enums;

namespace main.model
{
    // for unique book
    class BookItem
    {
        #region Properties
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private bool _isRefOnly;

        public bool isRefOnly
        {
            get { return _isRefOnly; }
            set { _isRefOnly = value; }
        }
        private DateTime _dueDate;

        public DateTime dueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }
        private DateTime _pubdate;

        public DateTime pubDate
        {
            get { return _pubdate; }
            set { _pubdate = value; }
        }
        private DateTime _purchase;

        public DateTime purchase
        {
            get { return _purchase; }
            set { _purchase = value; }
        }

        private DateTime _bordate;

        public DateTime bordate
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
        private BookFormat _type;

        public BookFormat type
        {
            get { return _type; }
            set { _type = value; }
        }
        private LendingStatus _lendingStatus;

        public LendingStatus lendingStatus
        {
            get { return _lendingStatus; }
            set { _lendingStatus = value; }
        }

        private Rack _place;

        public Rack place
        {
            get { return _place; }
            set { _place = value; }
        }



        #endregion

        //this contructor is use for clone book item from db
        public BookItem(int id, bool isRefOnly, int info)
        {
            this.id = id;
            this.isRefOnly = isRefOnly;
            this.info = info;           
        }

    }
}
