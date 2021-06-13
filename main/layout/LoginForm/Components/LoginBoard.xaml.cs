using main.controller;
using main.layout.Book;
using main.model;
using main.viewmodel.features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// 
    public partial class LoginBoard : UserControl
    {
        List<Staff> allStaffAccount;

        public static event LoginHandler loginSuccess;

        public LoginBoard()
        {
            InitializeComponent();
            error.Text = "";
            allStaffAccount = new List<Staff>();
            allStaffAccount = LoadAllStaffAccount();
            
        }
        private Staff getEmailLogin(string email)
        {
            foreach (var staff in allStaffAccount)
            {
                if(staff.info.email == email)
                {
                    return staff;
                }
            }
            return null;
        }
        private Staff getIDLogin(string id)
        {
            foreach (var staff in allStaffAccount)
            {
                if (staff.id.ToString() == id)
                {
                    return staff;
                }
            }
            return null;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(email.Text !="" && password.Password != "")
            {
                if (checkEmaillogin(email.Text))
                {
                    Staff loginStaff = getEmailLogin(email.Text);
                    if(loginStaff != null)
                    {
                        if(loginStaff.password == password.Password)
                        {
                            error.Text = "Login success";
                            error.Foreground = Brushes.Green;
                            CurrentStaff.setCurrentStaff(loginStaff);                           
                            loginSuccess();                           
                            
                        }
                        else
                        {
                            error.Text = "Wrong password";
                        }
                    }
                    else
                    {
                        error.Text = "Email not exist";
                    }
                }
                else
                {
                    Staff loginStaff = getIDLogin(email.Text);
                    if (loginStaff != null)
                    {
                        if (loginStaff.password == password.Password)
                        {
                            error.Text = "Login success";
                            error.Foreground = Brushes.Green;
                            CurrentStaff.setCurrentStaff(loginStaff);
                            loginSuccess();

                        }
                        else
                        {
                            error.Text = "Wrong password";
                        }
                    }
                    else
                    {
                        error.Text = "ID not exist";
                    }
                }
            }
            else
            {
                error.Text = "Email or Password is empty";
            }
        }
        private List<Staff> LoadAllStaffAccount()
        {
            List<Staff> loadAllStaff = new List<Staff>();
            loadAllStaff = Db.getInstace().getAllStaffs();
            return loadAllStaff;
        }
        
        private bool checkEmaillogin(string emailaddress)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailaddress);
            if (match.Success)
                return true;
            else
            {               
                return false;
            }

        }
    }
}
