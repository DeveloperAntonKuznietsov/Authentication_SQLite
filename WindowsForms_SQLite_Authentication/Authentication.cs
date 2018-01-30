using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace WindowsForms_SQLite_Authentication
{
    

    public class Authentication
    {
        public string connectionString { get; set; }//privat

        public void GetConnection()
        {
            string connection = @"Data Source = Account.db; Version=3";
            connectionString = connection;
        }

        public void CreateDataBase()// проверка на наличие файла
        {
            if (!File.Exists("Account.db"))
            {
                File.Create("Account.db");

                GetConnection();
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    SQLiteCommand cmd = new SQLiteCommand();
                    connection.Open();

                    string query = @"CREATE TABLE Akun (ID INTEGER PRIMARY KEY AUTOINCREMENT,UsernameText(25),Pasword Text(25), Email Text (35))";
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                }
            }
            else return;
        }
    }
}
