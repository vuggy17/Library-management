using LibraryManagement.model;
using LibraryManagement.viewmodel.features;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.UnitTest
{
    [TestFixture]

    class EditBookViewModelTest
    {
        [TestCase("", "Nguyễn Quang Sáng", 32000, false)]
        [TestCase("Chiếc lược ngà", "", 32000, false)]
        [TestCase("Chiếc lược ngà", "Nguyễn Quang Sáng", 32000, true)]
        [TestCase("Chiếc lược ngà", "Nguyễn Quang Sáng", -10000, false)]
        [TestCase("Chiếc lược ngà", "Nguyễn Quang Sáng", 9999999999, true)]
        public void updateBookTest(string name, string author, int price, bool expected)
        {
            const int BOOKID = 12;
            var books = new List<Book>();
            books.Add(new Book("Hai dua tre", "Thach Lam", new DateTime(), 1234, 2).buildWithID(BOOKID));
            books.Add(new Book("Hai dua tre 1", "Thach Lam", new DateTime(), 1234, 2).buildWithID(342));
            books.Add(new Book("Hai dua tre 2", "Thach Lam", new DateTime(), 1234, 2).buildWithID(565));
            books.Add(new Book("Hai dua tre 3", "Thach Lam", new DateTime(), 1234, 2).buildWithID(3214));
            books.Add(new Book("Hai dua tre 4", "Thach Lam", new DateTime(), 1234, 2).buildWithID(33241));
            books.Add(new Book("Hai dua tre 5", "Thach Lam", new DateTime(), 1234, 2).buildWithID(845));

            var updateValue = new Book(name, author, new DateTime(), price, 99).buildWithID(BOOKID);

            var mock = new MockDbService().MockUpdateBook(updateValue).MockInsertBookImage(updateValue).MockGetAllBook(books);
            EditBookViewModel viewmodel = new EditBookViewModel(mock.Object);

            var result = viewmodel.updateBook1(updateValue);
            Console.WriteLine(expected);
            Console.WriteLine(result);
            Assert.AreEqual(expected, result);
        }
    }
}
