using main.controller;
using main.model.features;
using main.viewmodel.features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using main.model;

namespace main.layout.Book.Components
{
    /// <summary>
    /// Interaction logic for BookList.xaml
    /// </summary>
    public partial class BookList : UserControl
    {
        public static int deleteIndex;
        public static int editIndex;
        DataLoadFromDB dataLoadFromDB = DataLoadFromDB.getIntance();
        public BookList()
        {
            InitializeComponent();
            this.DataContext = new BookListViewModel(dataLoadFromDB.getBooks());
            AddBookViewModel.addBook += AddBookViewModel_addBook;
          //  DeleteBookViewModel.deleteBook += DeleteBookViewModel_deleteBook;
            //EditBookViewModel.editBook += EditBookViewModel_editBook;
            SearchByIdTitleAuthorViewModel.Searching += SearchByIdTitleAuthorViewModel_search;
        }

        private void SearchByIdTitleAuthorViewModel_search()
        {
            this.DataContext = null;
            this.DataContext = new BookListViewModel(SearchByIdTitleAuthorBar.lstBookOnSearch);
        }

        private void EditBookViewModel_editBook(int index)
        {
            //ListAllBook.editBookAt(editIndex, NewBook.getInstanceWithCertain());
            //NewBook.resetInstance();
            this.DataContext = null;
            this.DataContext = new BookListViewModel(ListAllBook.getInstance());
        }

        private void DeleteBookViewModel_deleteBook(int index)
        {
            ListAllBook.deleteBookAt(deleteIndex); 
            this.DataContext = null;
            this.DataContext = new BookListViewModel(ListAllBook.getInstance());
        }

        private void AddBookViewModel_addBook()
        {
            this.DataContext = null; 
            this.DataContext = new BookListViewModel(ListAllBook.getInstance());
            // add to db BookItem as same as the number of book
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //editIndex = lvBookList.SelectedIndex;
            //EditBook editBook = new EditBook();
            //editBook.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // delete logic
            deleteIndex = lvBookList.SelectedIndex;
            //DeleteBookBoard deleteBook = new DeleteBookBoard();
            //deleteBook.Show();
        }

    }
}
