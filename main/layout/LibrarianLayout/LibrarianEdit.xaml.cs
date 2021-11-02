using LibraryManagement.controller;
using LibraryManagement.model;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using MessageBox = System.Windows.MessageBox;

namespace LibraryManagement.layout.HomeAndFeature.components
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
            img.Source = currentStaff.info.image;
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

       
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentStaff.updateInfo(id.Text, name.Text, address.Text, phone.Text, email.Text, imageName);
                MessageBox.Show("Update success", "", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
                ToggleForm();
            }
            catch (Exception ex)
            {
                var exCode = ex.Message.ToString();
                if(exCode =="BAD_INPUT") 
                MessageBox.Show("Information is required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    MessageBox.Show("System error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        //public bool updateStaffInfo(string id, string name, string address, string phone, string mail) 
        //{
        //    if (String.IsNullOrEmpty(id) || String.IsNullOrEmpty(name) || String.IsNullOrEmpty(address) || String.IsNullOrEmpty(phone) || String.IsNullOrEmpty(mail))
        //        throw new Exception("BAD_INPUT");
        //    if (IsValidEmail(email.Text) && isVietnamesePhoneNumber(phone) && isValidName(name))
        //    {
        //        Person newInfo = new Person(name, address, mail, phone); ;
        //        if (imageName != "")
        //        {
        //            byte[] imageData = File.ReadAllBytes(imageName);
        //            string base64String = Convert.ToBase64String(imageData, 0, imageData.Length);
        //            newInfo.imgSource = base64String;
        //        }
        //        currentStaff.ChangeInfo(newInfo);
        //        this.Close();
        //        ToggleForm();
        //        return true;
        //    }
        //    return false;
        //}

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
        string imageName = "";
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImageSourceConverter isc = new ImageSourceConverter();
                imageName = open.FileName;
                img.SetValue(Image.SourceProperty, isc.ConvertFromString(imageName));


            }
        }
    }
}
