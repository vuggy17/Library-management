using LibraryManagement.model;
using LibraryManagement.model.Test;
using LibraryManagement.viewmodel.form;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.UnitTest
{
    class ReturnBookTest
    {
        [TestCase("Loaned", "1001", false, "Available", true, "")]
        [TestCase("Reserved", "1001", false, "Ready", true, "")]
        [TestCase("Loaned", "1001", true, "Available", true, "Remind fee")]
        [TestCase("Loaned", "", true, "Available", false, "Return book fail nothing selected")]
        public void returnBookTest(string bookItemStatus, string bookItemId, bool isOverDue, string newStatus, bool returnResule, string logMessage)
        {
            ReturnBookResult expected = new ReturnBookResult(newStatus, returnResule, logMessage);
            DateTime date = new DateTime(2031, 7, 13);
            if(isOverDue == true)
            {
                date = new DateTime(2001, 7, 13);
            }
            ObservableCollection<BookToShow> bookToShows = new ObservableCollection<BookToShow>();
            if (bookItemId != "")
            {
                BookToShow book = new BookToShow(bookItemId, date, bookItemStatus);
                bookToShows.Add(book);
            }           
            ReturnBookFormViewModel returnBook = new ReturnBookFormViewModel();
            ReturnBookResult result = returnBook.removeBookToLendingListTest(bookToShows);
            bool testExpected = false;
            if (expected.compare(result))
            {
                testExpected = true;
            }
            if(expected.returnResult == result.returnResult)
            {
                testExpected = true;
            }
            Assert.AreEqual(true, testExpected);

        }
    }
}
