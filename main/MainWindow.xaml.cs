
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
using main.model;
using main.model.enums;
using main.layout.HomeAndFeature;
using main.layout.Book;
using main.layout.member;
using main.layout;
using main.layout.LoginForm;
using main.layout.Book.Components;
using main.layout.HomeAndFeature.form;

namespace main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Visibility = Visibility.Collapsed;
            //HomeAndFeatureTest homeAndFeatureTest = new HomeAndFeatureTest();
            //homeAndFeatureTest.Show();
            //LoginForm login = new LoginForm();
            //login.Show();
            BooksForm books = new BooksForm();
            books.Show();
            //BooksForm bookTest = new BooksForm();
            //bookTest.Show();
            //AddBookForm addBookForm = new AddBookForm();
            //addBookForm.Show();
            //RenewForm renewForm = new RenewForm();
            //renewForm.Show();

            // db test


            var myaccount = new Account("Phong", "kh", "phong@gmail.com", "phone", 1, "pass", AccountStatus.ACTIVE, new DateTime(1000000), 5);
            //MessageBox.Show(myaccount.p);
            //Db.getInstace().createNewAccount(myaccount);
            //Console.WriteLine( Db.getInstace().getPersonId(myaccount.info.name, myaccount.info.email));



        }
    }
}
