using LibraryManagement.model.features;
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

namespace LibraryManagement.layout.HomeAndFeature.components
{
    /// <summary>
    /// Interaction logic for UserScanerBoard.xaml
    /// </summary>
    public partial class UserScanerBoard : UserControl
    {
        public UserScanerBoard()
        {
            InitializeComponent();
            this.DataContext = new UserScanerBoardViewModel();
        }


        private void searchBar_LostFocus(object sender, RoutedEventArgs e)
        {
            searchBar.Text = "";
        }
    }
}
