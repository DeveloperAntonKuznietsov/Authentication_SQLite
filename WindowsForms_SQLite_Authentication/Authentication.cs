﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_SQLite_Authentication
{
    public partial class Authentication : Form
    {
        MainWindow mainWindow = new MainWindow();
        Registration registration = new Registration();
        public Authentication()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            registration.ShowDialog();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            mainWindow.Show();
            this.Hide();
        }
    }
}
