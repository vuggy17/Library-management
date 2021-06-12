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

namespace main.layout.HomeAndFeature.components
{
    /// <summary>
    /// Interaction logic for LibrarianIcon.xaml
    /// </summary>

    public partial class LibrarianIcon : UserControl
    {
        LibrarianIconNavigationViewModel librarianIconNavigationViewModel;
        public LibrarianIcon()
        {
            InitializeComponent();
            librarianIconNavigationViewModel = new LibrarianIconNavigationViewModel();
            DataContext = librarianIconNavigationViewModel;
        }
    }
}
