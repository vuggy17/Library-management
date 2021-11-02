using LibraryManagement.layout;
using LibraryManagement.model;
using LibraryManagement.model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManagement.controller
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
            if(db.addBookItem(bookItem) == true)
            {
                bookItems.Add(bookItem);
            }
            else
            {
                MessageBox.Show("System error, please wait a minute then try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }           
           
        }
        public void addNewBook(Book book)
        {            
            book.buildWithID(db.addBook(book));
            db.inseartBookImage(book);
            if(book.id != -1)
            {
                books.Add(book);
            }
            else
            {
                MessageBox.Show("System error, please wait a minute then try again","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        public void addNewMember(Account member)
        {
            member.id=db.addNewAccount(member);
            db.insertImageData(member.info);       
           
            
            if(member.id != -1)
            {
                members.Add(member);
            }
            else
            {
                MessageBox.Show("System error, please wait a minute then try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
        public void deleteBook(Book book)
        {            
            foreach (var bookItem in book.getAllBookItems())
            {
                deleteBookItems(bookItem);
            }
            if (db.dropBook(book))
            {
                books.Remove(book);
            }
            else
            {
                MessageBox.Show("System error, please wait a minute then try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        public void deleteBookItems(BookItem bookItem)
        {
            if (db.dropBookItem(bookItem))
            {
                bookItems.Remove(bookItem);
            }
            else
            {
                MessageBox.Show("System error, please wait a minute then try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
        public void deleteMember(Account member)
        {
            if (db.dropAccount(member))
            {
                
                if (db.dropPerson(member.info))
                {
                    members.Remove(member);
                }
                else
                {
                    MessageBox.Show("System error, please wait a minute then try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("System error, please wait a minute then try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            
        }

        public void updateBook(Book value)
        {
            for( int i=0; i< books.Count; i++)
            {
                if(books[i].id == value.id)
                {
                    if (db.updateBook(value))
                    {
                        db.inseartBookImage(value);
                        books[i] = value;
                    }
                    else
                    {
                        MessageBox.Show("System error, please wait a minute then try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }                   
                   
                }
            }            
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
        public BookItem findBookItemByID(int id)
        {
            foreach (var bookItem in bookItems)
            {
                if (bookItem.id == id)
                {
                    return bookItem;
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
                    if (db.updateAccount(value))
                    {
                        members[i] = value;
                        return members[i];
                    }
                    else
                    {
                        MessageBox.Show("System error, please wait a minute then try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
            return null;
           
        }
        public Account updateMemberInfo(Person value)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].info.id == value.id)
                {                  
                    if (db.updateInfo(value) && db.insertImageData(value))
                    {

                        members[i].info = value;
                        return members[i];
                    }
                    else
                    {
                        MessageBox.Show("System error, please wait a minute then try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            return null;

        }

        public BookItem updateBookItem(BookItem value)
        {
            for (int i = 0; i < bookItems.Count; i++)
            {
                if (bookItems[i].id == value.id)
                {
                    if (db.updateBookItem(value))
                    {
                        bookItems[i] = value;
                        return bookItems[i];
                    }
                    else
                    {
                        MessageBox.Show("System error, please wait a minute then try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

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
