using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.model
{
    class BookToReserve
    {
        int availableCopies;
        int count;
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

        public int AvalableCopies
        {
            get => availableCopies;
        }
        public int Conunt
        {
            get => count;
            set => count = value;
        }

        public BookToReserve(Book bookInfo)
        {
            this.count = 1;
            getAvailableCopies(bookInfo);

        }
        private int getAvailableCopies(Book bookInfo)
        {
            int availableCopies = 0;
            if (bookInfo != null)
            {
                List<BookItem> bookItems = new List<BookItem>();
                foreach(var bookItem in bookItems)
                {
                    if(bookItem.info == bookInfo.id && bookItem.lendingStatus == enums.LendingStatus.AVAI)
                    {
                        availableCopies++;
                    }
                }
            }
            return availableCopies;
        }
    }
}
