using main.controller;
using main.layout.HomeAndFeature.form;
using main.model;
using main.model.features;
using main.viewmodel.features;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace main.layout.HomeAndFeature.components
{
    /// <summary>
    /// Interaction logic for BookBorrowReturn.xaml
    /// </summary>
    public partial class BookBorrowReturn : UserControl
    {
        private ObservableCollection<BookToShow> selectedBooks;

        private CurrentMember currentMember = CurrentMember.getInstance();
        public BookBorrowReturn()
        {
            InitializeComponent();
            selectedBooks = new ObservableCollection<BookToShow>();
            CurrentMember current = CurrentMember.getInstance();
            DataContext = new ReturnBookViewModel(current.GetAccount());
            UserScanerBoardViewModel.updateLedingBookList += UserScanerBoardViewModel_updateLedingBookList;
        }

        private void UserScanerBoardViewModel_updateLedingBookList(Account account)
        {
            DataContext = new ReturnBookViewModel(account);
        }
        private ObservableCollection<BookToShow> selectedBooksConvert()
        {
            ObservableCollection<BookToShow> bookToShows = new ObservableCollection<BookToShow>();
            foreach (var selectedItem in ListReturnBook.SelectedItems)
            {
                bookToShows.Add(selectedItem as BookToShow);
            }
            return bookToShows;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            selectedBooks = selectedBooksConvert();
            if (selectedBooks.Count != 0)
            {
                ReturnBookForm returnBook = new ReturnBookForm(currentMember.GetAccount(),selectedBooks);
                returnBook.Show();
            }
        }

        private void SelectAll_Checked(object sender, RoutedEventArgs e)
        {
            ListReturnBook.SelectAll();
        }

        private void SelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            ListReturnBook.UnselectAll();
        }
    }
}
