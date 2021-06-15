﻿using main.controller;
using main.viewmodel.features;
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
using main.model;
using MessageBox = System.Windows.MessageBox;

using main.layout.Book.Forms;
using System.Text.RegularExpressions;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace main.layout.Book.Components
{
    /// <summary>
    /// Interaction logic for AddBookForm.xaml
    /// </summary>
    public partial class AddBookForm : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;
        private DataLoadFromDB data = DataLoadFromDB.getIntance();
        public static event updateBookListHandeler update;


        
        public AddBookForm()
        {
            InitializeComponent();
            lbNumber.Content = "0";          
            ToggleForm();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            ToggleForm();
        }


        private static readonly Regex _regex = new Regex("[^0-9-]+"); //regex that matches disallowed text
        private bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(tbPrice.Text !=""&& tbName.Text!="" && tbAuthor.Text!="" && datePicker.SelectedDate != null)
            {
                if (IsTextAllowed(tbPrice.Text) && Double.Parse(tbPrice.Text) > 1000 && Double.Parse(tbPrice.Text)<1000000000)
                {
                    if(datePicker.SelectedDate.Value <= DateTime.Now.Date)
                    {
                        model.Book newBook = new model.Book(tbName.Text, tbAuthor.Text, datePicker.SelectedDate.Value, Double.Parse(tbPrice.Text));
                        data.addNewBook(newBook);
                        int numOfCopies = int.Parse(lbNumber.Content.ToString());
                        int autoID = newBook.id*1000;
                        for (int i = 0; i < numOfCopies; i++)
                        {
                            autoID += 1;
                            data.addNewBookItem(new main.model.BookItem(autoID, newBook.id, model.enums.LendingStatus.AVAI));
                        }
                        AddBookSuccessForm add = new AddBookSuccessForm(newBook);
                        add.Show();
                        update();
                        this.Close();
                        ToggleForm();
                    }
                    else
                    {
                        MessageBox.Show("Pulishing date is in future!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Price must be a number between 1.000đ - 1.000.000.000đ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }               
            }
            else
            {
                MessageBox.Show("Some field is empy","Error", MessageBoxButton.OK,MessageBoxImage.Error);
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
