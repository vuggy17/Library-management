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
using MaterialDesignThemes.Wpf;
using System.Diagnostics;

namespace LibraryManagement.layout.member.component
{
    /// <summary>
    /// Interaction logic for member_list.xaml
    /// </summary>
    public partial class Member_list : UserControl
    {
        public Member_list()
        {
            InitializeComponent();
            DataContext = MemberViewModel.getInstance();          
        }
      
    }
}
