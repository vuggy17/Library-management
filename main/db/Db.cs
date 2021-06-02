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
        private const string connectionString = "server=localhost;user id=cnpm;database=cnpm;port=3306;password=pass";
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

        public bool isUserExits(string id, string password)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from ACCOUNT where ID= @ID";
                        cmd.Parameters.AddWithValue("@ID", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            return reader.HasRows ? true : false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;

        }
        public void createNewAccount(Account account)
        {
            // tim id cua person trong account, xong roi add new account theo id cua person tim dc, neu khong co person thi bao loi
            var personId = getPersonId(account.info.name, account.info.email);
            if (personId == "-1")
            {
                MessageBox.Show("User Profile not exist");
                return;
            }
            var command = $"INSERT INTO `ACCOUNT` ( `PASSWORD`, `STATUS`, `PERSON`, `TOTALBOOKCHECKOUT`) VALUES( '{account.password}' , '{account.status}', '{personId}', '{account.totalBookLoan}')";

            executeCommand(command);
            closeConnection();

        }

        // lay info cua user theo name va email, neu ton tai tra id, khong ton tai tra -1
        public string getPersonId(string name, string email)
        {
            var personId = "-1";
            var command = $"SELECT `ID` FROM `PERSON` WHERE `NAME`= '{name}' AND `EMAIL`='{email}'";
            var reader = executeCommand(command);

            while (reader.Read())
            {
                personId = reader[0].ToString();
            }

            closeConnection();
            return personId;
        }

        public bool editPersonInfo(string name, string email)
        {

            return true;
        }
        public void dropPersonInfo(Person person)
        {
            var command = $"DELETE FROM `PERSON` WHERE NAME='{person.name}' EMAIL='{person.email}'";
            executeCommand(command);
            closeConnection();
        }


        // fix command
        public bool editAccoutInfo(Account account)
        {
            var isSuccess = false;
            var personId = getPersonId(account.info.name, account.info.email);
            if (personId == "-1")
            {
                MessageBox.Show("Invalid user");
                return false;
            }
            var command = $"UPDATE `ACCOUNT` SET `STATUS`='{account.status}',`PERSON`='{personId}',`TOTALBOOKCHECKOUT`='{account.totalBookLoan}' WHERE  ";
            var reader = executeCommand(command);
            isSuccess = reader.HasRows ? true : false;
            closeConnection();
            return isSuccess;
        }
    }
}
//using (var reader = cmd.ExecuteReader())
//{
//    int i = 0;
//    while (reader.Read())
//    {

//        Console.WriteLine(reader[i++]);
//    }
//}