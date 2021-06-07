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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace main.layout.LoginForm.Components
{
    /// <summary>
    /// Interaction logic for LoginBoard.xaml
    /// </summary>
    public partial class LoginBoard : UserControl
    {
        public LoginBoard()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel();
        }
        public class TemplateConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter,
                System.Globalization.CultureInfo culture)
            {
                string strings = "";
                foreach (string str in values)
                {
                    strings += str;
                }
                return strings;
            }

            public object[] ConvertBack(object value, Type[] targetTypes, object parameter,
                System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
