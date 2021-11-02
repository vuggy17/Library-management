using LibraryManagement.controller;
using LibraryManagement.layout.Book.Forms;
using LibraryManagement.viewmodel.features;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManagement.layout.Book.Components
{
    /// <summary>
    /// Interaction logic for EditBook.xaml
    /// </summary>
    public partial class EditBook : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;

        model.Book book;
        public EditBook(model.Book book)
        {
            InitializeComponent();
            ToggleForm();
            this.book = new model.Book(book);
            DataContext = new EditBookViewModel(book);
            EditBookItemForm.ToggleForm += EditBookItemForm_ToggleForm; ;
        }

        private void EditBookItemForm_ToggleForm()
        {
            if (this.Opacity == 1)
            {
                this.Opacity = 0.3;

            }
            else
            {
                this.Opacity = 1;

            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {           
            this.Close();
            ToggleForm();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ToggleForm();
        }
        string imageName = "";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImageSourceConverter isc = new ImageSourceConverter();
                imageName = open.FileName;
                imgBookCover.SetValue(Image.SourceProperty, isc.ConvertFromString(imageName));
                updateBookImage(this.book);
            }
        }
        private void updateBookImage(model.Book book)
        {
            if (imageName != "")
            {
                byte[] imageData = File.ReadAllBytes(imageName);
                string base64String = Convert.ToBase64String(imageData, 0, imageData.Length);
                book.imgSource = base64String;
                DataContext = new EditBookViewModel(book);
            }
        }
    }
}
