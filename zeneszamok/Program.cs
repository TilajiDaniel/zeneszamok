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
            string valasztott = "";
            bool kilep = true;
            do
            {

            Console.WriteLine("1. Előadók listázása");
            Console.WriteLine("2. Előadó felvétele");
            Console.WriteLine("3. Előadó módosítása");
            Console.WriteLine("4. Előadó törlése");
            Console.WriteLine("5. Kilépés");
            valasztott = Console.ReadLine();
            switch (valasztott)
            {
                case "1":
                    List<Eloado> eloadoLista = EladoLista();
                    foreach (var item in eloadoLista)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "2":
                        Eloado rogzitendo = EloadoBekerese();
                        string uzenetUJ = EloadoFelvetele(rogzitendo);
                        Console.WriteLine(uzenetUJ);    
                        break;
                case "3":
                        Eloado modositando = EloadoBekerese();
                        string uzenetMOdosit = EloadoModositasa(modositando);
                        Console.WriteLine(uzenetMOdosit);
                        break;
                case "4":
                        Console.WriteLine("Kérem a törlendő előadó azonosítóját:");
                        int torlendoId = int.Parse(Console.ReadLine());
                        string uzenetTorol = EloadoTorlese(torlendoId);
                        Console.WriteLine(uzenetTorol);
                        break;
                case "5":
                     kilep = false;
                     break;
                default:
                    Console.WriteLine("Nincs ilyen menüpont!");
                    break;
            }
            } while (kilep);


            
        }
        private static string EloadoTorlese(int id )
        {
            SQLConnection.Open();
            string sql = "DELETE FROM eloado WHERE Id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, SQLConnection);
            cmd.Parameters.AddWithValue("@id", id);
            int erintettSorok = cmd.ExecuteNonQuery();
            SQLConnection.Close();
            return erintettSorok > 0 ? "Sikeres torles" : "Sikertelen torles";
        }
        private static string EloadoModositasa(Eloado modositando)
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
        private static string EloadoFelvetele(Eloado rogzitendo)
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

        static Eloado EloadoBekerese()
        {
            Eloado Ujeloado = new Eloado();
            Console.WriteLine("Kérem az előadó azonosytot:");
            Ujeloado.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem az előadó nevét:");
            Ujeloado.Nev = Console.ReadLine();
            Console.WriteLine("Kérem az előadó nemzetiségét:");
            Ujeloado.Nemzetiseg = Console.ReadLine();
            Console.WriteLine("Kérem az előadó szóló előadó e? (igen/nem)");
            Ujeloado.Szolo = "igen" == Console.ReadLine().ToLower();
            return Ujeloado;


        }
        static List<Eloado> EladoLista()
        {
            List<Eloado> eloadoLista = new List<Eloado>();
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
