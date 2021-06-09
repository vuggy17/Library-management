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
        public void updateMember(Account value)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].id == value.id)
                {
                    members[i] = value;
                }
            }
            //xử lý db
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
            //fake load to test
            books.Add(new Book(12345670, "Rừng NaUy", "Novel", "Haruki Murakami",new DateTime(2021,6,2),20000));
            books.Add(new Book(76543210, "Clean code", "Education","Robert C. Martin", new DateTime(2021, 6, 3), 25000));
            books.Add(new Book(00000001,"Sach chi tham khao","Tào lao","Pham Minh Tan", new DateTime(2021, 6, 3), 500000));
            books.Add(new Book(76543218, "Clean code 2018", "Education", "Robert C. Martin", new DateTime(2018, 6, 3),28000));
            books.Add(new Book(76543219, "Clean code 2019", "Education", "Robert C. Martin", new DateTime(2029, 6, 3),29000));
            books.Add(new Book(76543220, "Clean code 2020", "Education", "Robert C. Martin", new DateTime(2020, 6, 3),22000));
        }
        private void loadBookItemsFromDB()
        {
            //fake load to test
            bookItems.Add(new BookItem(12345671, 12345670,LendingStatus.AVAI,new DateTime(2021,6,2)));
            bookItems.Add(new BookItem(12345672, 12345670,LendingStatus.LOANED, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(12345673, 12345670,LendingStatus.LOANED, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(76543211, 76543210,LendingStatus.RESV, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(76543212, 76543210,LendingStatus.AVAI, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(76543213, 76543210,LendingStatus.LOANED, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(76543214, 76543210,LendingStatus.AVAI, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(10000001, 00000001, LendingStatus.AVAI, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(20000001, 00000001, LendingStatus.AVAI, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(30000001, 00000001, LendingStatus.AVAI, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(10000001, 76543218, LendingStatus.AVAI, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(20000001, 76543219, LendingStatus.AVAI, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(30000001, 76543220, LendingStatus.AVAI, new DateTime(2021, 6, 2)));
        }
        
        private void loadMembersFromDB()
        {
            //fake load to test
            members.Add(new Account("Pham Minh Tân","Long An","pmt@gmail.com","0343027600", 1307,"123456789", AccountStatus.ACTIVE, new DateTime(2019,12,31),0));
            members.Add(new Account("Pham Minh Tân1", "Long An", "pmt1@gmail.com", "0343027601",1412 , "123456789", AccountStatus.ACTIVE, new DateTime(2019, 12, 31), 1));
            members.Add(new Account("Pham Minh Tân2", "Long An", "pmt2@gmail.com", "0343027602", 1111, "123456789", AccountStatus.ACTIVE, new DateTime(2019, 12, 31), 2));
            members.Add(new Account("Pham Minh Tân3", "Long An", "pmt3@gmail.com", "0343027603", 8266, "123456789", AccountStatus.ACTIVE, new DateTime(2019, 12, 31), 3));
            members.Add(new Account("Pham Minh Tân4", "Long An", "pmt4@gmail.com", "0343027604", 1530, "123456789", AccountStatus.ACTIVE, new DateTime(2019, 12, 31), 4));
        }


    }
}
