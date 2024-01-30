using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Verbindungsinformationen zum SQL Server
        string server = "DESKTOP-HR8IHM9\\SQLEXPRESS";
        string database = "MertYamaliDB";
        string username = "";
        string password = "465020";

        // Verbindungsschnur (Connection String) erstellen
        string connectionString = $"Server={server};Database={database};User Id={username};Password={password};";

        // SqlConnection-Objekt erstellen
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // Verbindung öffnen
                connection.Open();
                Console.WriteLine("Verbindung erfolgreich geöffnet.");

                

                // Beispiel: SQL-Befehl ausführen
                string sqlQuery = "SELECT * FROM DeineTabelle";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Verarbeitung der Daten hier
                            Console.WriteLine(reader["Vorname"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Öffnen der Verbindung: {ex.Message}");
            }
        }
    }
}
