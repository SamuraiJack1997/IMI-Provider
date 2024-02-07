using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBuider.Models
{
    internal class TVPlanBuilder : APlanBuilder
    {
        int TVPlanID;
        public TVPlanBuilder(int ID, string name, int price, int TVPlanID) : base(ID, name, price)
        {
            this.TVPlanID = TVPlanID;
        }

        public override void SetPlan()
        {
            throw new NotImplementedException();
        }
    }
}
