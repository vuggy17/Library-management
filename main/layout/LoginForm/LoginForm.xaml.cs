using main.layout.Book;
using main.layout.HomeAndFeature.components;
using main.layout.LoginForm.Components;
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
    /// Interaction logic for loginForm.xaml
    /// </summary>
    public partial class loginForm : Window
    {
        
        public loginForm()
        {
            InitializeComponent();
            LoginBoard.loginSuccess += LoginBoard_loginSuccess;         
            

        }

        

        private void LoginBoard_loginSuccess()
        {
            this.DialogResult = true;
            this.Close();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if(this.DialogResult != true)
            {
                Application.Current.Shutdown();
            }
            
        }
    }
}
