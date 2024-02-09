using ProviderDatabaseLibrary.PlanBuider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBuider
{
    public class Director
    {
        static PlanBuilder planBuilder = PlanBuilder.getPlanBuilder();

        public static PlanBuilderModel SetTVPlan(string name,int tv_plan_ID,int channelNumber)
        {
            planBuilder.reset();
            planBuilder.setName(name);
            planBuilder.setTVPlanID(tv_plan_ID);
            planBuilder.setChannelNumber(channelNumber);

            return planBuilder.GetResult();
        }

        public static PlanBuilderModel SetInternetPlan(string name, int internet_plan_id, int download_speed,int upload_speed)
        {
            planBuilder.reset();
            planBuilder.setName(name);
            planBuilder.setInternetPlanID(internet_plan_id);
            planBuilder.setDownloadSpeed(download_speed);
            planBuilder.setUploadSpeed(upload_speed);

            return planBuilder.GetResult();
        }

        public static PlanBuilderModel SetComboPlan(string name, int internet_plan_id, int tv_plan_ID, int download_speed, int upload_speed, int channelNumber)
        {
            planBuilder.reset();
            planBuilder.setName(name);
            planBuilder.setInternetPlanID(internet_plan_id);
            planBuilder.setTVPlanID(tv_plan_ID);
            planBuilder.setDownloadSpeed(download_speed);
            planBuilder.setUploadSpeed(upload_speed);
            planBuilder.setChannelNumber(channelNumber);

            return planBuilder.GetResult();
        }
    }
}
