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
        string connection;

        public void GetConnection()
        {
            connection = @"Data Source = Account.db; Version=3";
            connectionString = connection;
        }

        public void CreateDataBase()// проверка на наличие файла
        {
            if (!File.Exists("Account.db"))
            {
                File.Create("Account.db");

                CreateTable();
            }
            else CreateTable(); //CreateTable();если такой файл есть то просто создать таблицу
        }
        private void CreateTable()
        {
            GetConnection();
            using (SQLiteConnection connect = new SQLiteConnection(connection))
            {
                connect.Open();
                SQLiteCommand cmd = new SQLiteCommand();

                string query = @"CREATE TABLE Akun (ID INTEGER PRIMARY KEY AUTOINCREMENT,Username Text(25),Password Text(25), Email Text (35))";
                cmd.CommandText = query;
                cmd.Connection = connect;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
