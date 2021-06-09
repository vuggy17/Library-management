using main.controller;
using main.layout.Book.Forms;
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

namespace main.layout.Book.Components
{
    /// <summary>
    /// Interaction logic for EditBook.xaml
    /// </summary>
    public partial class EditBook : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;

        public EditBook(model.Book book)
        {
            InitializeComponent();
            ToggleForm();
            DataContext = new EditBookViewModel(book);
            EditBookItemForm.ToggleForm += EditBookItemForm_ToggleForm; ;
        }

        private void EditBookItemForm_ToggleForm()
        {
            if (this.Opacity == 1)
            {
                this.Opacity = 0.3;

            }
            else
            {
                this.Opacity = 1;

            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {           
            this.Close();
            ToggleForm();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ToggleForm();
        }
    }
}
