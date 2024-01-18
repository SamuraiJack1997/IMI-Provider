using ProviderDatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Connections
{
    internal class SQLiteConnection
    {
        private static ProviderSQLite provider;
        private static SqlConnection _connection = null;
        public static SqlConnection Connection
        {

            get
            {
                if (provider == null)
                {
                    provider = new ProviderSQLite();
                }
                if (_connection == null)
                    _connection = new SqlConnection(@"" + provider.getConnectionString() + "");
                return _connection;
            }
        }
    }
}
