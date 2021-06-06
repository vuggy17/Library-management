using main.layout.HomeAndFeature.form;
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

namespace main.layout.HomeAndFeature.components
{
    /// <summary>
    /// Interaction logic for BookBorrowReturn.xaml
    /// </summary>
    public partial class BookBorrowReturn : UserControl
    {
        
        public BookBorrowReturn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReturnBookForm returnBook = new ReturnBookForm();
            returnBook.Show();
        }

        private void SelectAll_Checked(object sender, RoutedEventArgs e)
        {
            ListReturnBook.SelectAll();
        }

        private void SelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            ListReturnBook.UnselectAll();
        }
    }
}
