using LibraryManagement.controller;
using LibraryManagement.viewmodel.Members;
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

namespace LibraryManagement.layout.member.component
{
    /// <summary>
    /// Interaction logic for MemberNavigationBar.xaml
    /// </summary>
    public partial class MemberNavigationBar : UserControl
    {
        public MemberNavigationBar()
        {
            InitializeComponent();
            DataContext = new MemberNavigationViewModel();
            MemberNavigationViewModel.ChangePage += MemberNavigationViewModel_ChangePage;
        }

        private void MemberNavigationViewModel_ChangePage(string page)
        {
            switch (page)
            {
                case "ActiveList":
                    ActiveList.Opacity = 1;
                    BlackList.Opacity = 0.5;
                    break;
                case "BlackList":
                    ActiveList.Opacity = 0.5;
                    BlackList.Opacity = 1;
                    break;
            }
        }
    }
}
