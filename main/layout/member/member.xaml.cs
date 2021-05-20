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
using main.controller;
using System.Diagnostics;
using main.layout.member.component;
using MaterialDesignThemes.Wpf;

namespace main.layout
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Member : UserControl
    {
        public static  Member instance;
        // lock object for multi thread-safe
        private static object syncLock = new object();
        public static  Member getInstance()
        {
            if (instance == null)
                lock (syncLock)
                    if(instance  == null)
                        instance = new Member();
            return instance;
        }
        public Member()
        {
            InitializeComponent();
            this.DataContext = new MemberViewModel();
          
        }
       

       
    }

}
