using main.viewmodel.form;
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

namespace main.layout.Book.Forms
{
    /// <summary>
    /// Interaction logic for EditBookItemForm.xaml
    /// </summary>
    public partial class EditBookItemForm : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;
        public EditBookItemForm(model.Book book)
        {
            InitializeComponent();
            DataContext = new EditBookItemViewModel(book);
            ToggleForm();
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            ToggleForm();
        }
    }
}
