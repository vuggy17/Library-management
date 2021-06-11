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
                if(bookItem.lendingStatus != model.enums.LendingStatus.RESV)
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
               for(int i = 0; i< Reservedbook.Count; i++)
                {
                    var bookItem = getReserverableList(book)[i];
                                       
                    bookItems.Add(bookItem);
                }

            }
            return bookItems;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            foreach (var bookItem in getListReservedItem())
            {
                bookItem.lendingStatus = model.enums.LendingStatus.RESV;
                dataLoadFromDB.updateBookItem(bookItem);
                account.addNewBookToReservedBookList(bookItem);
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
