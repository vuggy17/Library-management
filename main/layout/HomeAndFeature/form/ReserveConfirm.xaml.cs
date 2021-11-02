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
    /// Interaction logic for ReserveConfirm.xaml
    /// </summary>
    public partial class ReserveConfirm : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;

        public static event ClearInfoNotifyHandler ClearInfo;

        private Account account;

        private ObservableCollection<BookToReserve> reservedList;

        private List<BookItem> listReservedItem;

        DataLoadFromDB dataLoadFromDB = DataLoadFromDB.getIntance();
        public ReserveConfirm(Account account, ObservableCollection<BookToReserve> reservedList)
        {
            InitializeComponent();
            ToggleForm();
            DataContext = new ReserveConfrimViewModel(account.id.ToString(), reservedList);
            this.account = account;
            this.reservedList = reservedList;
            listReservedItem = new List<BookItem>();
        }
        private List<BookItem> getReserverableList(model.Book book)
        {
            var bookItems = new List<BookItem>();
            foreach (var bookItem in book.getAllBookItems())
            {
                if((bookItem.lendingStatus == model.enums.LendingStatus.LOANED || bookItem.lendingStatus ==model.enums.LendingStatus.RENEWED ) && !isInLendingBookList(bookItem))
                {
                    bookItems.Add(bookItem);
                }
            }
            return bookItems.OrderBy(o => o.dueDate).ToList();
        }
        private List<BookItem> getListReservedItem()
        {
            var bookItems = new List<BookItem>();
            foreach (var Reservedbook in reservedList)
            {
                model.Book book = Reservedbook.toBook();
                if(Reservedbook.Count > getReserverableList(book).Count)
                {
                    MessageBoxResult result = MessageBox.Show($"You can only reserve '{getReserverableList(book).Count}' of '{book.title}! Do you want to continue?'","Warning",MessageBoxButton.YesNo,MessageBoxImage.Warning);
                    if(result == MessageBoxResult.Yes)
                    {
                        for (int i = 0; i < getReserverableList(book).Count; i++)
                        {
                            var bookItem = getReserverableList(book)[i];
                            bookItems.Add(bookItem);
                            

                        }
                    }                    
                }
                else
                {
                    for (int i = 0; i < Reservedbook.Count; i++)
                    {
                        var bookItem = getReserverableList(book)[i];
                        bookItems.Add(bookItem);
                    }
                }             

            }
           
            return bookItems;
        }
        private bool isInLendingBookList(BookItem item)
        {
            Account account = CurrentMember.getInstance().GetAccount();
            if (account != null)
            {
                foreach (var bookItem in account.getLendingBookItems())
                {
                    if(item.id == bookItem.id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {

                foreach (var bookItem in getListReservedItem())
                {
                    bookItem.lendingStatus = model.enums.LendingStatus.RESV;
                    if (!isInLendingBookList(bookItem))
                    {
                        if (account.addNewBookToReservedBookList(bookItem))
                        {
                            dataLoadFromDB.updateBookItem(bookItem);
                        }
                    }                   

                }
            
            

            ClearInfo();
            this.Close();
            ToggleForm();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ToggleForm();
        }

    }
}
