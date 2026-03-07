using Azure.Core.Extensions;
using CoworkingSystem.backend;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoworkingSystem
{
    public partial class LoginForma : Form
    {
        public LoginForma()
        {
            InitializeComponent();
        }

        private void lgnBtn_Click(object sender, EventArgs e)
        {
            IRepoFactory repo = new SqlRepoFactory();

            string username = usrTxt.Text.Trim();
            string password = pswTxt.Text;

            AdminService auth = new AdminService(repo.createAdminRepo());

            bool ok = auth.Validate(username, password);
            if (!ok)
            {
                greskaLbl.Text = "Pogrešan username ili lozinka.";
                return;
            }

            MessageBox.Show("Login uspešan!");

            // ovde otvori glavnu formu
            var main = new Form1();
            main.Show();

            this.Hide();
        }

        private void LoginForma_Load(object sender, EventArgs e)
        {

        }
    }
}
