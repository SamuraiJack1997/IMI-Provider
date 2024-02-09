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
    public class Director
    {
        static PlanBuilder planBuilder = PlanBuilder.getPlanBuilder();


        public static PlanBuilderModel SetTVPlan(String name, int price, int channels)
        {
            planBuilder.reset();
            planBuilder.setName(name);
            planBuilder.setPrice(price);
            planBuilder.setChannelNumber(channels);

            return planBuilder.GetResult();
        }

        public static PlanBuilderModel SetInternetPlan(String name, int price, int dSpeed, int uSpeed)
        {
            planBuilder.reset();
            planBuilder.setName(name);
            planBuilder.setPrice(price);
            planBuilder.setDownloadSpeed(dSpeed);
            planBuilder.setDownloadSpeed(uSpeed);

            return planBuilder.GetResult();
        }

        public static PlanBuilderModel SetComboPlan(String name, int price, int iID, int tvID)
        {
            planBuilder.reset();
            planBuilder.setName(name);
            planBuilder.setPrice(price);
            planBuilder.setInternetPlanID(iID);
            planBuilder.setTVPlanID(tvID);

            return planBuilder.GetResult();
        }
    }
}


