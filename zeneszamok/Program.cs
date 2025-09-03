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
                        break;
                case "3":
                    break;
                case "4":
                     break;
                case "5":
                     kilep = false;
                     break;
                default:
                    Console.WriteLine("Nincs ilyen menüpont!");
                    break;
            }
            } while (kilep);


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
