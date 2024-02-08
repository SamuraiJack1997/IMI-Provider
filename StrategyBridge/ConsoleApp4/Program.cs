using ProviderDatabaseLibrary.Package.Bridge;
using ProviderDatabaseLibrary.Package.Paketi;
using ProviderDatabaseLibrary.PlanStrategyBridge.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPlanImplementation tvImplementation = new TvPlanImplementation(4);
            Plan tvPlan = new TVPlan(tvImplementation, 1, "prvi tv plan");
           
            Console.WriteLine(tvPlan.GetFullPrice());
           

            IPlanImplementation internetImplementation = new InternetPlanImplementation(100, 100);
            Plan internetPlan = new InternetPlan(internetImplementation, 2, "Internet plan");

            IPlanImplementation comboImp = new ComboPlanImplementation(150, 250, 20);
            Plan comboPlan = new ComboPlan(comboImp, 3, "combo");

            Console.WriteLine(internetPlan.GetFullPrice());
            Console.WriteLine(comboPlan.GetFullPrice());
           
            Console.ReadKey();
        }
    }
}
