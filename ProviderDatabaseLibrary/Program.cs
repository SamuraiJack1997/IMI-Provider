using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using ProviderDatabaseLibrary.Models;
using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Factories;
using ProviderDatabaseLibrary.Models.Plans;

namespace ProviderDatabaseLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IProvider db;
            Provider provider = Provider.Instance;
            //provider.setProviderData("MTS", @"Data Source=C:\Users\aleks\Desktop\DS_Projekat\PROVIDER.db;", "SQLite");
            provider.setProviderData("SBB", @"Data Source=(localdb)\baza2; Initial Catalog = PROVIDER; Integrated Security = True","MySQL");
            //Primer povlacenja podataka
            db = ProviderFactory.Provider(provider.getDatabaseType());
            int vrednost=db.insertClient("Filip123", "Filip", "Aleksandric");
            Console.WriteLine("Vrednost:"+vrednost);
            int ID = db.getClientIdByUsername("Filip123");
            Console.WriteLine("ID pronadjen:" + ID);
        }
    }
}
