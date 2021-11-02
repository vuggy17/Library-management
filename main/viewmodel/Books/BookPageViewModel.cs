using LibraryManagement.controller;
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
    class BookPageViewModel: BaseViewModel
    {
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
        DataLoadFromDB dataLoadFromDB = DataLoadFromDB.getIntance();
        public BookPageViewModel()
        {
            allBooks = new List<Book>();
            allBooks = dataLoadFromDB.getBooks();
            searchKey = "";
            Delete = new RelayCommand<Object>((p) => true, (p) => { deleteBookFormShow(SelectedItem); });
            Edit = new RelayCommand<Object>((p) => true, (p) => { editBookFormShow(SelectedItem); });
            filterList = new ObservableCollection<Book>();
            AddBookForm.update += update;
            DeleteBookViewModel.deleteBook += deleteBookItem;
            EditBookViewModel.update += update;
            CheckOutConfirm.checkOutUpdateBook += update;
            ReturnBookForm.returnUpdateBook += update;


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

        private void deleteBookItem(Book book)
        {
            if (book.TotalCopies == book.AvalableCopies )
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
