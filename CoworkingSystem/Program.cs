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
            try
            {
                TestMSSQL();
                //TestMySQL();

                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        static void TestMySQL()
        {
            string connStr = "Server=localhost;Port=3306;Database=TestDb;User=root;Password=root123;";

            using var conn = new MySqlConnection(connStr);
            conn.Open();

            using var cmd = new MySqlCommand("select count(*) from Users", conn);
            var result = cmd.ExecuteScalar();

            MessageBox.Show($"Rezultat: {result}");
        }
    }
}
