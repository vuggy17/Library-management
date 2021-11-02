using LibraryManagement.controller;
using LibraryManagement.layout.HomeAndFeature.form;
using LibraryManagement.model;
using LibraryManagement.model.features;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryManagement.viewmodel.features
{
    class ResearveBookViewModel: BaseViewModel
    {
        private ObservableCollection<BookToReserve> reserveList;

        public ObservableCollection<BookToReserve> ReserveList
        {
            get => reserveList;
            set => reserveList = value;
        }
        public ICommand SelectBook { get; set; }

        public ICommand Add { get; set; }
        public ICommand Remove { get; set; }
        public ICommand Delete { get; set; }
        public BookToReserve selectedItem { get; set; }

        public ICommand Confirm { get; set; }
        CurrentMember current = CurrentMember.getInstance();
        public ResearveBookViewModel()
        {
            reserveList = new ObservableCollection<BookToReserve>();
            SelectBook = new RelayCommand<object>((p) => { return true; }, (p) => { openFormToSelect(); });
            Add = new RelayCommand<object>((p) => { return true; }, (p) => { increaseCount(); });
            Remove = new RelayCommand<object>((p) => { return true; }, (p) => { decreaseCount(); });
            Confirm = new RelayCommand<object>((p) => { return true; }, (p) => { ConfirmResearveList(); });
            Delete = new RelayCommand<object>((p) => { return true; }, (p) => { removeSeletedItem(); });
            ResearveBookFormViewModel.addItemToReserve += ResearveBookFormViewModel_addItemToReserve;
            ReserveConfirm.ClearInfo += ReserveConfirm_ClearInfo;
        }

        private void ReserveConfirm_ClearInfo()
        {
            reserveList.Clear();
        }

        private void removeSeletedItem()
        {
            reserveList.Remove(selectedItem);
        }

        private void ResearveBookFormViewModel_addItemToReserve(BookToReserve bookToResearve)
        {
            reserveList.Add(bookToResearve);
        }

        private void openFormToSelect()
        {
            ReseverBookForm reseverBookForm = new ReseverBookForm(reserveList);
            reseverBookForm.Show();
        }

        private void ConfirmResearveList()
        {
            if (current.GetAccount() == null || reserveList.Count == 0)
            {
                MessageBox.Show("Member and list book can't not place empty", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            ReserveConfirm reserveConfirm = new ReserveConfirm(current.GetAccount(), reserveList);
            reserveConfirm.Show();
        }

        private void increaseCount()
        {
            if (selectedItem.Count < 5 && selectedItem.Count < selectedItem.AvalableCopies)
            {
                selectedItem.Count++;
            }

        }
        private void decreaseCount()
        {
            if (selectedItem.Count > 1)
            {
                selectedItem.Count--;
            }
        }

    }
}
