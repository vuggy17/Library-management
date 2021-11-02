using LibraryManagement.viewmodel;
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

namespace LibraryManagement.layout.HomeAndFeature.components
{
    /// <summary>
    /// Interaction logic for HomeNavigationBar.xaml
    /// </summary>
    public partial class HomeNavigationBar : UserControl
    {
        public HomeNavigationBar()
        {
            InitializeComponent();
            DataContext = new HomeNavigationViewModel();
            HomeNavigationViewModel.ChangePage += HomeNavigationViewModel_ChangePage;
        }

        private void HomeNavigationViewModel_ChangePage(string page)
        {
            switch (page)
            {
                case "Home":
                    Home.Opacity = 1;
                    Books.Opacity = 0.5;
                    Members.Opacity = 0.5;
                    break;
                case "Books":
                    Home.Opacity = 0.5;
                    Books.Opacity = 1;
                    Members.Opacity = 0.5;
                    break;
                case "Members":
                    Home.Opacity = 0.5;
                    Books.Opacity = 0.5;
                    Members.Opacity = 1;
                    break;
            }
        }
    }
}
