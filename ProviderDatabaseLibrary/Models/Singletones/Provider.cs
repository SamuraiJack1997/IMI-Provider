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

        private float Download_Price { get; set; }
        private float Upload_Price { get; set; }
        private float Channel_Price { get; set; }

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

        public void setDownloadPrice(float Download_Price)
        {
            this.Download_Price = Download_Price;
        }

        public float getDownloadPrice()
        {
            return Download_Price;
        }

        public void setUploadPrice(float Upload_Price)
        {
            this.Upload_Price = Upload_Price;
        }

        public float getUploadPrice()
        {
            return Upload_Price;
        }

        public void setChannelPrice(float Channel_Price)
        {
            this.Channel_Price = Channel_Price;
        }

        public float getChannelPrice()
        {
            return Channel_Price;
        }

        public override string? ToString()
        {
            return "Database:" + DatabaseType + " Provider:" + Name + "\n" + "Connection string:" + ConnectionString;
        }
    }
}
