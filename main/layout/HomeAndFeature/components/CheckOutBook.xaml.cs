using main.layout.HomeAndFeature.form;
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

namespace main.layout.HomeAndFeature.components
{
    /// <summary>
    /// Interaction logic for CheckOutBook.xaml
    /// </summary>
    public partial class CheckOutBook : UserControl
    {
        public CheckOutBook()
        {
            InitializeComponent();
            this.DataContext = new CheckOutBookViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RenewForm renew = new RenewForm();
            renew.Show();
        }
    }
}
