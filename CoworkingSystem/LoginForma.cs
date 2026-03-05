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
            string username = usrTxt.Text.Trim();
            string password = pswTxt.Text;

            //var auth = new AuthService();
            //bool ok = auth.Login(username, password);


            if (false
                )
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
    }
}
