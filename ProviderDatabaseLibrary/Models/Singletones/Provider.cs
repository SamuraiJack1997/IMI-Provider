using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Models.Singletones
{
    //Singleton
    public class Provider
    {
        private static Provider? providerInstance;

        private string? Name { get; set; }
        private string? ConnectionString { get; set; }
        private string? DatabaseType { get; set; }

        private Provider() { }

        public static Provider Instance
        {

            get
            {
                if (providerInstance == null)
                {
                    providerInstance = new Provider();
                }
                return providerInstance;
            }
        }

        public void setProviderData(string Name, string ConnectionString, string DatabaseType)
        {
            this.Name = Name;
            this.ConnectionString = ConnectionString;
            this.DatabaseType = DatabaseType;
        }

        public void setName(string Name)
        {
            this.Name = Name;
        }

        public string getName()
        {
            return Name;
        }

        public void setConnectionString(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }
        public string getConnectionString()
        {
            return ConnectionString;
        }

        public void setDatabaseType(string DatabaseType)
        {
            this.DatabaseType = DatabaseType;
        }

        public string getDatabaseType()
        {
            return DatabaseType;
        }

        public override string? ToString()
        {
            return "Database:" + DatabaseType + " Provider:" + Name + "\n" + "Connection string:" + ConnectionString;
        }
    }
}
