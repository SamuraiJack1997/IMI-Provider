using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Factories;
using ProviderDatabaseLibrary.Models.Plans;
using ProviderDatabaseLibrary.PlanBridgeStrategy.Bridge;
using ProviderDatabaseLibrary.PlanBridgeStrategy.Interfaces;
using ProviderDatabaseLibrary.PlanBuider.Models;
using ProviderDatabaseLibrary.PlanBuider;
using ProviderDatabaseLibrary.Models.Singletones;

namespace ProviderDatabaseLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //////////////////PRIMER POZIVA BAZE I SETOVANJE PARAMETARA
            
            IProvider db;
            Provider provider = Provider.Instance;
            provider.setProviderData("MTS", @"Data Source=C:\Users\aleks\Desktop\DS_Projekat\PROVIDER.db;", "SQLite");
            //provider.setProviderData("SBB", @"Data Source=(localdb)\baza2; Initial Catalog = PROVIDER; Integrated Security = True; MultipleActiveResultSets=True;", "MySQL");
            db = ProviderFactory.Provider(provider.getDatabaseType());

            //PRIMER KORISCENJA BRIDGE/STRATEGY
            /*
            IPlanImplementation tvImplementation = new TvPlanImplementation(4);
            Plan tvPlan = new TV_Plan(0, "ime", 0, 0, 0, 0);
            tvPlan.setPlanPriceImplementation(tvImplementation);

            IPlanImplementation internetImplementation = new InternetPlanImplementation(100, 100);
            Plan internetPlan = new Internet_Plan( 0, "ime", 0, 0, 0, 0);
            internetPlan.setPlanPriceImplementation(internetImplementation);

            IPlanImplementation comboImplementation = new ComboPlanImplementation(150, 250, 20);//iz modela kupi podatke
            Plan comboPlan = new Combo_Plan( 0, "ime", 0, 0, 0, 0);
            comboPlan.setPlanPriceImplementation(comboImplementation);

            Console.WriteLine(tvPlan.ToString());
            Console.WriteLine(internetPlan.ToString());
            Console.WriteLine(comboPlan.ToString());
            */

            /////////////////////////////////////////////PRIMER KORISCENJA BUILDERA
            PlanBuilderModel tvPlan = Director.SetTVPlan("TV 101", 1, 101);///////1 je za proveru da li je plan
            PlanBuilderModel internetPlan = Director.SetInternetPlan("NET Plan", 1, 100,100);////////////1 je za proveru da li je plan,uvek se salje
            PlanBuilderModel comboPlan = Director.SetComboPlan("COMBO Plan", 1,1, 100,100,100);////////////umesto 1 i 1 ide pravi id iz baze za tv ili net plan

            Plan plan1 = tvPlan.ExecutePlanCreation();//kada se okine funkcija za ExecutePlanCreation on izracuna cenu za taj plan
            Plan plan2 = internetPlan.ExecutePlanCreation();
            Plan plan3 = comboPlan.ExecutePlanCreation();
            Console.WriteLine(plan1.Price);

            int rowsAffected1 = db.insertTVPlan((TV_Plan)plan1);
            int rowsAffected2 = db.insertInternetPlan((Internet_Plan)plan2);
            int rowsAffected3 = db.insertComboPlan((Combo_Plan)plan3);

        }
    }
}
