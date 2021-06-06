using main.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.viewmodel.form
{
    class RenewBookFormViewModel:BaseViewModel
    {
        public String Id { get; set; }
        public ObservableCollection<BookToShow> ConfirmBooks { get; set; }

        public RenewBookFormViewModel(string Id, ObservableCollection<BookToShow> confirmBooks)
        {
            this.Id = "Member ID: " + Id;
            setNewDueDate(confirmBooks);
            this.ConfirmBooks = confirmBooks;
        }
        private void setNewDueDate(ObservableCollection<BookToShow> confirmBooks)
        {
            foreach(var book in confirmBooks)
            {
                book.dueDate = book.dueDate.AddDays(10);
            }
        }
    }
}
