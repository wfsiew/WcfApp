using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WcfApp.Db;
using WcfApp.Model;

namespace WcfApp.Service
{
    public class CarService : ICarService
    {
        private const string ConnectionStr = "server=0222f8b2-6308-478d-ae87-a11200cef3be.mysql.sequelizer.com;database=db0222f8b26308478dae87a11200cef3be;uid=lycddawsjcjbpvvs;pwd=hyjz8wRVMfGqnrxvR3EfbiWjDaXkA72Lh26fuLrfpsCbALFfQbtQuTR8J857FFtP";

        public List<CarRecord> GetCars(int page, int pageSize)
        {
            DbLayer db = new DbLayer();
            db.OpenConnection(ConnectionStr);
            DataTable dt = db.GetCars(page, pageSize);
            db.CloseConnection();

            List<CarRecord> ls = new List<CarRecord>();
            DataTableReader rd = dt.CreateDataReader();

            while (rd.Read())
            {
                ls.Add(new CarRecord {
                    ID = (int) rd["ID"],
                    Make = (string) rd["Make"],
                    Model = (string) rd["Model"],
                    Year = (int) rd["Year"],
                    Doors = (int) rd["Doors"],
                    Colours = (string) rd["Colour"],
                    Price = (double) rd["Price"]
                });
            }

            return ls;
        }
    }
}