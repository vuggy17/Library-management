using main.model;
using main.model.features;
using main.model.form;
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
    /// Interaction logic for CheckOutConfirm.xaml
    /// </summary>
    public partial class CheckOutConfirm : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;

        public static event ClearInfoNotifyHandler ClearInfo;
        public CheckOutConfirm(Account account, ObservableCollection<BookToShow> bookToShows)
        {
            InitializeComponent();
            this.DataContext = new CheckOutConfirmViewModel(account.id.ToString(), bookToShows);
            ToggleForm();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ToggleForm();
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            ClearInfo();
            this.Close();
            ToggleForm();
        }
    }
}
