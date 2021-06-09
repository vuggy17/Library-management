using main.layout.HomeAndFeature.components;
using main.layout.HomeAndFeature.form;
using main.model.features;
using main.viewmodel;
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

namespace main.layout.HomeAndFeature
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    /// 
    public partial class HomePage : UserControl
    {
        FeatureNavigationViewModel featureNavigation;
        public HomePage()
        {
            InitializeComponent();
            featureNavigation = new FeatureNavigationViewModel();
            FeatureNavigationViewModel.ChangePage += FeatureNavigation_ChangePage;            

        }

        private void FeatureNavigation_ChangePage(string page)
        {
            switch (page)
            {
                case "ReturnBook":
                    ReserveBookList.Visibility = Visibility.Hidden;
                    ReturnBookList.Visibility = Visibility.Visible;
                    RenewBookList.Visibility = Visibility.Hidden;
                    CheckOutBookList.Visibility = Visibility.Hidden;
                    break;
                case "ReserveBook":
                    ReserveBookList.Visibility = Visibility.Visible;
                    ReturnBookList.Visibility = Visibility.Hidden;
                    RenewBookList.Visibility = Visibility.Hidden;
                    CheckOutBookList.Visibility = Visibility.Hidden;
                    break;
                case "CheckOutBook":
                    ReserveBookList.Visibility = Visibility.Hidden;
                    ReturnBookList.Visibility = Visibility.Hidden;
                    RenewBookList.Visibility = Visibility.Hidden;
                    CheckOutBookList.Visibility = Visibility.Visible;
                    break;
                case "RenewBook":
                    ReserveBookList.Visibility = Visibility.Hidden;
                    ReturnBookList.Visibility = Visibility.Hidden;
                    RenewBookList.Visibility = Visibility.Visible;
                    CheckOutBookList.Visibility = Visibility.Hidden;
                    break;
            }
        }
    }
}
