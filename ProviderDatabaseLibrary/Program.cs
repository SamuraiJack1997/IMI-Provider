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
using ProviderDatabaseLibrary.Package.Bridge;
using ProviderDatabaseLibrary.Package.Paketi;
using ProviderDatabaseLibrary.Package.Strategy;
using ProviderDatabaseLibrary.PlanStrategyBridge.Interface;

namespace ProviderDatabaseLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IProvider db;
            Provider provider = Provider.Instance;
            provider.setProviderData("MTS", @"Data Source=C:\Users\aleks\Desktop\DS_Projekat\PROVIDER.db;", "SQLite");
            IPlanImplementation tvImplementation = new TvPlanImplementation();
            IPlanImplementation internetImplementation = new InternetPlanImplementation();
            IPlanImplementation combinedImplementation = new ComboPlanImplementation();

            // Kreiranje konkretnih paketa koristeći Bridge pattern
            Package tvPackage = new TvPackage(tvImplementation);
            Package internetPackage = new InternetPlan(internetImplementation);
            Package combinedPackage = new ComboPlan(combinedImplementation);

            // Kreiranje konkretnih strategija za dodatne detalje paketa
            IPlanDetailsStrategy tvDetailsStrategy = new TvChannelsDetailsStrategy();
            IPlanDetailsStrategy internetDetailsStrategy = new InternetSpeedDetailsStrategy();
            IPlanDetailsStrategy combinedDetailsStrategy = new ComboDetailsStrategy();

            // Postavljanje strategija za pakete koristeći Strategy pattern
            tvPackage.SetDetailsStrategy(tvDetailsStrategy);
            internetPackage.SetDetailsStrategy(internetDetailsStrategy);
            combinedPackage.SetDetailsStrategy(combinedDetailsStrategy);

            // Prikaz informacija o paketima
            Console.WriteLine(tvPackage.GetFullInfo());
            Console.WriteLine(internetPackage.GetFullInfo());
            Console.WriteLine(combinedPackage.GetFullInfo());

        }
    }
}
