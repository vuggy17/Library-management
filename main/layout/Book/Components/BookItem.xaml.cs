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
    /// Interaction logic for BookItem.xaml
    /// </summary>
    public partial class BookItem : UserControl
    {
        public BookItem()
        {
            InitializeComponent();
        }

        private void Border_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            btnDelete.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Visible;
        }
    }
}
