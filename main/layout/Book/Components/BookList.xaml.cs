using main.model.features;
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

namespace main.layout.Book.Components
{
    /// <summary>
    /// Interaction logic for BookList.xaml
    /// </summary>
    public partial class BookList : UserControl
    {
        public BookList()
        {
            InitializeComponent();
            this.DataContext = new BookListViewModel();
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditBook editBook = new EditBook();
            editBook.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteBookBoard deleteBook = new DeleteBookBoard();
            deleteBook.Show();
        }

        private void AddBook()
        {
            
        }

    }
}
