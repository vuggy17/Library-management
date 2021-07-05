using main.controller;
using main.model;
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
    /// Interaction logic for ChangePasswordBoard.xaml
    /// </summary>
    public partial class ChangePasswordBoard : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;
        Staff currentStaff = CurrentStaff.getIntance();
        public ChangePasswordBoard()
        {
            InitializeComponent();
            ToggleForm();
        }
        private bool checkPass()
        {
            if(PasswordHash.ValidatePassword(pass.Password, currentStaff.password))            
            {
                return true;
            }
            else
            {
                MessageBox.Show("Wrong password!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }            
        }
       private bool checkConfrimPass()
        {
            if(newPass.Password.Length <8)
            {
                MessageBox.Show("Password is atleast 8 character", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(newPass.Password == newPassConfirm.Password)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Confrim not the same!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(checkPass() && checkConfrimPass())
            {
                currentStaff.password = newPass.Password;

                currentStaff.changePassWord();
                this.Close();
                ToggleForm();
            }
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ToggleForm();
        }
    }
}
