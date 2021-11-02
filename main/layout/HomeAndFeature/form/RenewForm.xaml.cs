using LibraryManagement.controller;
using LibraryManagement.model;
using LibraryManagement.model.features;
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
    /// Interaction logic for RenewForm.xaml
    /// </summary>
    public partial class RenewForm : Window
    {

        public static event ToggleFormDialogNotifyHandler ToggleForm;

        public static event updateBookListHandeler returnUpdateBook;

        public static event updateMemberListHandeler returnUpdateMember;

        DataLoadFromDB dataLoadFromDB = DataLoadFromDB.getIntance();

        private Account account;
        private ObservableCollection<BookToShow> renewBookList;
        public RenewForm(Account account, ObservableCollection<BookToShow> renewBookList)
        {
            InitializeComponent();
            ToggleForm();
            this.account = account;
            this.renewBookList = renewBookList;
            DataContext = new RenewBookFormViewModel(account.id.ToString(), renewBookList);
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            ToggleForm();

        }
        private void updateDueDateInLendingList(Account account, ObservableCollection<BookToShow> renewBookList)
        {
            foreach (var book in renewBookList)
            {
                BookItem bookItem = dataLoadFromDB.findBookItemByID(int.Parse(book.Id));

                if (bookItem.dueDate != null)
                {
                    DateTime dateTime = (DateTime)bookItem.dueDate;
                    bookItem.dueDate = dateTime.AddDays(10);
                    
                }
                bookItem.lendingStatus = model.enums.LendingStatus.RENEWED;
               
                if(Db.getInstace().updateLendingRenew(CurrentMember.getInstance().GetAccount(), bookItem))
                {
                    if (dataLoadFromDB.updateBookItem(bookItem) != null)
                    {
                        returnUpdateBook();
                        returnUpdateMember();
                    }
                }                
                else
                {
                    MessageBox.Show("Unknow error");
                }

            }
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            updateDueDateInLendingList(account, renewBookList);
            this.Close();
            ToggleForm();
        }
    }
}
