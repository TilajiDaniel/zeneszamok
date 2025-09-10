using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeneszamok.Models;

namespace zeneszamok.Controllers
{
    internal class EloadaoController
    {
        static MySqlConnection SQLConnection;
        public static void BuildConnection()
        {

            string connectionString = "SERVER = localhost;" +
                                      "DATABASE= zene;" +
                                      "UID = root;" +
                                      "PASSWORD =;" +
                                      "SSL MODE= none;";
            SQLConnection = new MySqlConnection();
            SQLConnection.ConnectionString = connectionString;
        }
        public string EloadoTorlese(int id)
        {
            BuildConnection();
            SQLConnection.Open();
            string sql = "DELETE FROM eloado WHERE Id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, SQLConnection);
            cmd.Parameters.AddWithValue("@id", id);
            int erintettSorok = cmd.ExecuteNonQuery();
            SQLConnection.Close();
            return erintettSorok > 0 ? "Sikeres torles" : "Sikertelen torles";
        }
        public string EloadoModositasa(Eloado modositando)
        {
            SQLConnection.Open();
            string sql = "UPDATE eloado SET Nev = @nev, Nemzetiseg = @nemzetiseg, Szolo = @szolo WHERE Id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, SQLConnection);
            cmd.Parameters.AddWithValue("@nev", modositando.Nev);
            cmd.Parameters.AddWithValue("@nemzetiseg", modositando.Nemzetiseg);
            cmd.Parameters.AddWithValue("@szolo", modositando.Szolo);
            cmd.Parameters.AddWithValue("@id", modositando.Id);
            int erintettSorok = cmd.ExecuteNonQuery();
            SQLConnection.Close();
            return erintettSorok > 0 ? "Sikeres modositas" : "Sikertelen modositas";
        }
        public string EloadoFelvetele(Eloado rogzitendo)
        {
            SQLConnection.Open();
            string sql = "INSERT INTO eloado(Nev, Nemzetiseg, Szolo) VALUES (@nev,@nemzetiseg,@szolo)";
            MySqlCommand cmd = new MySqlCommand(sql, SQLConnection);
            cmd.Parameters.AddWithValue("@nev", rogzitendo.Nev);
            cmd.Parameters.AddWithValue("@nemzetiseg", rogzitendo.Nemzetiseg);
            cmd.Parameters.AddWithValue("@szolo", rogzitendo.Szolo);
            int erintettSorok = cmd.ExecuteNonQuery();
            SQLConnection.Close();
            return erintettSorok > 0 ? "Sikeres felvétel" : "Sikertelen felvétel";
        }
        public List<Eloado> EladoLista()
        {
            List<Eloado> eloadoLista = new List<Eloado>();
            BuildConnection();
            SQLConnection.Open();
            string sql = "SELECT * FROM eloado";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = SQLConnection;
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Eloado eloado = new Eloado();
                eloado.Id = reader.GetInt32("Id");
                eloado.Nev = reader.GetString("Nev");
                if (!reader.IsDBNull(2))
                {
                    eloado.Nemzetiseg = reader.GetString
                        ("Nemzetiseg");
                }
                eloado.Szolo = reader.GetBoolean("Szolo");
                eloadoLista.Add(eloado);
            }
            SQLConnection.Close();
            return eloadoLista;
        }
    }
}
