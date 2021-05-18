using main.model;
using main.model.enums;
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

namespace main.layout.member
{
    /// <summary>
    /// Interaction logic for member_card.xaml
    /// </summary>
    public partial class member_card : UserControl
    {
        public member_card()
        {
            InitializeComponent();

            Account member = new Account("duy", "khanh hoa", "duy mail", "08969256174", 12, "this is paswd", AccountStatus.ACTIVE, new DateTime(1200), 5);
            List<Converter> memberList = new List<Converter>() {

            new Converter("duy", "khanh hoa", "duy mail", "08969256174",  AccountStatus.ACTIVE, 5,"../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174",  AccountStatus.ACTIVE, 5,"../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174",  AccountStatus.ACTIVE, 5,"../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174",  AccountStatus.ACTIVE, 5,"../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174",  AccountStatus.ACTIVE, 5,"../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174",  AccountStatus.ACTIVE, 5,"../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174",  AccountStatus.ACTIVE, 5,"../resource/img/avt_default.png"),
            };
        }

    }
}

