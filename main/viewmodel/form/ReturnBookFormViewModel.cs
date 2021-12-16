using LibraryManagement.controller;
using LibraryManagement.model;
using LibraryManagement.model.Test;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManagement.viewmodel.form
{

    public class ReturnBookFormViewModel : BaseViewModel
    {
        public String Id { get; set; }
        public ObservableCollection<BookToShow> ConfirmBooks { get; set; }

        public double TotalFee { get => caculateTotalOverDuefee(); }

        public static event updateBookListHandeler returnUpdateBook;

        public static event updateMemberListHandeler returnUpdateMember;

        DataLoadFromDB dataLoadFromDB;

        public ReturnBookFormViewModel(string Id, ObservableCollection<BookToShow> confirmBooks)
        {
            this.Id = "Member ID: " + Id;
            this.ConfirmBooks = confirmBooks;
            dataLoadFromDB = DataLoadFromDB.getIntance();
        }
        public ReturnBookFormViewModel()
        {

        }

        private double caculateTotalOverDuefee()
        {
            double result=0.0;
            foreach (var book in this.ConfirmBooks)
            {
                result += book.OverDueFee;
            }
            return result;
        }
        public ReturnBookResult removeBookToLendingListTest(ObservableCollection<BookToShow> checkOutBookList)
        {
            ReturnBookResult returnBook = new ReturnBookResult("", false, "Return book fail nothing selected");
            foreach (var book in checkOutBookList)
            {
                returnBook.logMessage = "";
                BookItem bookItem = book.bookItemTest();
                returnBook.returnResult = true;                
                if (bookItem.lendingStatus != model.enums.LendingStatus.RESV)
                {
                    bookItem.lendingStatus = model.enums.LendingStatus.AVAI;
                    returnBook.newBookItemStatus = "Available";
                }
                else
                {
                    bookItem.lendingStatus = model.enums.LendingStatus.READY;
                    returnBook.newBookItemStatus = "Ready";
                }
                if(book._dueDate < DateTime.Now)
                {
                    returnBook.logMessage = "Remind fee";
                }              
                returnBook.returnResult = true;
            }
            return returnBook;
        }

        public void removeBookToLendingList(Account account, ObservableCollection<BookToShow> CheckOutBookList)
        {
            foreach (var book in CheckOutBookList)
            {
                BookItem bookItem = book.toBookItem();
                account.removeBookToLendingBookList(bookItem);
                if (bookItem.lendingStatus != model.enums.LendingStatus.RESV)
                {
                    bookItem.lendingStatus = model.enums.LendingStatus.AVAI;                    
                }
                else
                {
                    bookItem.lendingStatus = model.enums.LendingStatus.READY;
                }
                bookItem.bordate = null;
                bookItem.dueDate = null;
                if (dataLoadFromDB.updateBookItem(bookItem) != null)
                {
                    returnUpdateBook();
                    returnUpdateMember();
                }
                else
                {
                    MessageBox.Show("Unknow error");
                }
            }
        }
        
    }
}
