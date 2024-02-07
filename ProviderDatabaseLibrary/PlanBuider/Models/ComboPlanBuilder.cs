using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBuider.Models
{
    internal class ComboPlanBuilder: APlanBuilder
    {
        int comboPlanID;
        public ComboPlanBuilder(int ID, string name, int price, int comboPlanID) : base(ID, name, price)
        {
            this.comboPlanID = comboPlanID;
        }

        public override void SetPlan()
        {
            throw new NotImplementedException();
        }
    }
}
