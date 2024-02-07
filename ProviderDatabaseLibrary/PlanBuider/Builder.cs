using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBuider
{
    public interface Builder
    {
        public void setName(String name);
        public void setPrice(int price);
        public void setInternetPlan(int IPlanId);
        public void setTVPlan(int TVPlanId);
        public void setComboPlan(int ComboPlanId);
    }
}


