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
            this.DataContext = new MemberViewModel();
            List<Converter> memberList = new List<Converter>()
            {
                new Converter("duy", "khanh hoa", "duy mail", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
        };
            memberListv.ItemsSource = memberList;


        }

      
    }
}
