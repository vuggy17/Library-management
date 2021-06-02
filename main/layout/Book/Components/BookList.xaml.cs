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
        private int deleteIndex;
        public BookList()
        {
            InitializeComponent();
            this.DataContext = new BookListViewModel(ListAllBook.getInstance());
            AddBookViewModel.addBook += AddBookViewModel_addBook;
            DeleteBookViewModel.deleteBook += DeleteBookViewModel_deleteBook;
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
            EditBook editBook = new EditBook();
            editBook.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // delete logic
            deleteIndex = lvBookList.SelectedIndex;
            DeleteBookBoard deleteBook = new DeleteBookBoard();
            deleteBook.Show();
        }

    }
}
