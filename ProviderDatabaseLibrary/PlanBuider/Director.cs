using ProviderDatabaseLibrary.PlanBuider;
using ProviderDatabaseLibrary.PlanBuider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBuider
{
    internal class Director
    {
    }
}


namespace ConsoleApp2.Builder
{
    public class Director
    {
        static PlanBuilder planBuilder = PlanBuilder.getPlanBuilder();


        public static APlanBuilder GetTVPlan()
        {
            planBuilder.reset();
            planBuilder.setName("");
            planBuilder.setPrice(1000);
            planBuilder.setTVPlan();

            return planBuilder.GetResult();
        }

        public static APlanBuilder GetInternetPlan()
        {
            planBuilder.reset();
            planBuilder.setName("");
            planBuilder.setPrice(1000);
            planBuilder.setInternetPlan();

            return planBuilder.GetResult();
        }

        public static APlanBuilder GetComboPlan()
        {
            planBuilder.reset();
            planBuilder.setName("");
            planBuilder.setPrice(1000);
            planBuilder.setComboPlan();

            return planBuilder.GetResult();
        }
    }
}