using MySql.Data.MySqlClient;
using System;
using zeneszamok.Controllers;
using zeneszamok.Models;

namespace zeneszamok
{
    internal class Program
    {
        static MySqlConnection SQLConnection;
        static void Main(string[] args)
        {
            string adott = "";
            bool vege = true;
            do
            {
                adott = FoMenuKiirasa();
                switch (adott)
                {
                    case "1":
                        string valasztott = "";
                        bool kilep = true;
                        do
                        {
                            valasztott = MenuKiirasa();

                            switch (valasztott)
                            {
                                case "1":
                                    List<Eloado> eloadoLista = new EloadaoController().EladoLista();
                                    foreach (var item in eloadoLista)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.WriteLine("A folytatáshoz nyomjon egy entert!");
                                    Console.ReadLine();
                                    break;
                                case "2":
                                    Eloado rogzitendo = EloadoBekerese();
                                    string uzenetUJ = new EloadaoController().EloadoFelvetele(rogzitendo);
                                    Console.WriteLine(uzenetUJ);
                                    Console.WriteLine("A folytatáshoz nyomjon egy entert!");
                                    Console.ReadLine();
                                    break;
                                case "3":
                                    Eloado modositando = EloadoBekerese();
                                    string uzenetMOdosit = new EloadaoController().EloadoModositasa(modositando);
                                    Console.WriteLine(uzenetMOdosit);
                                    Console.WriteLine("A folytatáshoz nyomjon egy entert!");
                                    Console.ReadLine();
                                    break;
                                case "4":
                                    Console.WriteLine("Kérem a törlendő előadó azonosítóját:");
                                    int torlendoId = int.Parse(Console.ReadLine());
                                    string uzenetTorol = new EloadaoController().EloadoTorlese(torlendoId);
                                    Console.WriteLine(uzenetTorol);
                                    Console.WriteLine("A folytatáshoz nyomjon egy entert!");
                                    Console.ReadLine();
                                    break;
                                case "5":
                                    kilep = false;
                                    break;
                                default:
                                    Console.WriteLine("Nincs ilyen menüpont!");
                                    break;
                            }
                            Console.WriteLine("A folytatáshoz nyomjon egy entert!");
                            Console.ReadLine();
                        } while (kilep);
                        break;
                    case "2":
                        string opciok = "";
                        bool viszalep = true;
                        do
                        {
                            opciok = MenuKetoKiirasa();

                            switch (opciok)
                            {
                                case "1":
                                    List<Lemez> lemezLista = new LemezController().LemezLista();
                                    foreach (var item in lemezLista)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.WriteLine("A folytatáshoz nyomjon egy entert!");
                                    Console.ReadLine();
                                    break;
                                case "2":
                                    Lemez rogzitendolemez = LemezBekerese();
                                    string uzenetUJ = new LemezController().LemezFelvetele(rogzitendolemez);
                                    Console.WriteLine(uzenetUJ);
                                    Console.WriteLine("A folytatáshoz nyomjon egy entert!");
                                    Console.ReadLine();
                                    break;
                                case "3":
                                    Lemez modositandolemez = LemezBekerese();
                                    string uzenetMOdosit = new LemezController().LemezModositasa(modositandolemez);
                                    Console.WriteLine(uzenetMOdosit);
                                    Console.WriteLine("A folytatáshoz nyomjon egy entert!");
                                    Console.ReadLine();
                                    break;
                                case "4":
                                    Console.WriteLine("Kérem a törlendő előadó azonosítóját:");
                                    int torlendoId = int.Parse(Console.ReadLine());
                                    string uzenetTorol = new LemezController().LemezTorlese(torlendoId);
                                    Console.WriteLine(uzenetTorol);
                                    Console.WriteLine("A folytatáshoz nyomjon egy entert!");
                                    Console.ReadLine();
                                    break;
                                case "5":
                                    kilep = false;
                                    break;
                                default:
                                    Console.WriteLine("Nincs ilyen menüpont!");
                                    break;
                            }
                            Console.WriteLine("A folytatáshoz nyomjon egy entert!");
                            Console.ReadLine();
                        } while (viszalep);
                        break;
                    case "3":
                        vege = false;
                        break;
                }



            } while (vege);


        }

        private static Eloado EloadoBekerese()
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
        private static Lemez LemezBekerese()
        {
            Lemez Ujlemez = new Lemez();
            Console.WriteLine("Kérem az előadó azonosytot:");
            Ujlemez.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem a lemez cimet :");
            Ujlemez.Cim = Console.ReadLine();
            Console.WriteLine("Kérem az előadó Éve:");
            Ujlemez.KiadasEve = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem a a lemez kiadojat ");
            Ujlemez.Kiado = Console.ReadLine();
            return Ujlemez;
        }

        static string FoMenuKiirasa()
            {
                string adott = "";
                Console.Clear();
                Console.WriteLine("1. Előadók kezelése");
                Console.WriteLine("2. Zeneszámok kezelése");
                Console.WriteLine("3. Kilépés");
                adott = Console.ReadLine();
                return adott;
            }

            static string MenuKiirasa()
            {
                string valasztott = "";
                Console.Clear();
                Console.WriteLine("1. Előadók listázása");
                Console.WriteLine("2. Előadó felvétele");
                Console.WriteLine("3. Előadó módosítása");
                Console.WriteLine("4. Előadó törlése");
                Console.WriteLine("5. Kilépés");
                valasztott = Console.ReadLine();
                return valasztott;
            }
            static string MenuKetoKiirasa()
            {
                string opciokk = "";
                Console.Clear();
                Console.WriteLine("1. Lemezek listázása");
                Console.WriteLine("2. Lemezek felvétele");
                Console.WriteLine("3. Lemezek módosítása");
                Console.WriteLine("4. Lemezek törlése");
                Console.WriteLine("5. Kilépés");
                opciokk = Console.ReadLine();
                return opciokk;
            }

        }  
    }


