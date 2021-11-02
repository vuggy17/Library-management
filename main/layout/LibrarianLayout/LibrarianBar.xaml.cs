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

namespace LibraryManagement.layout.HomeAndFeature.components
{
    /// <summary>
    /// Interaction logic for LibrarianBar.xaml
    /// </summary>
    public partial class LibrarianBar : UserControl
    {
        public static event LogoutHandler logout;
        
        public LibrarianBar()
        {
            InitializeComponent();
        }

        private void tbLogout_Click(object sender, RoutedEventArgs e)
        {
            logout();
            
        }

        private void tbEdit_Click(object sender, RoutedEventArgs e)
        {            
            LibrarianEdit librarianEdit = new LibrarianEdit();
            librarianEdit.Show();
        }
    }
}
