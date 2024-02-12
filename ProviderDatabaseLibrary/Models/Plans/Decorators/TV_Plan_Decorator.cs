using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProviderDatabaseLibrary.Models.Plans.Decorators
{
    public class TV_Plan_Decorator : TV_Plan
    {
        private readonly TV_Plan plan;
        public TV_Plan_Decorator(TV_Plan plan): base(plan.ID, plan.Name, plan.Price, plan.Internet_Plan_ID, plan.TV_Plan_ID, plan.Combo_Plan_ID, plan.Channel_Number )
        {
            this.plan = plan;
        }

        public override string ToString()
        {
            return $"TV PLAN: "+plan.Name+".\nOvim planom dobijate: "+plan.Channel_Number+" kanala. \nMesecna naknada: " + plan.Price+"dinara.";
        }
    }

}
