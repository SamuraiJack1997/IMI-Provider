using ProviderDatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Connections
{
    //Singleton
    public class MySqlConnection
    {
        private static SqlConnection _connection = null;

        public static SqlConnection Connection
        {
            get
            {
                Provider provider = Provider.Instance;
                if (_connection == null && provider.getConnectionString() != null)
                {
                    _connection = new SqlConnection();
                    _connection.ConnectionString = provider.getConnectionString();
                }
                return _connection;
            }
        }
    }
}
