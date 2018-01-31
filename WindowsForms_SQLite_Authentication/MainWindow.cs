using System;
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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string username;
        private void MainWindow_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();

            username = login.usernames;
            lblWellcome.Text = "Wellcome, " + username + " !";
        }
    }
}
