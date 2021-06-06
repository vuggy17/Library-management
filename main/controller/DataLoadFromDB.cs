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
        private static DataLoadFromDB dataLoadFromDB;
        private DataLoadFromDB() {
            members = new List<Account>();
            bookItems = new List<BookItem>();
            books = new List<Book>();
            loadMembersFromDB();
            loadBookItemsFromDB();
            loadBookFromDB();
        }
        private List<Account> members;
        private List<BookItem> bookItems; // reference to book by in for
        private List<Book> books;

        public static List<Book> getBooks()
        {
            if (dataLoadFromDB == null)
            {
                dataLoadFromDB = new DataLoadFromDB();
            }
            return dataLoadFromDB.books;
        }
        public static List<BookItem> getBookItems()
        {
            if(dataLoadFromDB == null)
            {
                dataLoadFromDB = new DataLoadFromDB();
            }
            return dataLoadFromDB.bookItems;
        }

        public static List<Account> getAllMembers()
        {
            if(dataLoadFromDB == null)
            {
                dataLoadFromDB = new DataLoadFromDB();
            }
            return dataLoadFromDB.members;
        }
        private void loadBookFromDB()
        {
            books.Add(new Book(12345670, "Rừng NaUy", "Novel", "Haruki Murakami",new DateTime(2021,6,2)));
            books.Add(new Book(76543210, "Clean code", "Education","Robert C. Martin", new DateTime(2021, 6, 3)));
            books.Add(new Book(00000001,"Sach chi tham khao","Tào lao","Pham Minh Tan", new DateTime(2021, 6, 3)));
        }
        private void loadBookItemsFromDB()
        {
            //fake load to test
            bookItems.Add(new BookItem(12345671, false, 12345670,LendingStatus.AVAI,new DateTime(2021,6,2)));
            bookItems.Add(new BookItem(12345672, false, 12345670,LendingStatus.LOANED, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(12345673, false, 12345670,LendingStatus.LOANED, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(76543211, false, 76543210,LendingStatus.RESV, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(76543212, false, 76543210,LendingStatus.AVAI, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(76543213, false, 76543210,LendingStatus.LOANED, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(76543214, false, 76543210,LendingStatus.LOANED, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(10000001, true, 00000001, LendingStatus.AVAI, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(20000001, true, 00000001, LendingStatus.AVAI, new DateTime(2021, 6, 2)));
            bookItems.Add(new BookItem(30000001, true, 00000001, LendingStatus.AVAI, new DateTime(2021, 6, 2)));
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
