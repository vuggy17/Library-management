using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.viewmodel.features
{
    class UserScanerBoardViewModel: BaseViewModel
    {
        string searchKeyword = "";       
        public UserScanerBoardViewModel()
        {

        }
        public string SearchKeyword
        {
            get => searchKeyword;
            set
            {
                searchKeyword = value;
                OnPropertyChanged("ListMusic");
                OnPropertyChanged("SearchKeyword");
            }
        }
    }
}
