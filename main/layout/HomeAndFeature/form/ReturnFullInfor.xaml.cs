using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using main.model;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using main.model.form;

namespace main.layout.HomeAndFeature.components
{
    /// <summary>
    /// Interaction logic for ReturnFullInfor.xaml
    /// </summary>
    public partial class ReturnFullInfor : Window
{
        public static event ToggleFormDialogNotifyHandler ToggleForm;
        public ReturnFullInfor(Account targerAccount)
        {
            InitializeComponent();
            
            DataContext = new ReturnFullInforViewModel(targerAccount);
            ToggleForm();
            if(targerAccount.status == model.enums.AccountStatus.BLACKLISTED)
            {
                blackListCheck.IsChecked = true;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ToggleForm();
        }

       
    }
}
