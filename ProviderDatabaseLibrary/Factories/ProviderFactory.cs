using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Queries;

namespace ProviderDatabaseLibrary.Factories
{
    public class ProviderFactory
    {
        public static IProvider Provider(string database)
        {
            switch (database)
            {
                case "MySQL":
                    return new ProviderQueriesMySQL();
                case "SQLite":
                    return new ProviderQueriesSQLite();
                default:
                    return new ProviderQueriesMySQL();
            }
        }
    }
}
