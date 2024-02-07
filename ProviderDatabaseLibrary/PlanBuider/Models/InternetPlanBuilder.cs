using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBuider.Models
{
    internal class InternetPlanBuilder : APlanBuilder
    {
        int internetPlanID;
        public InternetPlanBuilder(int ID, string name, int price, int internetPlanID) : base(ID, name, price)
        {
            this.internetPlanID = internetPlanID;
        }

        public override void SetPlan()
        {
            throw new NotImplementedException();
        }
    }
}
