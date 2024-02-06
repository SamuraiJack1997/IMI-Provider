using ProviderDatabaseLibrary.Models;
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
                if (_connection == null)
                    _connection = new SQLiteConnection(@""+ provider.getConnectionString()+"" );
                return _connection;
            }
        }
    }
}
