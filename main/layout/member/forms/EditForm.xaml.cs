using main.controller;
using main.model;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace main.layout.member.forms
{
    /// <summary>
    /// Interaction logic for EditForm.xaml
    /// </summary>
    public partial class EditForm : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;
        DataLoadFromDB data = DataLoadFromDB.getIntance();
        public static event updateMemberListHandeler updateMember;
        public EditForm()
        {
            InitializeComponent();
            ToggleForm();
            DataContext = MemberViewModel.getInstance();

          
        }
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text != "" && tbAddress.Text != "" && tbEmail.Text != "" && tbPhone.Text != "")
            {
                if (IsValidEmail(tbEmail.Text) && isVietnamesePhoneNumber(tbPhone.Text) && isValidName(tbName.Text))
                {
                    int updateAccountID = int.Parse(lbId.Content.ToString());                   
                    Person newInfo = new Person(tbName.Text, tbAddress.Text, tbEmail.Text, tbPhone.Text);
                    Account updateAccount= data.findMemberByID(updateAccountID);
                    newInfo.id = updateAccount.info.id;
                    if(imageName != "")
                    {
                        byte[] imageData = File.ReadAllBytes(imageName);
                        string base64String = Convert.ToBase64String(imageData, 0, imageData.Length);
                        newInfo.imgSource = base64String;
                    }
                   
                    
                    if (data.updateMemberInfo(newInfo) != null)
                    {
                        MessageBox.Show("Update Success", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Update Failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    updateMember();
                    ToggleForm();
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("This field can not place empty!", "error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            ToggleForm();
        }
        string imageName = "";
        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImageSourceConverter isc = new ImageSourceConverter();
                imageName = open.FileName;
                imgBookCover.SetValue(Image.SourceProperty, isc.ConvertFromString(imageName));


            }
        }
    }
}
