using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using main.model;
using System.Globalization;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace main
{
    public class Db
    {
        public StringBuilder result = new StringBuilder();
        private Db() { }
        private static Db _instance;
        private MySqlConnection connection { get; set; }
        private const string connectionString = "server=localhost;user id=root;database=cnpm;port=3306;password=pass";
        public static Db getInstace()
        {
            if (_instance == null)
                _instance = new Db();
            return _instance;
        }

        // fix hàm này,
        // chưa trả về kết quả của query
        private MySqlDataReader executeCommand(string command)
        {
            MySqlDataReader reader = null;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = command;
                reader = cmd.ExecuteReader();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return reader;

        }

        private void closeConnection()
        {
            if (this.connection.State == System.Data.ConnectionState.Open || connection == null)
                this.connection.Close();
        }

        public Person getInfoByAccountID(int PersonId)
        {
            string command = "select * from PERSON where ID = " + PersonId.ToString();
            var reader = executeCommand(command);
            while (reader.Read())
            {
                Person person = new Person(reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()).buildWithID((int)reader[0]);
                getImage(person);
                person.image = setImage(person);
                return person;
            }
            closeConnection();
            return null;

        }
        private model.enums.AccountStatus castTypeAccount(string value)
        {
            switch (value)
            {
                case "ACTIVE":
                    return model.enums.AccountStatus.ACTIVE;
                case "BLACKLISTED":
                    return model.enums.AccountStatus.BLACKLISTED;
                default:
                    return model.enums.AccountStatus.NONE;
            }
        }
        private model.enums.LendingStatus castTypeLendingBookItem(string value)
        {
            switch (value)
            {
                case "AVAI":
                    return model.enums.LendingStatus.AVAI;
                case "LOANED":
                    return model.enums.LendingStatus.LOANED;
                case "LOST":
                    return model.enums.LendingStatus.LOST;
                case "READY":
                    return model.enums.LendingStatus.READY;
                case "RENEWED":
                    return model.enums.LendingStatus.RENEWED;
                case "RESV":
                    return model.enums.LendingStatus.RESV;
                default:
                    return model.enums.LendingStatus.AVAI;
            }
        }
        public BitmapImage setImage(Person person)
        {           
            string imreBase64Data = person.imgSource;
            byte[] blob = Convert.FromBase64String(imreBase64Data);

            using (var ms = new System.IO.MemoryStream(blob))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
        public List<Account> getAllAccount()
        {
            List<Account> accounts = new List<Account>();
            string command = "select * from ACCOUNT";
            var reader = executeCommand(command);
            while (reader.Read())
            {

                Person info = getInfoByAccountID((int)reader[2]);
                if (info != null)
                {
                    Account account = new Account(info.name, info.address, info.email, info.phone, castTypeAccount(reader[1].ToString()), (DateTime)reader[3], (int)reader[4]).buildWithId((int)reader[0]);
                    account.info.id = info.id;
                    account.info.image = setImage(info);
                    accounts.Add(account);
                }

            }
            closeConnection();
            return accounts;
        }
        public List<Staff> getAllStaffs()
        {
            List<Staff> staff = new List<Staff>();
            string command = "select * from STAFF";
            var reader = executeCommand(command);
            while (reader.Read())
            {
                Person info = getInfoByAccountID((int)reader[1]);
                if (info != null)
                {
                    staff.Add(new Staff(info, (int)reader[0], reader[2].ToString()));
                }

            }
            closeConnection();
            return staff;
        }
        public List<Book> getAllBooks()
        {
            List<Book> books = new List<Book>();
            string command = "select * from BOOK";
            var reader = executeCommand(command);
            while (reader.Read())
            {
                Book add = new Book(reader[1].ToString(), reader[2].ToString(), (DateTime)reader[3], (double)reader[4]).buildWithID((int)reader[0]);
                add.imgSource = reader[5].ToString();
                books.Add(add);

            }
            closeConnection();
            return books;
        }
        public List<BookItem> getAllBookItems()
        {
            List<BookItem> bookItems = new List<BookItem>();
            string command = "select * from BOOKITEM";
            var reader = executeCommand(command);
            while (reader.Read())
            {


                bookItems.Add(new BookItem(int.Parse(reader[0].ToString()), int.Parse(reader[2].ToString()), castTypeLendingBookItem(reader[1].ToString())));

            }
            closeConnection();
            return bookItems;
        }
        public int addBook(Book book)
        {
            int lastInsertID = -1;
            string command = $"INSERT INTO `BOOK`( `TITLE`, `AUTHOR`, `PUBDATE`, `PRICE`) VALUES ('{book.title}','{book.author}','{book.pubDate.Year}-{book.pubDate.Month}-{book.pubDate.Day}','{book.price}')";
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(command, connection);
                cmd.ExecuteNonQuery();
                lastInsertID = int.Parse(cmd.LastInsertedId.ToString());
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return lastInsertID;
        }
        public bool addBookItem(BookItem bookItem)
        {
            string command = $"INSERT INTO `BOOKITEM`(`ID`,`STATUS`, `BOOKINFO`) VALUES ('{bookItem.id}','{bookItem.lendingStatus}','{bookItem.info}')";
            var reader = executeCommand(command);
            if (reader != null)
            {
                closeConnection();
                return true;
            }
            else
            {
                closeConnection();
                return false;
            }

        }
        private int addNewPersonInfo(Person info)
        {
            int lastInsertID = -1;
            string command = $"INSERT INTO `PERSON`(`NAME`, `ADDRESS`, `EMAIL`, `PHONE`) VALUES ('{info.name}','{info.address}','{info.email}','{info.phone}')";
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(command, connection);
                cmd.ExecuteNonQuery();
                lastInsertID = int.Parse(cmd.LastInsertedId.ToString());
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return lastInsertID;
        }
        public int addNewAccount(Account account)
        {
            int lastInsertID = -1;
            int infoId = addNewPersonInfo(account.info);
            account.info.id = infoId;
            string command = $"INSERT INTO `ACCOUNT`(`STATUS`, `PERSON`, `TOTALBOOKCHECKOUT`) VALUES ('{account.status}','{infoId}','{account.totalBookLoan}')";
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(command, connection);
                cmd.ExecuteNonQuery();
                lastInsertID = int.Parse(cmd.LastInsertedId.ToString());
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return lastInsertID;
        }
        public bool dropBook(Book book)
        {
            bool result = false;
            string command = $"DELETE FROM `BOOK` WHERE ID = {book.id}";
            var reader = executeCommand(command);
            if (reader != null)
            {
                result = true;
            }
            closeConnection();
            return result;
        }
        public bool dropBookItem(BookItem bookItem)
        {
            bool result = false;
            string command = $"DELETE FROM `BOOKITEM` WHERE ID = {bookItem.id}";
            var reader = executeCommand(command);
            if (reader != null)
            {
                result = true;
            }
            closeConnection();
            return result;
        }
        public bool dropAccount(Account account)
        {
            bool result = false;
            string command = $"DELETE FROM `ACCOUNT` WHERE ID = {account.id}";
            var reader = executeCommand(command);
            if (reader != null)
            {
                result = true;
            }
            closeConnection();
            return result;
        }
        public bool dropPerson(Person person)
        {
            bool result = false;
            string command = $"DELETE FROM `PERSON` WHERE ID = {person.id}";
            var reader = executeCommand(command);
            if (reader != null)
            {
                result = true;
            }
            closeConnection();
            return result;
        }
        public bool updateBook(Book book)
        {
            bool result = false;
            string command = $"UPDATE `BOOK` SET `TITLE`='{book.title}',`AUTHOR`='{book.author}',`PUBDATE`='{book.pubDate.Year}-{book.pubDate.Month}-{book.pubDate.Day}',`PRICE`='{book.price}' WHERE ID = '{book.id}'";
            var reader = executeCommand(command);
            if (reader != null)
            {
                result = true;
            }
            closeConnection();
            return result;
        }
        public bool updateBookItem(BookItem bookItem)
        {
            bool result = false;
            string command = $"UPDATE `BOOKITEM` SET `STATUS`='{bookItem.lendingStatus}' WHERE ID = '{bookItem.id}'";
            var reader = executeCommand(command);
            if (reader != null)
            {
                result = true;
            }
            closeConnection();
            return result;
        }
        public bool updateInfo(Person info)
        {
            bool result = false;
            string command = $"UPDATE `PERSON` SET `NAME`='{info.name}',`ADDRESS`='{info.address}',`EMAIL`='{info.email}',`PHONE`='{info.phone}' WHERE ID = '{info.id}'";
            var reader = executeCommand(command);
            if (reader != null)
            {
                result = true;
            }
            closeConnection();
            return result;
        }
        public bool updateAccount(Account account)
        {
            bool result = false;
            string command = $"UPDATE `ACCOUNT` SET `STATUS`='{account.status}',`TOTALBOOKCHECKOUT`='{account.totalBookLoan}' WHERE ID ='{account.id}'";
            var reader = executeCommand(command);
            if (reader != null)
            {
                result = true;
            }
            closeConnection();
            return result;
        }
        public bool addNewBookToLendingList(Account account, BookItem item, Staff staff)
        {
            bool result = false;
            DateTime dateTime = DateTime.Now.AddDays(10);
            string cmd = $"INSERT INTO `LENDINGDETAIL`(`MEMBER_ID`, `BID`, `DUEDATE`, `STAFF_ID`) VALUES ('{account.id}','{item.id}','{dateTime.Year}-{dateTime.Month}-{dateTime.Day}','{staff.id}')";
            var reader = executeCommand(cmd);
            if (reader != null)
            {
                result = true;
            }
            closeConnection();
            return result;
        }
        public List<BookItem> loadLendingBookList(Account account)
        {
            List<BookItem> lendingBookList = new List<BookItem>();

            string command = $"select * from `LENDINGDETAIL` where MEMBER_ID = '{account.id}'";
            var reader = executeCommand(command);
            if (reader != null)
            {
                while (reader.Read())
                {
                    if (reader[4].GetType() == typeof(DBNull))
                    {
                        if (reader[3].GetType() != typeof(DBNull))
                        {

                            lendingBookList.Add(new BookItem((int)reader[1], (DateTime)reader[2], (DateTime)reader[3]));
                        }

                    }

                }
            }
            closeConnection();
            return lendingBookList;
        }
        public bool updateLendingRenew(Account account, BookItem item)
        {
            bool result = false;
            DateTime date = (DateTime)item.dueDate;
            string command = $"UPDATE `LENDINGDETAIL` SET `DUEDATE`='{date.Year}-{date.Month}-{date.Day}' WHERE MEMBER_ID = '{account.id}' and BID = '{item.id}' and RETURNDATE is null";
            var reader = executeCommand(command);
            if (reader != null)
            {
                result = true;
            }
            closeConnection();
            return result;
        }
        public bool RemoveLending(Account account, BookItem item)
        {
            bool result = false;
            DateTime date = DateTime.Now;
            string command = $"UPDATE `LENDINGDETAIL` SET `RETURNDATE`='{date.Year}-{date.Month}-{date.Day}' WHERE MEMBER_ID = '{account.id}' and BID = '{item.id}' and RETURNDATE is null";
            var reader = executeCommand(command);
            if (reader != null)
            {
                result = true;
            }
            closeConnection();
            return result;
        }
        public bool addNewBookToReserveList(Account account, BookItem item)
        {
            bool result = false;
            string cmd = $"INSERT INTO `BOOKRESERVATION`(`STATUS`, `BOOKID`, `MEMBER_ID`) VALUES ('WAITING','{item.id}','{account.id}')";
            var reader = executeCommand(cmd);
            if (reader != null)
            {
                result = true;
            }
            closeConnection();
            return result;
        }
        public List<int> loadReserveList(Account account)
        {
            List<int> idListReseved = new List<int>();
            string cmd = $"SELECT * FROM `BOOKRESERVATION` WHERE MEMBER_ID ='{account.id}' and STATUS = 'WAITING'";
            var reader = executeCommand(cmd);
            if (reader != null)
            {
                while (reader.Read())
                {
                    idListReseved.Add((int)reader[3]);
                }
            }
            closeConnection();
            return idListReseved;
        }
        public bool updateReserveList(Account account, BookItem book, string status)
        {
            bool result = false;
            string cmd = $"UPDATE `BOOKRESERVATION` SET `STATUS`='{status}' WHERE MEMBER_ID ='{account.id}' and BOOKID ='{book.id}' and STATUS = 'WAITING'";
            var reader = executeCommand(cmd);
            if (reader != null)
            {
                result = true;
            }
            closeConnection();
            return result;
        }
        public bool updatePassword(Staff staff)
        {
            bool result = false;
            string cmd = $"UPDATE `STAFF` SET `PASSWORD`='{staff.password}' WHERE ID = '{staff.id}'";
            var reader = executeCommand(cmd);
            if (reader != null)
            {
                result = true;
            }
            closeConnection();
            return result;
        }
        public bool updateHinhAnh(Person person)
        {
            bool result = false;
            string cmd = $"";
            var reader = executeCommand(cmd);
            if (reader != null)
            {
                result = true;
            }
            closeConnection();
            return result;
        }
        public bool updateHinhAnhSach(Book book)
        {
            bool result = false;
            string cmd = $"";
            var reader = executeCommand(cmd);
            if (reader != null)
            {
                result = true;
            }
            closeConnection();
            return result;
        }
        public void getImage(Person person)
        {
            string cmd = $"SELECT * FROM `PERSON` WHERE ID ={person.id}";
            var reader = executeCommand(cmd);
            if (reader != null)
            {
                while (reader.Read())
                {
                    if (reader[5].GetType() != typeof(DBNull))
                    {

                        person.imgSource =(string)reader[5];                       
                    }
                    
                }
                
            }
            closeConnection();
        }
        public bool insertImageData(Person person)
        {
            try
            {
                if (person.imgSource != "")
                {                   
                                   
                    string cmd = $"UPDATE `PERSON` SET `IMAGE`='{person.imgSource}' WHERE ID = {person.id}";
                    var reader = executeCommand(cmd);                    
                    closeConnection();                  

                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool inseartBookImage(Book book)
        {
            try
            {
                if (book.imgSource != "")
                {

                    string cmd = $"UPDATE `BOOK` SET `IMAGE`='{book.imgSource}' WHERE ID = {book.id}";
                    var reader = executeCommand(cmd);
                    closeConnection();

                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
