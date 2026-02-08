using CoworkingSystem.backend;
using Microsoft.Data.SqlClient;
using MySqlConnector;
using System;
using System.Windows.Forms;

namespace CoworkingSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // pravim neke promene
            // pravim neke promene
            // pravim neke promene
            // pravim neke promene

            //TestMSSQL();
            //TestMySQL();

            Config config = Config.getInstance();

            //MessageBox.Show($"MSSQL rezultat: {config.connectionString}");

            TestMySQL(config.connectionString);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            
        }

        static void TestMSSQL()
        {
            string connStr = "Server=localhost,1433;Database=TestDb;User Id=sa;Password=YourStrong!Passw0rd123;TrustServerCertificate=True;";
            using var conn = new SqlConnection(connStr);
            conn.Open();

            using var cmd = new SqlCommand("select count(*) from Users", conn);
            var result = cmd.ExecuteScalar();

            MessageBox.Show($"MSSQL rezultat: {result}");
        }

        static void TestMySQL(string connStr)
        {
            //string connStr = "Server=localhost;Port=3306;Database=TestDb;User=root;Password=root123;";

            using var conn = new MySqlConnection(connStr);
            conn.Open();

            using var cmd = new MySqlCommand("select 1", conn);
            var result = cmd.ExecuteScalar();

            MessageBox.Show($"Rezultat: {result}");
        }
    }
}
