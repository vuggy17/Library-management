using main.controller;
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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using main.model;


namespace main.layout.Book.Components
{
    /// <summary>
    /// Interaction logic for AddBookForm.xaml
    /// </summary>
    public partial class AddBookForm : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;
        public AddBookForm()
        {
            InitializeComponent();
            lbNumber.Content = "0";
            this.DataContext = new AddBookViewModel();
            ToggleForm();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ToggleForm();
        }

      

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            ListAllBook.addNewBook(new model.Book(12345670, "Rừng NaUy", "Novel", "Haruki Murakami", new DateTime(2021, 6, 2)));           
            this.Close();
            ToggleForm();
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            var result = openFileDialog.ShowDialog();
            if (result == false) return;
            imgBookCover.Source = new BitmapImage(new Uri(openFileDialog.FileName));
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
