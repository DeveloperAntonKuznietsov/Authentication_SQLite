﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsForms_SQLite_Authentication
{
    public partial class Registration : Form
    {
        Authentication authentication;

        public Registration()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFaq_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В этом окне Вы должны зарегестрирываться\nобратите внимание что пороль должен совпадать.", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text!=""&&
                txtPassword.Text!=""&&
                txtConfirmPassword.Text!=""&&
                txtAddress.Text != "")
            {
                if (txtPassword.Text.Equals(txtConfirmPassword.Text))
                {
                    CheckAccount(txtUserName.Text);
                }
            }
        }

        private void CheckAccount(string username)
        {
            authentication = new Authentication();
            authentication.CreateDataBase();
            authentication.GetConnection();

            using (SQLiteConnection sqlconnection = new SQLiteConnection(authentication.connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand();
                sqlconnection.Open();

                int count = 0;
                string query = @"SELECT * FROM Akun WHERE Username= '"+username+"'";
                cmd.CommandText = query;
                cmd.Connection = sqlconnection;
            }

        }
    }
}
