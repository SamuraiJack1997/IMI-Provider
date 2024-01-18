using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Queries;

namespace ProviderDatabaseLibrary
{
    internal class ClientFactory
    {
        public static IClient Provider(string database)
        {
            switch (database)
            {
                case "MySQL":
                    return new ClientMySQL();
                    break;
                case "SQLite":
                    return new ClientSQLite();
                    break;
                default:
                    return new ClientMySQL();
            }
        }
    }
}
