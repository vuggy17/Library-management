using main.model;
using main.model.features;
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
    /// Interaction logic for ReseverBookForm.xaml
    /// </summary>
    public partial class ReseverBookForm : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;


        public ReseverBookForm(ObservableCollection<BookToReserve> alreadyAddBookToReserves)
        {
            InitializeComponent();
            this.DataContext = new ResearveBookFormViewModel(alreadyAddBookToReserves);
            ToggleForm();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ToggleForm();
        }
    }
}
