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

namespace main.layout.HomeAndFeature.components
{
    /// <summary>
    /// Interaction logic for ReseviceBook.xaml
    /// </summary>
    public partial class ReseviceBook : UserControl
    {
        public List<String> tempList = new List<string>();
        public ReseviceBook()
        {
            InitializeComponent();
            tempList.Add("");
            tempList.Add("");
            tempList.Add("");
            tempList.Add("");
            tempList.Add("");
            testLv.ItemsSource = tempList;
        }
    }
}
