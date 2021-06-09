using main.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.viewmodel.form
{
    class AddBookSuccessViewModel: BaseViewModel
    {
        public String Id { get; set; }

        public int TotalItems { get; set; }
        public ObservableCollection<BookToShow> ListBookItems { get; set; }

        public AddBookSuccessViewModel(Book book)
        {
            this.Id = book.id.ToString();
            this.ListBookItems = getBookItemsToShow(book);
            TotalItems = ListBookItems.Count;
          
        }
        private ObservableCollection<BookToShow> getBookItemsToShow(Book book)
        {
            ObservableCollection<BookToShow> bookToShows = new ObservableCollection<BookToShow>();
            foreach( var bookItem in book.getAllBookItems())
            {
                bookToShows.Add(new BookToShow(bookItem.id.ToString(), book.title));
            }
            return bookToShows;
        }

    }
}
