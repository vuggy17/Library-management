using LibraryManagement.model;
using LibraryManagement.viewmodel.Books;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.UnitTest
{
    [TestFixture]
    class BookPageViewModelTest
    {
        [TestCase(32)]
        public void deleteBookItem_AllBookReturned_notThrowException(int bookId)
        {
            var bookItems = new List<BookItem>();
            bookItems.Add(new BookItem(bookId, model.enums.LendingStatus.AVAI, 12));
            bookItems.Add(new BookItem(bookId, model.enums.LendingStatus.AVAI, 12));
            bookItems.Add(new BookItem(bookId , model.enums.LendingStatus.AVAI, 12));
            bookItems.Add(new BookItem(bookId , model.enums.LendingStatus.AVAI, 12));
            bookItems.Add(new BookItem(bookId , model.enums.LendingStatus.AVAI, 12));

            var books = new List<Book>();
            books.Add(new Book("Hai dua tre", "Thach Lam", new DateTime(), 1234, 2).buildWithID(bookId));
            books.Add(new Book("Hai dua tre 1", "Thach Lam", new DateTime(), 1234, 2).buildWithID(342));
            books.Add(new Book("Hai dua tre 2", "Thach Lam", new DateTime(), 1234, 2).buildWithID(565));
            books.Add(new Book("Hai dua tre 3", "Thach Lam", new DateTime(), 1234, 2).buildWithID(3214));
            books.Add(new Book("Hai dua tre 4", "Thach Lam", new DateTime(), 1234, 2).buildWithID(33241));
            books.Add(new Book("Hai dua tre 5", "Thach Lam", new DateTime(), 1234, 2).buildWithID(845));

            var mock = new MockDbService().MockGetAllBookItems(bookItems).MockGetAllBook(books);
            BookPageViewModel viewmodel = new BookPageViewModel(mock.Object);
            
            //Assert.DoesNotThrow(() => viewmodel.deleteBookItem1(bookId));
        }

        [TestCase(32, "Delete book only available when all of it's item had return")]
        public void deleteBookItem_SomeBookNotReturned_throwException(int bookId, string expectedErrorMessage)
        {
            var bookItems = new List<BookItem>();
            bookItems.Add(new BookItem(12, model.enums.LendingStatus.AVAI, bookId));
            bookItems.Add(new BookItem(32, model.enums.LendingStatus.LOANED, bookId));
            bookItems.Add(new BookItem(43, model.enums.LendingStatus.READY, bookId));
            bookItems.Add(new BookItem(54, model.enums.LendingStatus.AVAI, bookId));
            bookItems.Add(new BookItem(76, model.enums.LendingStatus.LOANED, bookId));
            bookItems.Add(new BookItem(87, model.enums.LendingStatus.READY, bookId));

            var books = new List<Book>();
            books.Add(new Book("Hai dua tre", "Thach Lam", new DateTime(), 1234, 2).buildWithID(bookId));
            books.Add(new Book("Hai dua tre 1", "Thach Lam", new DateTime(), 1234, 2).buildWithID(342));
            books.Add(new Book("Hai dua tre 2", "Thach Lam", new DateTime(), 1234, 2).buildWithID(565));
            books.Add(new Book("Hai dua tre 3", "Thach Lam", new DateTime(), 1234, 2).buildWithID(3214));
            books.Add(new Book("Hai dua tre 4", "Thach Lam", new DateTime(), 1234, 2).buildWithID(33241));
            books.Add(new Book("Hai dua tre 5", "Thach Lam", new DateTime(), 1234, 2).buildWithID(845));

            var mock = new MockDbService().MockGetAllBookItems(bookItems).MockGetAllBook(books);
            BookPageViewModel viewmodel = new BookPageViewModel(mock.Object);

            var ex = Assert.Throws<System.Exception>(() => viewmodel.deleteBookItem1(bookId));
            Assert.That(ex.Message, Is.EqualTo(expectedErrorMessage));

        }

    }
}
