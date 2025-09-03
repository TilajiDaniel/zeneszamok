using MySql.Data.MySqlClient;
using System;

namespace zeneszamok
{
    internal class Program
    {
        static MySqlConnection SQLConnection;
        static void Main(string[] args)
        {
            BuildConnection();
            SQLConnection.Open();
            string sql = "SELECT * FROM eloado";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = SQLConnection;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //A beolvasott adatok feldolgozása

            }
            SQLConnection.Close();

        }

        private static void BuildConnection()
        {

            string connectionString = "SERVER = localhost;" +
                                      "DATABASE= zene;" +
                                      "UID = root;" +
                                      "PASSWORD =;" +
                                      "SSL MODE= none;";
            SQLConnection = new MySqlConnection();
            SQLConnection.ConnectionString = connectionString;
        }
    }
}
