using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
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

        public void InsertCar(Car o)
        {
            StringBuilder sb = new StringBuilder("insert into Car (Make, Model, Year, Doors, Colour, Price) values ")
            .Append("(@make, @model, @year, @doors, @colour, @price)");
            string q = sb.ToString();

            using (MySqlCommand cm = new MySqlCommand(q, Connection))
            {
                MySqlParameter p = new MySqlParameter("@make", MySqlDbType.String);
                p.Value = o.Make;
                cm.Parameters.Add(p);

                p = new MySqlParameter("@model", MySqlDbType.String);
                p.Value = o.Model;
                cm.Parameters.Add(p);

                p = new MySqlParameter("@year", MySqlDbType.Int32);
                p.Value = o.Year;
                cm.Parameters.Add(p);

                p = new MySqlParameter("@doors", MySqlDbType.Int32);
                p.Value = o.Doors;
                cm.Parameters.Add(p);

                p = new MySqlParameter("@colour", MySqlDbType.String);
                p.Value = o.Colour;
                cm.Parameters.Add(p);

                p = new MySqlParameter("@price", MySqlDbType.Double);
                p.Value = o.Price;
                cm.Parameters.Add(p);

                cm.ExecuteNonQuery();
            }
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