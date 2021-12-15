using LibraryManagement.controller;
using LibraryManagement.db;
using LibraryManagement.layout.Book;
using LibraryManagement.layout.Book.Components;
using LibraryManagement.layout.HomeAndFeature.form;
using LibraryManagement.model;
using LibraryManagement.viewmodel.features;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryManagement.viewmodel.Books
{
    public class BookPageViewModel : BaseViewModel
    {
        private IDatabase _db;
        public Book SelectedItem { get; set; }

        public String TotalBook
        {
            get
            {
                return allBooks.Count.ToString();
            }
        }

        public ICommand Delete { get; set; }

        public ICommand Edit { get; set; }
        private ObservableCollection<Book> filterList;

        public ObservableCollection<Book> FilterList
        {
            get => filterByInfo();
            set => filterList = value;
        }
        private List<Book> allBooks;

        private String searchKey;
        public String SearchKey
        {
            get => searchKey;
            set
            {
                searchKey = value;
                OnPropertyChanged("SearchKey");
                OnPropertyChanged("FilterList");
            }
        }
        DataLoadFromDB dataLoadFromDB;
        public BookPageViewModel()
        {
            allBooks = new List<Book>();
            //allBooks = dataLoadFromDB.getBooks();
            searchKey = "";
            Delete = new RelayCommand<Object>((p) => true, (p) => { deleteBookFormShow(SelectedItem); });
            Edit = new RelayCommand<Object>((p) => true, (p) => { editBookFormShow(SelectedItem); });
            filterList = new ObservableCollection<Book>();
          
            AddNewBookViewModel.update += update;
            DeleteBookViewModel.deleteBook += deleteBookItem;
            EditBookViewModel.update += update;
            CheckOutConfirm.checkOutUpdateBook += update;
            ReturnBookForm.returnUpdateBook += update;
            this.dataLoadFromDB = DataLoadFromDB.getIntance();
        }

        public BookPageViewModel(IDatabase db)
        {
            this._db = db;
            allBooks = this._db.getAllBooks();
        }

        private void update()
        {
            OnPropertyChanged("FilterList");
            OnPropertyChanged("TotalBook");
        }

        private void editBookItem(Book book)
        {


        }

        private void editBookFormShow(Book book)
        {

            EditBook edit = new EditBook(book);
            edit.Show();
        }

        private void deleteBookFormShow(Book book)
        {
            DeleteBookBoard delete = new DeleteBookBoard(book);
            delete.Show();
        }

        public void deleteBookItem(Book book)
        {
            if (book.TotalCopies == book.AvalableCopies)
            {
                allBooks.Remove(book);
                dataLoadFromDB.deleteBook(book);
                OnPropertyChanged("FilterList");
                OnPropertyChanged("TotalBook");
            }
            else
            {
                MessageBox.Show("Delete book only available when all of it's item had return", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        public void deleteBookItem1(int bookId)
        {
                var books = this._db.getAllBookItems();
                var copies = books.FindAll(item => item.info == bookId).Count;
                var avai = books.FindAll(item => item.info == bookId && item.lendingStatus == model.enums.LendingStatus.AVAI).Count;

                // nếu tất cả sách đã dược trả hết
                if (copies == avai)
                {
                    var removeItem = allBooks.Find(item => item.id == bookId);
                    allBooks.Remove(removeItem); // remove preloaded book list
                    this._db.dropBook(bookId); // call db to drop book
                    OnPropertyChanged("FilterList"); //update UI
                    OnPropertyChanged("TotalBook");
                }
                else
                {
                    throw new Exception("Delete book only available when all of it's item had return");
                }
            
        }

        private ObservableCollection<Book> filterByInfo()
        {
            ObservableCollection<Book> filterList = new ObservableCollection<Book>();
            allBooks = dataLoadFromDB.getBooks();

            foreach (var book in allBooks)
            {

                foreach (PropertyInfo prop in book.GetType().GetProperties())
                {
                    var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                    if (type == typeof(string) || type == typeof(int) || type == typeof(DateTime))
                    {
                        var book_field = prop.GetValue(book, null);
                        if (book_field != null)
                        {
                            String book_data = book_field.ToString().Trim().ToLower();
                            String keyWord = searchKey.ToLower();
                            if (book_data != null && keyWord != null)
                            {
                                if (book_data.Contains(keyWord))
                                {
                                    filterList.Add(book);
                                    break;
                                }
                            }
                        }
                    }

                }
            }
            return filterList;
        }
    }
}
