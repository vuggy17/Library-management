using LibraryManagement.controller;
using LibraryManagement.model;
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
        private bool checkPass(string password)
        {
            if (PasswordHash.ValidatePassword(password, currentStaff.password))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Wrong password!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        private bool checkConfrimPass(string password, string confirmPwd)
        {
            if (password.Length < 8)
            {
                MessageBox.Show("Password is atleast 8 character", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (password == confirmPwd)
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
            var newPwd = newPass.Password;
            var oldPwd = pass.Password;
            var confirmPwd = newPassConfirm.Password;

            changeStaffPassword(oldPwd, newPwd, confirmPwd);
        }
        private void changeStaffPassword(string oldPassword, string newPassword, string confirmPwd)
        {
            try
            {
                currentStaff.changePassWord(oldPassword, newPassword, confirmPwd);
                this.Close();
                ToggleForm();
            }
            catch (Exception e)
            {
                var exCode = e.Message.ToString();
                switch (exCode)
                {
                    case "WRONG_PASS":
                        MessageBox.Show("Wrong password!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case "INVALID_PASS":
                        MessageBox.Show("New password must have at least 8 character", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case "NOT_MATCH":
                        MessageBox.Show("New password not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case "DB_ERROR":
                        MessageBox.Show("Connection error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    default:
                        MessageBox.Show("System error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
                Console.WriteLine(exCode);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ToggleForm();
        }
    }
}
