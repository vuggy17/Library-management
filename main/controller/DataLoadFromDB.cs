using main.layout;
using main.model;
using main.model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.controller
{
    class DataLoadFromDB
    {
        Db db = Db.getInstace();
        private static DataLoadFromDB intance;
        private DataLoadFromDB() {
            members = new List<Account>();
            bookItems = new List<BookItem>();
            books = new List<Book>();
        }
        private List<Account> members;
        private List<BookItem> bookItems; // reference to book by infor
        private List<Book> books;
        public static DataLoadFromDB getIntance()
        {
            if(intance == null)
            {
                intance = new DataLoadFromDB();
                intance.loadBookFromDB();
                intance.loadMembersFromDB();
                intance.loadBookItemsFromDB();
            }
            return intance;
        }
        public void addNewBookItem(BookItem bookItem)
        {
            bookItems.Add(bookItem);
            //xử lý db
        }
        public void addNewBook(Book book)
        {
            books.Add(book);
            //xử lý db
        }
        public void addNewMember(Account member)
        {
            members.Add(member);
            //xử lý db
        }
        public void deleteBook(Book book)
        {
            books.Remove(book);
            foreach (var bookItem in book.getAllBookItems())
            {
                deleteBookItems(bookItem);
            }
            //xử lý db
        }
        public void deleteBookItems(BookItem bookItem)
        {
            bookItems.Remove(bookItem);
            //xử lý db
        }
        public void deleteMember(Account member)
        {
            members.Remove(member);
            //xử lý db
        }
        public void updateBook(Book value)
        {
            for( int i=0; i< books.Count; i++)
            {
                if(books[i].id == value.id)
                {
                    books[i] = value;
                   
                }
            }
            //xử lý db
        }
        public Account findMemberByID(int id)
        {
            foreach (var member in members)
            {
                if(member.id == id)
                {
                    return member;
                }
            }
            return null;

        }
        public Account updateMember(Account value)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].id == value.id)
                {
                    members[i] = value;
                    return members[i];
                }
            }
            return null;
            //xử lý db
        }
        public BookItem updateBookItem(BookItem value)
        {
            for (int i = 0; i < bookItems.Count; i++)
            {
                if (bookItems[i].id == value.id)
                {
                    bookItems[i] = value;
                    return bookItems[i];
                }
            }
            return null;
        }

        public List<Book> getBooks()
        {
            return books;
        }
        public List<BookItem> getBookItems()
        {
            return bookItems;
        }

        public List<Account> getAllMembers()
        {
            return members;
        }

        private void loadBookFromDB()
        {
            books = db.getAllBooks();
        }
        private void loadBookItemsFromDB()
        {
            bookItems = db.getAllBookItems();
        }
        
        private void loadMembersFromDB()
        {
            members = db.getAllAccount();
        }


    }
}
