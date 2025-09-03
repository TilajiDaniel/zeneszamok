using MySql.Data.MySqlClient;
using System;

namespace zeneszamok
{
    internal class Program
    {
        static MySqlConnection SQLConnection;
        static void Main(string[] args)
        {
            string connectionString = "SERVER = localhost;" +
                          "DATABASE= zene;" +
                          "UID = root;" +
                          "PASSWORD =;" +
                          "SSL MODE= none;";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            string sql = "SELECT * FROM előadó";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //A beolvasott adatok feldolgozása

            }
            conn.Close();

        }
    }
}
