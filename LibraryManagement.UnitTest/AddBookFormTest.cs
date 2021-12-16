using LibraryManagement.model;
using LibraryManagement.model.Test;
using LibraryManagement.viewmodel.Books;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.UnitTest
{
    class AddBookFormTest
    {
        [TestCase("32000", "Chiếc lượt ngà", "Nguyễn Quang Sáng", 13, 12, 2000, "image", 5, true, true, true, "")]
        [TestCase("32000", "", "Nguyễn Quang Sáng", 13, 12, 2000, "image", 5, false, false, false, "Some field is empty")]
        [TestCase("32000", "Chiếc lượt ngà", "", 13, 12, 2000, "image", 5, false, false, false, "Some field is empty")]
        [TestCase("", "Chiếc lượt ngà", "Nguyễn Quang Sáng", 13, 12, 2000, "image", 5, false, false, false, "Some field is empty")]
        [TestCase("32000", "Chiếc lượt ngà", "Nguyễn Quang Sáng", 0, 0, 0, "image", 5, false, false, false, "Some field is empty")]
        [TestCase("abc", "Chiếc lượt ngà", "Nguyễn Quang Sáng", 13, 12, 2000, "image", 5, false, false, false, "Price must be a number between 1.000đ - 1.000.000.000đ")]
        [TestCase("-1000", "Chiếc lượt ngà", "Nguyễn Quang Sáng", 13, 12, 2000, "image", 5, false, false, false, "Price must be a number between 1.000đ - 1.000.000.000đ")]
        [TestCase("9999999999", "Chiếc lượt ngà", "Nguyễn Quang Sáng", 13, 12, 2000, "image", 5, false, false, false, "Price must be a number between 1.000đ - 1.000.000.000đ")]
        [TestCase("32000", "Chiếc lượt ngà", "Nguyễn Quang Sáng", 13, 12, 2031, "image", 5, false, false, false, "Pulishing date is in future!!")]
        [TestCase("32000", "Chiếc lượt ngà", "Nguyễn Quang Sáng", 13, 12, 2000, "", 5, true, true, true, "")]
        [TestCase("32000", "Chiếc lượt ngà", "Nguyễn Quang Sáng", 13, 12, 2000, "image", 0, true, true, false, "")]
        public void addBookTest(string price, string name, string author, int day, int month, int year, string imageName, int numOfCopies, bool returnResult, bool isAddBookInDatabase, bool isAddBookItemInDatabase, string logMessage)
        {
            AddNewBookResult expected = new AddNewBookResult(returnResult, isAddBookInDatabase, isAddBookItemInDatabase, logMessage);
            AddNewBookViewModel addNewBookViewModel = new AddNewBookViewModel("test");
            DateTime? date;
            if(year !=0 && month !=0 && day !=0)
            {
                date = new DateTime(year, month, day);
            } else
            {
                date = null;
            }
            AddNewBookResult result = addNewBookViewModel.onButtonSaveClickTest(price, name, author,date , imageName, numOfCopies);
            bool testExpected = false;
            if(expected.compare(result))
            {
                testExpected = true;
            }
            Assert.AreEqual(true, testExpected);
        }
       
    }
}
