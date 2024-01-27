using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Models
{
    //Singleton
    public class ProviderMySQL
    {
        private static ProviderMySQL? providerInstance;

        private string? Name { get; set; }
        private string? ConnectionString { get; set; }

        private ProviderMySQL() { }

        public static ProviderMySQL Instance
        {
            
            get
            {
                if (providerInstance == null)
                {
                    providerInstance = new ProviderMySQL();
                }
                return providerInstance;
            }
        }

        public void setProviderData(string Name,string ConnectionString)
        {
            this.Name = Name;
            this.ConnectionString = ConnectionString;
        }

        public string getName()
        {
            return Name;
        }

        public string getConnectionString()
        {
            return ConnectionString;
        }

        public override string? ToString()
        {
            return "Provider:"+Name+"\n"+"Connection string:"+ConnectionString;
        }
    }
}
