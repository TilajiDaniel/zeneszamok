using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeneszamok.Models;

namespace zeneszamok.Controllers
{
    public class LemezController
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
        public string LemezTorlese(int id)
        {
            BuildConnection();
            SQLConnection.Open();
            string sql = "DELETE FROM lemez WHERE Id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, SQLConnection);
            cmd.Parameters.AddWithValue("@id", id);
            int erintettSorok = cmd.ExecuteNonQuery();
            SQLConnection.Close();
            return erintettSorok > 0 ? "Sikeres torles" : "Sikertelen torles";
        }
        public string LemezModositasa(Lemez modositandolemez)
        {
            BuildConnection();
            SQLConnection.Open();
            string sql = "UPDATE lemez SET Cim = @cim, KiadasEve = @kiadaseve, Kiado = @kiado WHERE Id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, SQLConnection);
            cmd.Parameters.AddWithValue("@cim", modositandolemez.Cim);
            cmd.Parameters.AddWithValue("@kiadaseve", modositandolemez.KiadasEve);
            cmd.Parameters.AddWithValue("@kiado", modositandolemez.Kiado);
            cmd.Parameters.AddWithValue("@id", modositandolemez.Id);
            int erintettSorok = cmd.ExecuteNonQuery();
            SQLConnection.Close();
            return erintettSorok > 0 ? "Sikeres modositas" : "Sikertelen modositas";
        }
        public string LemezFelvetele(Lemez rogzitendolemez)
        {
            BuildConnection();
            SQLConnection.Open();
            string sql = "INSERT INTO lemez(Cim, KiadasEve, Kiado) VALUES (@cim, @kiadaseve, @kiado)";
            MySqlCommand cmd = new MySqlCommand(sql, SQLConnection);
            cmd.Parameters.AddWithValue("@cim", rogzitendolemez.Cim);
            cmd.Parameters.AddWithValue("@kiadaseve", rogzitendolemez.KiadasEve);
            cmd.Parameters.AddWithValue("@Kiado", rogzitendolemez.Kiado);
            int erintettSorok = cmd.ExecuteNonQuery();
            SQLConnection.Close();
            return erintettSorok > 0 ? "Sikeres felvétel" : "Sikertelen felvétel";
        }
        public List<Lemez> LemezLista()
        {
            List<Lemez> lemezLista = new List<Lemez>();
            BuildConnection();
            SQLConnection.Open();
            string sql = "SELECT * FROM lemez";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = SQLConnection;
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Lemez lemez = new Lemez();
                lemez.Id = reader.GetInt32("Id");
                lemez.Cim = reader.GetString("Cim");
                lemez.KiadasEve = reader.GetInt32("KiadasEve");
                lemez.Kiado = reader.GetString("Kiado");
                lemezLista.Add(lemez);
            }
            SQLConnection.Close();
            return lemezLista;
        }
    }
}
