using main.layout.Book.Components;
using main.model;
using System;
using main.controller;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookItem = main.model.BookItem;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace main.viewmodel.features
{
    class CheckOutBookViewModel: BaseViewModel
    {
        
        public class BookToShow //Kieu de binding
        {
            string id;
            string name;
            public string Id { get => id; set { id = value; } }
            public String Name { get => name; set { name = value; } }

            public BookToShow(string id, string name)
            {
                this.Id = id;
                this.Name = name;
            }
        }       
        private List<BookItem> bookItems;
        private List<Book> books;
        
        private ObservableCollection<BookToShow> bookToShows;
        public ObservableCollection<BookToShow> BookToShows
        {
            get => getBookToShow();
            set
            {
                bookToShows = value;            
            }
        }
        public CheckOutBookViewModel()
        {
            bookToShows = new ObservableCollection<BookToShow>();
            bookItems = DataLoadFromDB.getBookItems();
            books = DataLoadFromDB.getBooks();            
           
        }
        private string searchKeyword = "";
        public string SearchKeyword
        {
            get => searchKeyword;
            set
            {
                searchKeyword = value;
                OnPropertyChanged("SearchKeyword");
                OnPropertyChanged("BookToShows");                
            }
        }
        private bool isExitstInCurrentList()
        {
            for(int i = 0; i < bookToShows.Count; i++)
            {
                if (bookToShows[i].Id == "ID: "+ searchKeyword)
                {
                    MessageBox.Show("This book is in list");
                    return true;
                }
            }
           
            return false;
        }

        private ObservableCollection<BookToShow> getBookToShow()
        {
            if (searchBookItemById(searchKeyword)!=null &&! isExitstInCurrentList())
            {
                if (findBookNameByBookItemId(searchBookItemById(searchKeyword)) != null)
                {
                    bookToShows.Add(findBookNameByBookItemId(searchBookItemById(searchKeyword)));                   
                    searchKeyword = "";
                }
                else
                {
                    MessageBox.Show("This book no longer availabel");
                }               
            }
            return bookToShows;
        }
        private BookToShow findBookNameByBookItemId(BookItem bookItem)
        {
            
            for (int i = 0; i < books.Count; i++)
            {
                if(bookItem.info == books[i].id)
                {
                   
                    return new BookToShow("ID: " + bookItem.id.ToString(), books[i].title);
                    
                }
            }
            return null;
        }

        private BookItem searchBookItemById(string searchKeyword)
        {
            for(int i=0; i < bookItems.Count; i++)
            {
                if(searchKeyword.Trim() == bookItems[i].id.ToString())
                {                   
                    return bookItems[i];
                }
            }
            return null;
        }

    }
}
