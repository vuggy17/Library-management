using main.layout.Book.Components;
using main.layout.HomeAndFeature.components;
using main.viewmodel.features;
using main.layout;
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

namespace main.layout.Book
{
    /// <summary>
    /// Interaction logic for BooksForm.xaml
    /// </summary>
    public partial class BooksForm : Window
    {
        LibrarianIconNavigationViewModel librarianIconNavigationViewModel;
        public BooksForm()
        {
            InitializeComponent();
            librarianIconNavigationViewModel = new LibrarianIconNavigationViewModel();
            LibrarianIconNavigationViewModel.updatebar += FeatureNavigationViewModel_ChangePage;
            LogoutViewModel.logout += LogoutViewModel_logout;
            AddBookForm.ToggleForm += ToggleForm;
            EditBook.ToggleForm += ToggleForm;
            DeleteBookBoard.ToggleForm += ToggleForm;
            LibrarianEdit.ToggleForm += ToggleForm;
        }

        private void LogoutViewModel_logout()
        {
            var loginForm = new LoginForm.LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void ToggleForm()
        {
            if (this.Opacity == 1)
            {
                this.Opacity = 0.3;
            }
            else this.Opacity = 1;
            if (this.IsEnabled == true)
            {
                this.IsEnabled = false;
            }
            else this.IsEnabled = true;
        }

        private void FeatureNavigationViewModel_ChangePage()
        {
          if (LibrarianBar.Visibility == Visibility.Hidden)
              LibrarianBar.Visibility = Visibility.Visible;
          else LibrarianBar.Visibility = Visibility.Hidden;                   
        }
    }
}
