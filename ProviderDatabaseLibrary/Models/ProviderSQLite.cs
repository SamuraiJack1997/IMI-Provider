using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Models
{
    internal class ProviderSQLite
    {
        private string Name { get; set; }
        private string ConnectionString { get; set; }

        public ProviderSQLite()
        {
            //ProviderDatabaseLibrary\bin\Debug\net8.0\config.txt
            string filePath = "config.txt";
            string absolutePath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            try
            {
                string[] lines = File.ReadAllLines(absolutePath);

                Name = lines[0];
                ConnectionString = lines[1];

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"The file {filePath} does not exist.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
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
            return "Provider:" + Name + "\n" + "Connection string:" + ConnectionString;
        }
    }
}
