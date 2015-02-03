using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlServerCe;

namespace OneMillionPixels.Database
{
    public class DBController : IDisposable
    {
        SqlCeConnection conn = null;

        public DBController()
        {
            conn = new SqlCeConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public void TestCommand()
        {
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Customers ([Customer ID], [Company Name]) Values('NWIND', 'Northwind Traders')";

            cmd.ExecuteNonQuery();
        }
    }
}