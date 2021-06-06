﻿using main.model;
using main.model.features;
using main.viewmodel.form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace main.layout.HomeAndFeature.form
{
    /// <summary>
    /// Interaction logic for RenewForm.xaml
    /// </summary>
    public partial class RenewForm : Window
    {
        public static event ToggleFormDialogNotifyHandler ToggleForm;
        public RenewForm(Account account, ObservableCollection<BookToShow> bookToShows)
        {
            InitializeComponent();
            ToggleForm();
            DataContext = new RenewBookFormViewModel(account.id.ToString(),bookToShows);
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            ToggleForm();

        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
