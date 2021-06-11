﻿using main.layout;
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
            bookItems.Add(new BookItem(12345671, 12345670,LendingStatus.AVAI,null));
            bookItems.Add(new BookItem(12345672, 12345670,LendingStatus.AVAI, null));
            bookItems.Add(new BookItem(12345673, 12345670,LendingStatus.AVAI, null));
            bookItems.Add(new BookItem(76543211, 76543210,LendingStatus.AVAI, null));
            bookItems.Add(new BookItem(76543212, 76543210,LendingStatus.AVAI, null));
            bookItems.Add(new BookItem(76543213, 76543210,LendingStatus.AVAI, null));
            bookItems.Add(new BookItem(76543214, 76543210,LendingStatus.AVAI, null));
            bookItems.Add(new BookItem(10000001, 00000001, LendingStatus.AVAI,null));
            bookItems.Add(new BookItem(20000001, 00000001, LendingStatus.AVAI,null));
            bookItems.Add(new BookItem(30000001, 00000001, LendingStatus.AVAI,null));
            bookItems.Add(new BookItem(10000001, 76543218, LendingStatus.AVAI,null));
            bookItems.Add(new BookItem(20000001, 76543219, LendingStatus.AVAI,null));
            bookItems.Add(new BookItem(30000001, 76543220, LendingStatus.AVAI,null));
        }
        
        private void loadMembersFromDB()
        {
            //fake load to test
            members.Add(new Account("Pham Minh Tân","Long An","pmt@gmail.com","0343027600", 1307, AccountStatus.ACTIVE, new DateTime(2019,12,31),0));
            members.Add(new Account("Pham Minh Tân 1", "Long An", "pmt1@gmail.com", "0343027601",1412 , AccountStatus.ACTIVE, new DateTime(2019, 12, 31), 1));
            members.Add(new Account("Pham Minh Tân 2", "Long An", "pmt2@gmail.com", "0343027602", 1111, AccountStatus.ACTIVE, new DateTime(2019, 12, 31), 2));
            members.Add(new Account("Pham Minh Tân 3", "Long An", "pmt3@gmail.com", "0343027603", 8266, AccountStatus.ACTIVE, new DateTime(2019, 12, 31), 3));
            members.Add(new Account("Pham Minh Tân 4", "Long An", "pmt4@gmail.com", "0343027604", 1530, AccountStatus.ACTIVE, new DateTime(2019, 12, 31), 4));
            members.Add(new Account("Pham Minh Tân 5", "Long An", "pmt3@gmail.com", "0343027603", 2583, AccountStatus.BLACKLISTED, new DateTime(2019, 12, 31), 3));
            members.Add(new Account("Pham Minh Tân 6", "Long An", "pmt4@gmail.com", "0343027604", 1609, AccountStatus.BLACKLISTED, new DateTime(2019, 12, 31), 4));
        }


    }
}
