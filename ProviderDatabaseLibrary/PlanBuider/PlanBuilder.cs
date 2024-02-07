using ProviderDatabaseLibrary.PlanBuider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBuider
{
    public class PlanBuilder: Builder
    {
        private APlanBuilder plan;

        private static readonly object kljuc = new object();

        public static PlanBuilder planBuilder = null;

        public static PlanBuilder getPlanBuilder()
        {
            if (planBuilder == null)
                lock(kljuc)
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
            this.plan = new APlanBuilder();
        }

        public APlanBuilder GetResult()
        {
            return this.plan;
        }

        public void setName(string name)
        {
            plan.name = name;
        }

        public void setPrice(int price)
        {
            plan.price = price;
        }

        public void setInternetPlan()
        {
            throw new NotImplementedException();
        }

        public void setTVPlan()
        {
            throw new NotImplementedException();
        }

        public void setComboPlan()
        {
            throw new NotImplementedException();
        }
    }
}
