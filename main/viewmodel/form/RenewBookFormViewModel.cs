using LibraryManagement.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.viewmodel.form
{
    class RenewBookFormViewModel:BaseViewModel
    {
        public String Id { get; set; }
        public ObservableCollection<BookToShow> ConfirmBooks { get; }

        public RenewBookFormViewModel(string Id, ObservableCollection<BookToShow> confirmBooks)
        {
            this.Id = "Member ID: " + Id;
            ConfirmBooks = new ObservableCollection<BookToShow>();            
            this.ConfirmBooks = confirmBooks;
            foreach (var book in ConfirmBooks)
            {                
                if (book._dueDate != null)
                {
                    DateTime dateTime = (DateTime)book._dueDate;
                    book._dueDate = dateTime.AddDays(10);
                   
                }
               
            }
        }
    }
}
