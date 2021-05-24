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

namespace main.layout.member.component
{
    /// <summary>
    /// Interaction logic for Member_info.xaml
    /// </summary>
    public partial class Member_info : UserControl
    {
        public Member_info()
        {
            InitializeComponent();
            bool isBlacklisted = MemberInfo_checkbox.IsChecked.Value; // or isBlacklisted from db
            MemberInfo_checkbox.IsEnabled = isBlacklisted;
        }
    }
}
