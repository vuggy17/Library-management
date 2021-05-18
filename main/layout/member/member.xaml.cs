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

namespace main.layout
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Member : UserControl
    {
        public Member()
        {
            InitializeComponent();
            Account member = new Account("duy", "khanh hoa", "duy mail", "08969256174",12, "this is paswd",AccountStatus.ACTIVE,new DateTime(1200),5);
            List<Converter> memberList = new List<Converter>()
            {
            new Converter("duy", "khanh hoa", "duy mail", "08969256174",  AccountStatus.ACTIVE, 5,"../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174",  AccountStatus.ACTIVE, 5,"../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174",  AccountStatus.ACTIVE, 5,"../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174",  AccountStatus.ACTIVE, 5,"../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174",  AccountStatus.ACTIVE, 5,"../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174",  AccountStatus.ACTIVE, 5,"../resource/img/avt_default.png"),
            new Converter("duy", "khanh hoa", "duy mail", "08969256174",  AccountStatus.ACTIVE, 5,"../resource/img/avt_default.png"),
        };
            memberListv.ItemsSource = memberList;

        }
    }
    public class Converter
    {
        #region properties
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _address;

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _email;

        public string email
        {
            get { return _email; }
            set
            {
                //if (validateEmail(value))
                    _email = value;
                //else thow err
            }
        }
        private string _phone;

        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        private int _bookNumber;

        public int bookNumber
        {
            get { return _bookNumber; }
            set { _bookNumber = value; }
        }
        private int _overDue;

        public int overDue
        {
            get { return _overDue; }
            set { _overDue = value; }
        }
        private AccountStatus _status;

        public AccountStatus status
        {
            get { return _status; }
            set { _status = value; }
        }
        private BitmapImage _imgSrc;

        public BitmapImage imgSrc
        {
            get { return _imgSrc; }
            set { _imgSrc = value; }
        }



        #endregion


        public Converter(string name, string addr, string mail, string phone, AccountStatus status, int totB, string imgSrc)
        {
            this.name = name;
            this.address = addr;
            this.email = mail;
            this.phone = phone;
            this.status = status;
            this.bookNumber = totB;
            this.overDue = 0;
            this.imgSrc = LoadImage(imgSrc);
        }
         private BitmapImage LoadImage(string filename)
        {
            return new BitmapImage(new Uri("pack://application:,,,/" + filename));
        }
    }
}
