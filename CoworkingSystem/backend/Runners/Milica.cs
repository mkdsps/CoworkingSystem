using CoworkingSystem.backend.Izvestaji;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;
using System;
using System.Windows.Forms;

namespace CoworkingSystem.backend.Runners
{
    internal class Milica
    {
        public static void Run()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Milica FAIL");
            }
        }
    }
}