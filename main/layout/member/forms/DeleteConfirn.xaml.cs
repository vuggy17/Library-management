using LibraryManagement.controller;
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
using System.Windows.Shapes;

namespace LibraryManagement.layout.member.forms
{
    /// <summary>
    /// Interaction logic for DeleteConfirn.xaml
    /// </summary>
    public partial class DeleteConfirn : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;
        DataLoadFromDB data = DataLoadFromDB.getIntance();
        public static event updateMemberListHandeler updateMember;
        public DeleteConfirn()
        {
            InitializeComponent();
            DataContext = MemberViewModel.getInstance();
            ToggleForm();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            model.Account account = data.findMemberByID(int.Parse(ID.Content.ToString()));
            if (account != null)
            {
                foreach (var bookItem in account.getLendingBookItems())
                {
                    bookItem.lendingStatus = model.enums.LendingStatus.LOST;                    
                    data.updateBookItem(bookItem);
                }
                while (account.getReservedBookItem().Count > 0)
                {
                    account.removeBookToReserveBookList(account.getReservedBookItem()[0], "CANCELED");
                }
                
                
                data.deleteMember(account);
                updateMember();
                this.Close();
                ToggleForm();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            ToggleForm();
        }
    }
}

