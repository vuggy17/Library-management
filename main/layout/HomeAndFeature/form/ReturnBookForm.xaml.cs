using LibraryManagement.controller;
using LibraryManagement.model;
using LibraryManagement.viewmodel.form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace LibraryManagement.layout.HomeAndFeature.form
{
    /// <summary>
    /// Interaction logic for ReturnBookForm.xaml
    /// </summary>
    public partial class ReturnBookForm : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;

        private ReturnBookFormViewModel viewModel;

        private Account account;
        private ObservableCollection<BookToShow> returnBookList;
        public ReturnBookForm(Account account, ObservableCollection<BookToShow> returnBookList)
        {
            InitializeComponent();
            ToggleForm();
            this.account = account;
            this.returnBookList = returnBookList;
            viewModel = new ReturnBookFormViewModel(account.id.ToString(), returnBookList);
            DataContext = viewModel;
        }

        

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ToggleForm();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            viewModel.removeBookToLendingList(account, returnBookList);
            this.Close();
            ToggleForm();
        }
    }
}
