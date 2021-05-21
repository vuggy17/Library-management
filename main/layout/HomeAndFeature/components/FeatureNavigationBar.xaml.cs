using main.viewmodel.features;
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

namespace main.layout.HomeAndFeature.components
{
    /// <summary>
    /// Interaction logic for FeatureNavigationBar.xaml
    /// </summary>
    public partial class FeatureNavigationBar : UserControl
    {
        FeatureNavigationViewModel featureNavigation;
        public FeatureNavigationBar()
        {
            InitializeComponent();
            featureNavigation = new FeatureNavigationViewModel();
            DataContext = featureNavigation;
            FeatureNavigationViewModel.ChangePage += FeatureNavigationViewModel_ChangePage;
        }

        private void FeatureNavigationViewModel_ChangePage(string page)
        {
            switch (page)
            {
                case "ReturnBook":
                    ReturnBook.Opacity = 1;
                    RenewBook.Opacity = 0.5;
                    ReserveBook.Opacity = 0.5;
                    CheckOutBook.Opacity = 0.5;
                    break;
                case "RenewBook":
                    RenewBook.Opacity = 1;
                    ReturnBook.Opacity = 0.5;
                    ReserveBook.Opacity = 0.5;
                    CheckOutBook.Opacity = 0.5;
                    break;
                case "ReserveBook":
                    ReserveBook.Opacity = 1;
                    ReturnBook.Opacity = 0.5;
                    RenewBook.Opacity = 0.5;
                    CheckOutBook.Opacity = 0.5;
                    break;
                case "CheckOutBook":
                    CheckOutBook.Opacity = 1;
                    ReturnBook.Opacity = 0.5;
                    RenewBook.Opacity = 0.5;
                    ReserveBook.Opacity = 0.5;
                    break;
            }
        }
    }
}
