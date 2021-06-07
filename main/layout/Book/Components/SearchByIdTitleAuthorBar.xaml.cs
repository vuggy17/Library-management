using main.controller;
using main.viewmodel.features;
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

namespace main.layout.Book.Components
{
    /// <summary>
    /// Interaction logic for SearchByIdTitleAuthorBar.xaml
    /// </summary>
    public partial class SearchByIdTitleAuthorBar : UserControl
    {
        public static List<main.model.Book> lstBookOnSearch = new List<model.Book>();
        public SearchByIdTitleAuthorBar()
        {
            InitializeComponent();
            this.DataContext = new SearchByIdTitleAuthorViewModel();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBar.Text != null)
            {
                lstBookOnSearch = null;
                lstBookOnSearch = new List<model.Book>();
                String currentSearch = SearchBar.Text;
                List<main.model.Book> listAllBook = ListAllBook.getInstance();
                for (int i = 0; i < listAllBook.Count; i++)
                {
                    if (listAllBook[i].author.Contains(currentSearch) || listAllBook[i].title.Contains(currentSearch) || listAllBook[i].id.ToString().Contains(currentSearch))
                    {
                        lstBookOnSearch.Add(listAllBook[i]);
                    }
                }
            }
            else
            {
                lstBookOnSearch = null;
                lstBookOnSearch = new List<main.model.Book>();
                lstBookOnSearch = ListAllBook.getInstance();
            }    
        }
    }
}
