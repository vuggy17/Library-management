using main.model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.model
{
    public class BookToShow //Kieu de binding
    {
        string id;
        string name;
        public string Id { get => id; set { id = value; } }
        public String Name { get => name; set { name = value; } }

        public double OverDueFee { get => cacurelateOverDueFee(); }

        private DateTime _dueDate;

        public DateTime dueDate
        {
            get { return _dueDate.Date; }
            set { _dueDate = value; }
        }
        private LendingStatus _lendingStatus;

        public LendingStatus lendingStatus
        {
            get { return _lendingStatus; }
            set { _lendingStatus = value; }
        }

        private double cacurelateOverDueFee()
        {
            DateTime toDay = new DateTime();
            toDay = DateTime.Today;
            if(toDay > dueDate)
            {
                return (toDay - dueDate).TotalDays * 5000.0;
            }
            return 0;
        }

        public BookToShow(string id, Book info, DateTime dueDate, LendingStatus lendingStatus)
        {
            this.Id = id;
            this.Name = info.title;
            this.dueDate = dueDate.Date;
            this.lendingStatus = lendingStatus;             
        }
        public BookToShow(string id, string name)
        {
            this.Id = id;
            this.name = name;
        }
        
    }
}
