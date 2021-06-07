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
using System.Windows.Input;
using main.layout.HomeAndFeature.form;
using main.viewmodel.form;

namespace main.model.features
{
    class CheckOutBookViewModel: BaseViewModel
    {
        
        public BookToShow SelectedItem { get; set; }

        public ICommand Delete { get; set; }
        public ICommand Confirm { get; set; }

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
        CurrentMember currentMember;
        public CheckOutBookViewModel()
        {
            bookToShows = new ObservableCollection<BookToShow>();
            bookItems = DataLoadFromDB.getBookItems();
            books = DataLoadFromDB.getBooks();
            currentMember = CurrentMember.getInstance();
            Delete = new RelayCommand<object>((p) => { return true; }, (p) => { removeSeletedItem(); });
            Confirm = new RelayCommand<object>((p) => { return true; }, (p) => { openCheckOutDiagram(); });
            CheckOutConfirm.ClearInfo += ClearBooksItem;
            CurrentMemberReservedBooksViewModel.addToCheckOut += CurrentMemberReservedBooksViewModel_addToCheckOut;

        }

        private void CurrentMemberReservedBooksViewModel_addToCheckOut(BookToShow bookToShow)
        {
            bookToShows.Add(bookToShow);
        }

        private void ClearBooksItem()
        {
            BookToShows.Clear();
        }

        private void openCheckOutDiagram()
        {
            if (currentMember.GetAccount() == null || bookToShows.Count == 0)
            {
                MessageBox.Show("Member and list book can't not place empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CheckOutConfirm checkOutConfirm = new CheckOutConfirm(currentMember.GetAccount(), BookToShows);
            checkOutConfirm.Show();
        }
        private void removeSeletedItem()
        {           
                     bookToShows.Remove(SelectedItem);
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
                    MessageBox.Show("This book is in list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    searchKeyword = "";
                    return true;
                }
            }
           
            return false;
        }
        private bool checkIsReserveByOrder()
        {
            //Check if this book is exist in this user reserveList
            if (searchBookItemById(SearchKeyword).lendingStatus == enums.LendingStatus.RESV)
            {
                MessageBox.Show("This book is reserved by order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                searchKeyword = "";
                return true;
            }
            return false;
        }
        private bool checkIsReferenceOnly()
        {
            if(searchBookItemById(SearchKeyword).isRefOnly == true)
            {
                MessageBox.Show("This book is reference only","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                searchKeyword = "";
                return true;
            }
            return false;
        }

        private ObservableCollection<BookToShow> getBookToShow()
        {            
            
            if (searchBookItemById(searchKeyword)!=null &&!checkIsReferenceOnly()&&! isExitstInCurrentList()&&!checkIsReserveByOrder())
            {

                if (findBookNameByBookItemId(searchBookItemById(searchKeyword)) != null)
                {
                    bookToShows.Add(findBookNameByBookItemId(searchBookItemById(searchKeyword)));                   
                    searchKeyword = "";
                }
                else
                {
                    MessageBox.Show("This book no longer available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    searchKeyword = "";
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
