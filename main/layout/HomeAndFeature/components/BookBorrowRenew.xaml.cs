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
    /// Interaction logic for BookBorrowRenew.xaml
    /// </summary>
    /// 
    public partial class BookBorrowRenew : UserControl
    {
        private ObservableCollection<BookToShow> selectedBooks;

        private CurrentMember currentMember = CurrentMember.getInstance();
        public BookBorrowRenew()
        {
            InitializeComponent();
            selectedBooks = new ObservableCollection<BookToShow>();
            CurrentMember current = CurrentMember.getInstance();
            DataContext = new RenewBookViewModel(current.GetAccount());
            UserScanerBoardViewModel.updateLedingBookList += UserScanerBoardViewModel_updateLedingBookList;
        }

        private void UserScanerBoardViewModel_updateLedingBookList(model.Account account)
        {
            DataContext = new RenewBookViewModel(account);
            SelectAll.IsChecked = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            selectedBooks = selectedBooksConvert();            
            if (selectedBooks.Count != 0 && checkBookCanRenew())
            {
                
                RenewForm renew = new RenewForm(currentMember.GetAccount(),selectedBooks);
                renew.Show();
            }
        }
        private bool checkBookCanRenew()
        {
            foreach (var book in selectedBooks)
            {
                if(book.lendingStatus == "Reserved")
                {
                    MessageBox.Show(book.Name + " is reserved by order!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                    return false;
                }
                if (book.OverDueFee > 0)
                {
                    MessageBox.Show(book.Name + " is over due! Please return first!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if(book.lendingStatus == "Renewed")
                {
                    MessageBox.Show(book.Name + " is already renewed one time!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

            }

            return true;
        }
        private ObservableCollection<BookToShow> selectedBooksConvert()
        {
            ObservableCollection<BookToShow> bookToShows = new ObservableCollection<BookToShow>();
            foreach (var selectedItem in RenewBookList.SelectedItems)
            {
                bookToShows.Add(selectedItem as BookToShow);
            }
            return bookToShows;
        }

        private void SelectAll_Checked(object sender, RoutedEventArgs e)
        {
            RenewBookList.SelectAll();
        }

        private void SelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            RenewBookList.UnselectAll();
        }
    }
}
