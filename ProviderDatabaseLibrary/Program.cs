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
using ProviderDatabaseLibrary.PlanBridgeStrategy.Bridge;
using ProviderDatabaseLibrary.PlanBridgeStrategy.Interfaces;

namespace ProviderDatabaseLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IProvider db;
            Provider provider = Provider.Instance;
            provider.setProviderData("MTS", @"Data Source=D:/Users/Kristina/Documents/GitHub/tim-10/PROVIDER.db;", "SQLite");
            provider.setProviderData("SBB", @"Data Source=(localdb)\baza; Initial Catalog = PROVIDER; Integrated Security = True; MultipleActiveResultSets=True;", "MySQL");
            db = ProviderFactory.Provider(provider.getDatabaseType());

            //Bridge Strategy Example
            IPlanImplementation tvImplementation = new TvPlanImplementation(4);
            Plan tvPlan = new TV_Plan(0, "ime", 0, 0, 0, 0);
            tvPlan.setPlanPriceImplementation(tvImplementation);

            IPlanImplementation internetImplementation = new InternetPlanImplementation(100, 100);
            Plan internetPlan = new Internet_Plan( 0, "ime", 0, 0, 0, 0);
            internetPlan.setPlanPriceImplementation(internetImplementation);

            IPlanImplementation comboImplementation = new ComboPlanImplementation(150, 250, 20);
            Plan comboPlan = new Combo_Plan( 0, "ime", 0, 0, 0, 0);
            comboPlan.setPlanPriceImplementation(comboImplementation);

            Console.WriteLine(tvPlan.ToString());
            Console.WriteLine(internetPlan.ToString());
            Console.WriteLine(comboPlan.ToString());

        }
    }
}
