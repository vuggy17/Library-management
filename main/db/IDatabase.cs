using LibraryManagement.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.db
{
    public interface IDatabase
    {
        bool updateInfo(Person info);
        bool updatePassword(string staffId, string newPassword);
        bool insertImageData(Person person);
        List<Staff> getAllStaffs();
        bool dropBook(int bookId);
        List<BookItem> getAllBookItems();
        List<Book> getAllBooks();
        bool updateBook(Book book);
        bool inseartBookImage(Book book);
    }
}
