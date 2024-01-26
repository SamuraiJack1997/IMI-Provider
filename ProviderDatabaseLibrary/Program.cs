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
        static void Main(string[] args)
        {
            
            Client c = new Client(1, "stefan123", "Stefan", "Aleksandric");
            ProviderMySQL provider = new ProviderMySQL();
            Console.WriteLine(provider);
            Console.WriteLine("Kreiran je lokalni user:"+c);

            Console.WriteLine("Klijenti iz baze:");
            IClient db;
            db = ClientFactory.Provider("MySQL");
            List<Client> clients = new List<Client>();
            clients = db.getAllClients();
            foreach(var client in clients)
            {
                Console.WriteLine(client.ToString());
            }
        }
    }
}
