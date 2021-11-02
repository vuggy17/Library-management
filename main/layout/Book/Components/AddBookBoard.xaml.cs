using LibraryManagement.layout.HomeAndFeature.form;
using LibraryManagement.viewmodel.features;
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

namespace LibraryManagement.layout.Book.Components
{
    /// <summary>
    /// Interaction logic for AddBookBoard.xaml
    /// </summary>
    public partial class AddBookBoard : UserControl
    {
        public AddBookBoard()
        {
            InitializeComponent();
        }

        private void btnAddNewBook_Click(object sender, RoutedEventArgs e)
        {
           AddBookForm addBookForm = new AddBookForm();
            addBookForm.Show();
        }
    }
}
