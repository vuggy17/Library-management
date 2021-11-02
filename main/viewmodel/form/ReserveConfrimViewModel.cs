using LibraryManagement.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.viewmodel.form
{
    class ReserveConfrimViewModel: BaseViewModel
    {
        public String Id { get; set; }
        public ObservableCollection<BookToReserve> ConfirmBooks { get; set; }

        public ReserveConfrimViewModel(string Id, ObservableCollection<BookToReserve> confirmBooks)
        {
            this.Id = "Member ID: " + Id;
            this.ConfirmBooks = confirmBooks;
        }
    }
}
