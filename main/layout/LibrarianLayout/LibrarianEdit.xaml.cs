using main.controller;
using main.model;
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

namespace main.layout.HomeAndFeature.components
{
    /// <summary>
    /// Interaction logic for LibrarianEdit.xaml
    /// </summary>
    public partial class LibrarianEdit : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;
        Staff currentStaff = CurrentStaff.getIntance();
        public LibrarianEdit()
        {
            InitializeComponent();
            ToggleForm();            
            id.Text = currentStaff.id.ToString();
            name.Text = currentStaff.info.name;
            address.Text = currentStaff.info.address;
            phone.Text = currentStaff.info.phone;
            email.Text = currentStaff.info.email;
            ChangePasswordBoard.ToggleForm += ChangePasswordBoard_ToggleForm;

        }

        private void ChangePasswordBoard_ToggleForm()
        {
            if (this.Opacity == 1)
            {
                this.Opacity = 0.3;
                this.IsEnabled = false;
                this.Topmost = false;


            }
            else
            {
                this.Opacity = 1;
                this.IsEnabled = true;
                this.Topmost = true;


            }
        }

        public bool isValidName(string name)
        {
            var regexItem = new Regex("^[a-zA-Z ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]*$");
            if (!regexItem.IsMatch(name))
            {
                MessageBox.Show("Name can't constrain number or special char", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            else
            {
                return true;
            }
        }
        public bool IsValidEmail(string emailaddress)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailaddress);
            if (match.Success)
                return true;
            else
            {
                MessageBox.Show("In valid email", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

        }
        private bool isVietnamesePhoneNumber(string number)
        {
            Regex _regex = new Regex("(03|05|07|08|09)+([0-9])");
            if (!_regex.IsMatch(number))
            {
                MessageBox.Show("Phone Number Error!", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (id.Text != "" && name.Text != "" && address.Text != "" && phone.Text != ""  && email.Text != "")
            {
                if (IsValidEmail(email.Text) && isVietnamesePhoneNumber(phone.Text) && isValidName(name.Text))
                {
                    Person newInfo = new Person(name.Text, address.Text, email.Text, phone.Text);
                    currentStaff.ChangeInfo(newInfo);
                    this.Close();
                    ToggleForm();
                    MessageBox.Show("Update success", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("This infomation can not place empty!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ToggleForm();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordBoard changePasswordBoard = new ChangePasswordBoard();
            changePasswordBoard.Show();
        }
    }
}
