using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBManagers
{
    public class DBControllerBase : IDisposable
    {
        SqlConnection conn = null;

        public DBControllerBase()
        {
            conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public SqlCommand CreateCommand()
        {
            return conn.CreateCommand();    
        }
    }
}
