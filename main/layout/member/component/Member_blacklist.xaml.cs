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
using LibraryManagement.controller;

namespace LibraryManagement.layout.member.component
{
    /// <summary>
    /// Interaction logic for Member_blacklist.xaml
    /// </summary>
    public partial class Member_blacklist : UserControl
    {
        public Member_blacklist()
        {
            InitializeComponent();
            var memberViewModel = MemberViewModel.getInstance();
            memberListv.DataContext = memberViewModel;
        }
    }
}
