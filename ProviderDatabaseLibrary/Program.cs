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
using ProviderDatabaseLibrary.PlanBuider.Models;
using ProviderDatabaseLibrary.PlanBuider;

namespace ProviderDatabaseLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* IProvider db;
             Provider provider = Provider.Instance;
             //provider.setProviderData("MTS", @"Data Source=C:\Users\aleks\Desktop\DS_Projekat\PROVIDER.db;", "SQLite");
             provider.setProviderData("SBB", @"Data Source=(localdb)\baza2; Initial Catalog = PROVIDER; Integrated Security = True","MySQL");
             //Primer povlacenja podataka
             db = ProviderFactory.Provider(provider.getDatabaseType());
             int vrednost=db.insertClient("Filip123", "Filip", "Aleksandric");
             Console.WriteLine("Vrednost:"+vrednost);
             int ID = db.getClientIdByUsername("Filip123");
             Console.WriteLine("ID pronadjen:" + ID);*/
            // Koristite Director za kreiranje plana
            PlanBuilderModel tvPlan = Director.SetTVPlan("TV Plan", 50, 100);

            // Ili koristite Director za kreiranje internet plana
            PlanBuilderModel internetPlan = Director.SetInternetPlan("Internet Plan", 40, 100, 20);

            // Ili koristite Director za kreiranje kombinovanog plana
            PlanBuilderModel comboPlan = Director.SetComboPlan("Combo Plan", 90, 1, 2);

            // Sada možete koristiti kreirane planove prema potrebi
            Console.WriteLine("TV Plan: " + tvPlan.Name + ", Price: $" + tvPlan.Price + ", Channels: " + tvPlan.ChannelNumber);
            Console.WriteLine("Internet Plan: " + internetPlan.Name + ", Price: $" + internetPlan.Price + ", Download Speed: " + internetPlan.DownloadSpeed + ", Upload Speed: " + internetPlan.UploadSpeed);
            Console.WriteLine("Combo Plan: " + comboPlan.Name + ", Price: $" + comboPlan.Price + ", Internet ID: " + comboPlan.InternetPlanID + ", TV ID: " + comboPlan.TVPlanID);

            // Ostatak koda...

        }
        
    }
}
