﻿using main.viewmodel.features;
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
    /// Interaction logic for UserScanerBoard.xaml
    /// </summary>
    public partial class UserScanerBoard : UserControl
    {
        public UserScanerBoard()
        {
            InitializeComponent();
            this.DataContext = new UserScanerBoardViewModel();
        }

        private void btnFullInfor_Click(object sender, RoutedEventArgs e)
        {
            //ReturnFullInfor returnFullInfor = new ReturnFullInfor();
            //returnFullInfor.Show();
        }
    }
}
