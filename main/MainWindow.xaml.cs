
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
            this.Visibility = Visibility.Hidden;
            HomeAndFeatureTest homeAndFeatureTest = new HomeAndFeatureTest();
            homeAndFeatureTest.Show();
            //BooksForm bookTest = new BooksForm();
            //bookTest.Show();

            //Person duy = new Person("Duy@alljf.com.vn");
            //Person trang = new Person("trang");

            //Account github = new Account(duy);

            //Console.WriteLine("account: "+github.info.email.ToString());

            //var bookStatus = BookFormat.AUDBOOK.ToString();
        }
    }
}
