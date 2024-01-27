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

namespace ProviderDatabaseLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            //Postavljanje informacija o bazi u singlton
            /*
            ProviderMySQL provider = ProviderMySQL.Instance;
            provider.setProviderData("SBB", @"Data Source=(localdb)\baza2; Initial Catalog = PROVIDER; Integrated Security = True");
            Console.WriteLine(provider.getConnectionString());

            Console.WriteLine("\nKlijenti iz baze:");
            //Primer koriscenja Factory pattern-a
            IProvider db;

            db = ProviderFactory.Provider("MySQL");
            List<Client> clients = new List<Client>();
            clients = db.getAllClients();
            foreach (var client in clients)
            {
                Console.WriteLine(client.ToString());
            }*/

        }
    }
}
