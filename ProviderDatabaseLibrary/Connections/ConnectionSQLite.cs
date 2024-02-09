using ProviderDatabaseLibrary.Models.Singletones;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Connections
{
    public class ConnectionSQLite
    {
        private static SQLiteConnection _connection = null;
        public static SQLiteConnection Connection
        {
            get
            {
                Provider provider = Provider.Instance;
                if (_connection == null && provider.getConnectionString()!=null)
                {
                    _connection = new SQLiteConnection();
                    _connection.ConnectionString = provider.getConnectionString();
                }
                return _connection;
            }
        }
    }
}
