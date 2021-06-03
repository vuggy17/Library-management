using main.layout.Book;
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
using System.Windows.Shapes;

namespace main.layout.LoginForm
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
            LoginViewModel.login += LoginViewModel_login;
        }

        private void LoginViewModel_login()
        {
            // Check account here
            BooksForm booksForm = new BooksForm();
            booksForm.Show();
            this.Close();
        }
    }
}
