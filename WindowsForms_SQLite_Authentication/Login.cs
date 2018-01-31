using System;
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
    public partial class Login : Form
    {
        
        
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }
        public string usernames;
        Authentication authentication;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text!=""&&
                txtPassword.Text != "")
            {
                checkAccount(txtUserName.Text,txtPassword.Text);
            }

            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибочка");
            }
        }

        private void checkAccount(string username, string password)
        {
            authentication = new Authentication();
            authentication.GetConnection();

            using (SQLiteConnection connection = new SQLiteConnection(authentication.connectionString))
            {
                connection.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                string query = @"SELECT * FROM Akun WHERE Username ='" + username + "' and Password ='" + password+ "'";

                int count = 0;
                cmd.CommandText = query;
                cmd.Connection = connection;

                SQLiteDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    count++;
                }

                if (count == 1)
                {
                    MessageBox.Show("Успешно", "Login Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    usernames = username;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Имя пользователя или пароль неверны!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
