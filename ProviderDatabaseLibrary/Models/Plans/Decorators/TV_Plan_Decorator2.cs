using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Models.Plans.Decorators
{
    public class TV_Plan_Decorator2 : TV_Plan
    {
        private readonly TV_Plan plan;
        public TV_Plan_Decorator2(TV_Plan plan) : base(plan.ID, plan.Name, plan.Price, plan.Internet_Plan_ID, plan.TV_Plan_ID, plan.Combo_Plan_ID, plan.Channel_Number)
        {
            this.plan = plan;
        }

        public override string ToString()
        {
            return $"TV PLAN: " + plan.Name + "\nMesecna naknada: " + plan.Price + " din.";
        }
    }
}
