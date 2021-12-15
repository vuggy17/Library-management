using LibraryManagement.controller;
using LibraryManagement.viewmodel.features;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryManagement.model;
using MessageBox = System.Windows.MessageBox;

using LibraryManagement.layout.Book.Forms;
using System.Text.RegularExpressions;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using System.IO;
using LibraryManagement.viewmodel.Books;

namespace LibraryManagement.layout.Book.Components
{
    /// <summary>
    /// Interaction logic for AddBookForm.xaml
    /// </summary>
    public partial class AddBookForm : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;
        private AddNewBookViewModel addNewBookViewModel;
        
        public AddBookForm()
        {
            InitializeComponent();
            lbNumber.Content = "0";
            addNewBookViewModel = new AddNewBookViewModel();
            this.DataContext = addNewBookViewModel;
            ToggleForm();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            ToggleForm();
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(addNewBookViewModel.onButtonSaveClick(tbPrice.Text,tbName.Text,tbAuthor.Text,datePicker.SelectedDate,imageName, int.Parse(lbNumber.Content.ToString())))
            {
                this.Close();
                ToggleForm();
            }            
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int number = Int32.Parse(lbNumber.Content.ToString());
            number++;
            lbNumber.Content = number.ToString();
        }

        private void btnReduce_Click(object sender, RoutedEventArgs e)
        {
            int number = Int32.Parse(lbNumber.Content.ToString());
            if (number > 0)
            {
                number--;
                lbNumber.Content = number.ToString();
            }
        }
    }
}
