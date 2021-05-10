using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace main
{
    public class Db
    {
        private Db() { }
        private static Db _instance;
        public MySqlConnection connection { get; set; }
        private const string connectionString = "server=localhost;user id=cnpm;database=cnpm;port=3306;password=pass";
        public Db openConnection()
        {
            //conncept
            //using (connection = new MySqlConnection(connectionString))
            //{
            //    connection.Open();

            //    using (var command = new MySqlCommand("SELECT * FROM AUTHOR;", connection))
            //    using (var reader = command.ExecuteReader())
            //        while (reader.Read())
            //            Console.WriteLine(reader.GetString(1));
            //}
            connection = new MySqlConnection(connectionString);
            if (getConnectionStatus() == "closed")
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            return _instance;
        }
        public static Db getInstace()
        {
            if (_instance == null)
                _instance = new Db();
            return _instance;
        }
        public string getConnectionStatus()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
                return "open";
            else return "closed";
        }
       

    }
}
