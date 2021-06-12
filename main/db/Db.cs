using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using main.model;
using System.Globalization;

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
            string command = "select * from PERSON where ID = "+PersonId.ToString();
            var reader = executeCommand(command);
            while (reader.Read())
            {
                return new Person(reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
            }
            closeConnection();
            return null;
            
        }
        private model.enums.AccountStatus castTypeAccount(string value )
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
        public List<Account> getAllAccount()
        {
            List<Account> accounts = new List<Account>();
            string command = "select * from ACCOUNT";
            var reader = executeCommand(command);
            while (reader.Read())
            {
                
                Person info = getInfoByAccountID((int)reader[2]);
                if(info != null)
                {
                    accounts.Add(new Account(info.name, info.address, info.email, info.phone, (int)reader[0], castTypeAccount(reader[1].ToString()), (DateTime)reader[3], (int)reader[4]));
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
                books.Add(new Book((int)reader[0], reader[1].ToString(), reader[2].ToString(), (DateTime)reader[3], (double)reader[4]));
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
                if(reader[3].GetType()!=typeof(DBNull))
                {
                    DateTime dateTime = (DateTime)reader[3];
                    bookItems.Add(new BookItem(int.Parse(reader[0].ToString()), int.Parse(reader[2].ToString()), castTypeLendingBookItem(reader[1].ToString()), dateTime));
                }
                else
                {
                    bookItems.Add(new BookItem(int.Parse(reader[0].ToString()), int.Parse(reader[2].ToString()), castTypeLendingBookItem(reader[1].ToString()), null));
                }                
            }
            closeConnection();
            return bookItems;
        }
    }
}
