using main.model;
using main.viewmodel.form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace main.layout.HomeAndFeature.form
{
    /// <summary>
    /// Interaction logic for ReserveConfirm.xaml
    /// </summary>
    public partial class ReserveConfirm : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;

        public static event ClearInfoNotifyHandler ClearInfo;
        public ReserveConfirm(Account account, ObservableCollection<BookToReserve> bookToShows)
        {
            InitializeComponent();
            ToggleForm();
            DataContext = new ReserveConfrimViewModel(account.id.ToString(), bookToShows);

        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            //Do something
            ClearInfo();
            this.Close();
            ToggleForm();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ToggleForm();
        }
    }
}
