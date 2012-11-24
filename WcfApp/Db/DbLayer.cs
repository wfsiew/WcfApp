using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using WcfApp;
using WcfApp.Model;

namespace WcfApp.Db
{
    public class DbLayer
    {
        public MySqlConnection Connection { get; set; }

        public void OpenConnection(string conStr)
        {
            Connection = new MySqlConnection();
            Connection.ConnectionString = conStr;
            Connection.Open();
        }

        public void CloseConnection()
        {
            Connection.Close();
        }

        public DataTable GetCars(int page, int pageSize)
        {
            DataTable dt = new DataTable();
            string q = "select * from Car limit @limit offset @offset";

            using (MySqlCommand cm = new MySqlCommand(q, Connection))
            {
                MySqlParameter p = new MySqlParameter("@limit", MySqlDbType.Int32);
                p.Value = pageSize;
                cm.Parameters.Add(p);

                p = new MySqlParameter("@offset", MySqlDbType.Int32);
                p.Value = (page - 1) * pageSize;
                cm.Parameters.Add(p);

                MySqlDataReader rd = cm.ExecuteReader();
                dt.Load(rd);
                rd.Close();
            }

            return dt;
        }
    }
}