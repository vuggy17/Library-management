using main.layout.Book.Components;
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
using System.Windows.Shapes;

namespace main.layout.Book
{
    /// <summary>
    /// Interaction logic for BooksForm.xaml
    /// </summary>
    public partial class BooksForm : Window
    {
        public BooksForm()
        {
            InitializeComponent();
            List<BookItem> listTest = new List<BookItem>();
            listTest.Add(new BookItem());
            listTest.Add(new BookItem());
            listTest.Add(new BookItem());
            listTest.Add(new BookItem());
            listTest.Add(new BookItem());
            lstBook.ItemsSource = listTest; 
        }
    }
}
