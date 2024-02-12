using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Models.Plans.Decorators
{
    public class Internet_Plan_Decorator1 : Internet_Plan
    {
        private readonly Internet_Plan plan;
        public Internet_Plan_Decorator1(Internet_Plan plan) : base(plan.ID, plan.Name, plan.Price, plan.Internet_Plan_ID, plan.TV_Plan_ID, plan.Combo_Plan_ID, plan.Download_Speed, plan.Upload_Speed)
        {
            this.plan = plan;
        }

        public override string ToString()
        {
            return $"INTERNET PLAN: " + plan.Name + "\nOvim planom dobijate internet brzine: "+plan.Download_Speed+"/"+plan.Upload_Speed+" mbps \nMesecna naknada: " + plan.Price + " din.";
        }
    }
}
