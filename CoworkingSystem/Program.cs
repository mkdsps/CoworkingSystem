using CoworkingSystem.backend;
using CoworkingSystem.backend.dbConnection;
using CoworkingSystem.backend.Runners;
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
            DbManager manager = DbManager.GetInstance();
            Config config = Config.getInstance();

            MessageBox.Show(
                $"Brand={config.name}\nType={config.type}\nCS={config.connectionString}",
                "CONFIG DEBUG"
            );


            //Andra.Run();
            //Igor.Run();

            //Milica.Run();
            //Lazar.Run();
            Smilja.Run();

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForma());
            
        }
    }
}
