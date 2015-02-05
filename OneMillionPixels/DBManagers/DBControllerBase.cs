using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace DBManagers
{
    public class DBControllerBase : IDisposable
    {
        SqlCeConnection conn = null;

        public DBControllerBase()
        {
            conn = new SqlCeConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public SqlCeCommand CreateCommand()
        {
            return conn.CreateCommand();    
        }
    }
}
