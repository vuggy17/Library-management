﻿using System;
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
using main.controller;
using MaterialDesignThemes.Wpf;
using System.Diagnostics;

namespace main.layout.member.component
{
    /// <summary>
    /// Interaction logic for member_list.xaml
    /// </summary>
    public partial class Member_list : UserControl
    {
        public Member_list()
        {
            InitializeComponent();
            var memberViewModel = new MemberViewModel();
            memberListv.DataContext = memberViewModel;
         ;

        }
        /*System.Windows.Data Error: 40 : BindingExpression path error: 'RunBlockNotificationCommand' property not found on 'object' ''Converter' (HashCode=65737292)'. 
         * BindingExpression:Path=RunBlockNotificationCommand; 
         * DataItem='Converter' (HashCode=65737292) ; 
         * target element is 'Button' (Name=''); 
         * target property is 'Command' (type 'ICommand')
        */
    }
}
