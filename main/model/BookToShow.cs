using main.model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.model
{
    public class BookToShow: BaseViewModel //Kieu de binding
    {
        string id;
        string name;
        public string Id { get => id; set { id = value; } }
        public String Name { get => name; set { name = value; } }

        public double OverDueFee { get => cacurelateOverDueFee(); }

        public DateTime _dueDate { get; set; }

        public string dueDate
        {
            get { return _dueDate.ToShortDateString(); }  
        }
        private string _lendingStatus;

        public string lendingStatus
        {
            get { return _lendingStatus; }
            set { _lendingStatus = value; }
        }

        private double cacurelateOverDueFee()
        {
            DateTime toDay = new DateTime();
            toDay = DateTime.Today;
            if(toDay > _dueDate)
            {
                return (toDay - _dueDate).TotalDays * 5000.0;
            }
            return 0;
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
                    ContentButton = "";
                }
                else
                {
                    ContentButton = "Add to checkout";
                }
                OnPropertyChanged("ContentButton");
                OnPropertyChanged("AddAble");

            }
        }

        public BookToShow(string id, Book info, DateTime dueDate, LendingStatus lendingStatus)
        {
            this.Id = id;
            this.Name = info.title;
            this._dueDate = dueDate.Date;
            switch (lendingStatus)
            {
                case LendingStatus.AVAI:
                    this.lendingStatus = "Available";
                    AddAble = true;
                    break;
                case LendingStatus.LOANED:
                    this.lendingStatus = "Loaned";
                    AddAble = false;
                    break;
                case LendingStatus.LOST:
                    this.lendingStatus = "Lost";
                    AddAble = false;
                    break;
                case LendingStatus.RESV:
                    AddAble = true;
                    this.lendingStatus = "Reserved";
                    break;
            }         
        }
        public BookToShow(string id, string name)
        {
            this.Id = id;
            this.name = name;
        }
        
    }
}
