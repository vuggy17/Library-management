using main.controller;
using main.model;
using main.viewmodel.form;
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
    /// Interaction logic for ReturnBookForm.xaml
    /// </summary>
    public partial class ReturnBookForm : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;

        public static event updateBookListHandeler returnUpdateBook;

        public static event updateMemberListHandeler returnUpdateMember;

        DataLoadFromDB dataLoadFromDB = DataLoadFromDB.getIntance();

        private Account account;
        private ObservableCollection<BookToShow> returnBookList;
        public ReturnBookForm(Account account, ObservableCollection<BookToShow> returnBookList)
        {
            InitializeComponent();
            ToggleForm();
            this.account = account;
            this.returnBookList = returnBookList;
            DataContext = new ReturnBookFormViewModel(account.id.ToString(), returnBookList);
        }

        private void removeBookToLendingList(Account account, ObservableCollection<BookToShow> CheckOutBookList)
        {
            foreach (var book in CheckOutBookList)
            {
                BookItem bookItem = book.toBookItem();
                account.removeBookToLendingBookList(bookItem);
                if (bookItem.lendingStatus != model.enums.LendingStatus.RESV)
                {
                    bookItem.lendingStatus = model.enums.LendingStatus.AVAI;
                }
                else
                {
                    bookItem.lendingStatus = model.enums.LendingStatus.READY;
                }               
                bookItem.bordate = null;
                bookItem.dueDate = null;
                if (dataLoadFromDB.updateBookItem(bookItem) != null)
                {
                   
                    returnUpdateBook();
                    returnUpdateMember();
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
            removeBookToLendingList(account, returnBookList);
            this.Close();
            ToggleForm();
        }
    }
}
