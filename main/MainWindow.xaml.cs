
using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryManagement.model;
using LibraryManagement.model.enums;
using LibraryManagement.layout.HomeAndFeature;
using LibraryManagement.layout.Book;
using LibraryManagement.layout.member;
using LibraryManagement.layout;
using LibraryManagement.layout.LoginForm;
using LibraryManagement.layout.Book.Components;
using LibraryManagement.layout.HomeAndFeature.form;
using LibraryManagement.model.features;
using LibraryManagement.layout.HomeAndFeature.components;
using LibraryManagement.viewmodel;
using LibraryManagement.layout.Book.Forms;
using LibraryManagement.controller;
using LibraryManagement.layout.member.forms;
using LibraryManagement.viewmodel.features;
using System.IO;

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

  
    public partial class MainWindow : Window
    {
        HomeNavigationViewModel homePageViewModel = new HomeNavigationViewModel();

        DataLoadFromDB data = DataLoadFromDB.getIntance();

        public static event ResetInfoScan resetInfoScan;
        public MainWindow()
        {
            InitializeComponent();
            
            loginForm login = new loginForm();
            login.ShowDialog();
            if (login.DialogResult == true)
            {
                data.getAllMembers();
                data.getBookItems();
                data.getBooks();
            };
            data.getAllMembers();
            data.getBookItems();
            data.getBooks();
            HomePage.DataContext = homePageViewModel;
            RenewForm.ToggleForm += ToggleForm;
            ReturnBookForm.ToggleForm += ToggleForm;
            ReturnFullInfor.ToggleForm += ToggleForm;
            CheckOutConfirm.ToggleForm += ToggleForm;
            ReseverBookForm.ToggleForm += ToggleForm;
            ReserveConfirm.ToggleForm += ToggleForm;
            AddBookForm.ToggleForm += ToggleForm;
            DeleteBookBoard.ToggleForm += ToggleForm;
            EditBook.ToggleForm += ToggleForm;
            CurrentMemberReserverBooks.ToggleForm += ToggleForm;
            AddBookSuccessForm.ToggleForm += ToggleForm;

            AddNewMemberForm.ToggleForm += ToggleForm;
            BlockConfirm.ToggleForm += ToggleForm;
            UnBlockConfirm.ToggleForm += ToggleForm;
            DeleteConfirn.ToggleForm += ToggleForm;
            AddSuccess.ToggleForm += ToggleForm;
            EditForm.ToggleForm += ToggleForm;

            LibrarianEdit.ToggleForm += ToggleForm;
           
            LibrarianIconNavigationViewModel.updatebar += LibrarianIconNavigationViewModel_updatebar;
            LibrarianBar.logout += LibrarianBar_logout;


            HomeNavigationViewModel.ChangePage += HomeNavigationViewModel_ChangePage;
            this.DataContext = new MemberViewModel();
        }
        
        private void LibrarianBar_logout()
        {
            System.Windows.Forms.Application.Restart();
            this.Close();

        }

        private void LibrarianIconNavigationViewModel_updatebar()
        {
           if(libradianBar.Visibility == Visibility.Visible)
            {
                libradianBar.Visibility = Visibility.Hidden;
            }
            else
            {
                libradianBar.Visibility = Visibility.Visible;
            }
        }

        private void HomeNavigationViewModel_ChangePage(string page)
        {
            switch (page)
            {
                case "Home":
                    
                    HomePage.Visibility = Visibility.Visible;
                    FeatureNavigation.Visibility = Visibility.Visible;
                    BooksAddBoard.Visibility = Visibility.Hidden;
                    BookPage.Visibility = Visibility.Hidden;
                    MemberNavigation.Visibility = Visibility.Hidden;
                    MemberPage.Visibility = Visibility.Hidden;

                    break;
                case "Books":
                    BookPage.Visibility = Visibility.Visible;
                    BooksAddBoard.Visibility = Visibility.Visible;
                    HomePage.Visibility = Visibility.Hidden;
                    FeatureNavigation.Visibility = Visibility.Hidden;
                    MemberNavigation.Visibility = Visibility.Hidden;
                    MemberPage.Visibility = Visibility.Hidden;
                    resetInfoScan();
                    break;
                case "Members":
                    MemberNavigation.Visibility = Visibility.Visible;
                    MemberPage.Visibility = Visibility.Visible;
                    BooksAddBoard.Visibility = Visibility.Hidden;
                    BookPage.Visibility = Visibility.Hidden;
                    HomePage.Visibility = Visibility.Hidden;
                    FeatureNavigation.Visibility = Visibility.Hidden;
                    resetInfoScan();
                    break;

            }
        }
        private void ToggleForm()
        {
            if (this.Opacity == 1)
            {
                this.Opacity = 0.3;
                this.IsEnabled = false;
               

            }
            else
            {
                this.Opacity = 1;
                this.IsEnabled = true;
               

            }
        }
    }
}

