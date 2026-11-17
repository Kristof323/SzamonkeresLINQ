using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace SzamonkeresLINQ
{
    internal class SzornyAdatbazis
    {

        private static readonly string server = "localhost";
        private static readonly string databaseName = "fantasybestariumdb";
        private static readonly string userName = "root";
        private static readonly string password = "";

        private static readonly string connectionString =
            $"Server={server};Database={databaseName};Uid={userName};Pwd={password};";


        public static List<Szorny> Feltolt(List<Szorny> szornyek)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM szornyek";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var szorny = new Szorny(
                                reader.GetInt32("id"),
                                reader.GetString("nev"),
                                reader.GetInt32("veszelyessegi_szint"),
                                reader.GetString("elohely"),
                                reader.GetString("fo_gyengeseg"),
                                reader.GetString("leggyakoribb_zsakmany"),
                                reader.GetBoolean("veszelyes_e")
                            );

                            szornyek.Add(szorny);
                        }
                    }
                }

                if (!szornyek.Any())
                {
                    Console.WriteLine("Nincs szörny az adatbázisban.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Adatbázis hiba: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ismeretlen hiba: {ex.Message}");
            }

            return szornyek;
        }
    }

}
