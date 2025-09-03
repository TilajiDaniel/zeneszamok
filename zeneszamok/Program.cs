using MySql.Data.MySqlClient;
using System;
using zeneszamok.Models;

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
            List<Eloado> eloadoLista = new List<Eloado>();
            while (reader.Read())
            {
                Eloado eloado = new Eloado();
                eloado.Id = reader.GetInt32("Id");
                eloado.Nev = reader.GetString("Nev");
                if (!reader.IsDBNull(reader.GetOrdinal("Nemzetiseg")))
                {
                    eloado.Nemzetiseg = reader.GetString("Nemzetiseg");
                }
                eloado.Szolo = reader.GetBoolean("Szolo");
                eloadoLista.Add(eloado);
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
