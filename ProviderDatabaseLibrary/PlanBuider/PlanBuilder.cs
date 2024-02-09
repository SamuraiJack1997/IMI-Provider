using ProviderDatabaseLibrary.PlanBuider.Interfaces;
using ProviderDatabaseLibrary.PlanBuider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBuider
{
    public class PlanBuilder: IBuilder
    {
        private PlanBuilderModel plan;

        private static readonly object kljuc = new object();

        public static PlanBuilder planBuilder = null;

        public static PlanBuilder getPlanBuilder()
        {
            if (planBuilder == null)
                lock (kljuc)
                    if (planBuilder == null)
                        planBuilder = new PlanBuilder();
            return planBuilder;
        }

        private PlanBuilder()
        {
            reset();
        }

        public void reset()
        {
            this.plan = new PlanBuilderModel();
        }

        public PlanBuilderModel GetResult()
        {
            return this.plan;
        }

        public void setName(string name)
        {
            plan.Name = name;
        }

        public void setPrice(int price)
        {
            plan.Price = price;
        }

        public void setChannelNumber(int channels)
        {
            plan.ChannelNumber = channels;
        }

        public void setInternetPlanID(int ID)
        {
            plan.InternetPlanID = ID;
        }

        public void setTVPlanID(int ID)
        {
            plan.TVPlanID = ID;
        }

        public void setDownloadSpeed(int dSpeed)
        {
            plan.DownloadSpeed = dSpeed;
        }

        public void setUploadSpeed(int uSpeed)
        {
            plan.UploadSpeed = uSpeed;
        }
    }
}
