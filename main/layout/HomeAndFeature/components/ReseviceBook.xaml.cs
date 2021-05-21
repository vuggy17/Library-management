using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using main.viewmodel.features;
using main.layout.HomeAndFeature.form;

namespace main.layout.HomeAndFeature.components
{
    /// <summary>
    /// Interaction logic for ReseviceBook.xaml
    /// </summary>
    public partial class ReseviceBook : UserControl
    {

        
        public ReseviceBook()
        {
            InitializeComponent();
            this.DataContext = new ResearveBookViewModel();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RenewForm renew = new RenewForm();
            renew.Show();
        }
    }
}
