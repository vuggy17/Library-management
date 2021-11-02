using LibraryManagement.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.viewmodel.form
{

    class ReturnBookFormViewModel : BaseViewModel
    {
        public String Id { get; set; }
        public ObservableCollection<BookToShow> ConfirmBooks { get; set; }

        public double TotalFee { get => caculateTotalOverDuefee(); }

        public ReturnBookFormViewModel(string Id, ObservableCollection<BookToShow> confirmBooks)
        {
            this.Id = "Member ID: " + Id;
            this.ConfirmBooks = confirmBooks;
        }
        private double caculateTotalOverDuefee()
        {
            double result=0.0;
            foreach (var book in this.ConfirmBooks)
            {
                result += book.OverDueFee;
            }
            return result;
        }
    }
}
