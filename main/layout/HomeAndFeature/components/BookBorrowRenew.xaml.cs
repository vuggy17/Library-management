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
    /// Interaction logic for BookBorrowRenew.xaml
    /// </summary>
    /// 
    public partial class BookBorrowRenew : UserControl
    {
        public List<String> tempList = new List<string>();
        public BookBorrowRenew()
        {
            InitializeComponent();
            tempList.Add("");
            tempList.Add("");
            tempList.Add("");
            tempList.Add("");
            tempList.Add("");
            RenewBookList.ItemsSource = tempList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RenewForm renew = new RenewForm();
            renew.Show();
        }

        private void SelectAll_Checked(object sender, RoutedEventArgs e)
        {
            RenewBookList.SelectAll();
        }

        private void SelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            RenewBookList.UnselectAll();
        }
    }
}
