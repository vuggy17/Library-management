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

namespace main.layout.member.forms
{
    /// <summary>
    /// Interaction logic for AddSuccess.xaml
    /// </summary>
    public partial class AddSuccess : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;
        public AddSuccess(int ID)
        {
            InitializeComponent();
            tbID.Content = ID.ToString();           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ToggleForm();

        }
    }
}
