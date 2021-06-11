using main.controller;
using main.model;
using main.model.features;
using main.model.form;
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

namespace main.layout.HomeAndFeature.form
{
    /// <summary>
    /// Interaction logic for CheckOutConfirm.xaml
    /// </summary>
    public partial class CheckOutConfirm : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;

        public static event ClearInfoNotifyHandler ClearInfo;

        public static event updateBookListHandeler checkOutUpdateBook;

        public static event updateMemberListHandeler checkOutUpdateMember;

        DataLoadFromDB dataLoadFromDB = DataLoadFromDB.getIntance();

        private Account account;
        private ObservableCollection<BookToShow> CheckOutBookList;
        public CheckOutConfirm(Account account, ObservableCollection<BookToShow> CheckOutBookList)
        {
            InitializeComponent();
            this.account = account;
            this.CheckOutBookList = CheckOutBookList;
            this.DataContext = new CheckOutConfirmViewModel(account.id.ToString(), CheckOutBookList);
            ToggleForm();
        }
       
        private void addBookToLendingList(Account account, ObservableCollection<BookToShow> CheckOutBookList)
        {
            foreach(var book in CheckOutBookList)
            {
                BookItem bookItem = book.toBookItem();
                bookItem.lendingStatus = model.enums.LendingStatus.LOANED;
                bookItem.bordate = DateTime.Now;
                DateTime dateTime = (DateTime)bookItem.bordate;
                bookItem.dueDate = dateTime.AddDays(10);
                if (dataLoadFromDB.updateBookItem(bookItem) != null)
                {
                    account.addNewBookToLendingList(bookItem);
                    checkOutUpdateBook();
                    checkOutUpdateMember();
                }
                else
                {
                    MessageBox.Show("Unknow error");
                }  
                
                
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ToggleForm();
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            addBookToLendingList(account, CheckOutBookList);
            ClearInfo();
            this.Close();
            ToggleForm();
        }
    }
}
