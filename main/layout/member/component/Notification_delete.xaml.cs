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
using main.controller;

namespace main.layout.member.component
{
    /// <summary>
    /// Interaction logic for Notification_delete.xaml
    /// </summary>
    public partial class Notification_delete : UserControl
    {
        private MemberViewModel memberInstance;
        public Notification_delete()
        {
            InitializeComponent();
             memberInstance = MemberViewModel.getInstance();
            this.DataContext = memberInstance;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            memberInstance.deleteMember();
        }
    }
}
