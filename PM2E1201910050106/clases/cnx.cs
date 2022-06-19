using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using System.Text;
using System.Threading.Tasks;
using PM2E1201910050106.model;

namespace PM2E1201910050106.clases
{
    public class cnx
    {
        private string pathdb;

        public cnx() { }

       

        public string Conector()
        {
            string dbname = "db.sqlite";
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            pathdb = Path.Combine(path, dbname);
            return pathdb;
        }

        public SQLiteConnection Conn()
        {
            SQLiteConnection conn = new SQLiteConnection(App.UBICACIONDB);
            return conn;
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            return new SQLiteAsyncConnection(App.UBICACIONDB);
        }


    }

  
}
