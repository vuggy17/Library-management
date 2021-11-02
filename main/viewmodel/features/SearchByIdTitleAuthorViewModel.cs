using LibraryManagement.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagement.viewmodel.features
{
    class SearchByIdTitleAuthorViewModel: BaseViewModel
    {
        private String search;

        public String Search { 
            get { return search; }
            set { search = value; Searching(); } 
        }

        public static event SearchByIdTitleAuthorHandler Searching;
    }
}
