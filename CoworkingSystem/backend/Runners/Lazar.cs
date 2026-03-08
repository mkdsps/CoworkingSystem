using CoworkingSystem.backend.Izvestaji;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;
using System;
using System.Windows.Forms;

namespace CoworkingSystem.backend.Runners
{
    internal class Lazar
    {
        private static ExportScheduler? _scheduler;

        public static void Run()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "LAZAR FAIL");
            }
        }
    }
}