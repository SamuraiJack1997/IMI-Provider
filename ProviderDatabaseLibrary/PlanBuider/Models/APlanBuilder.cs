using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBuider.Models
{
    public class APlanBuilder
    {
        public int ID;
        public String name;
        public int price;

        public APlanBuilder()
        {
        }

        public APlanBuilder(int ID, String name, int price)
        {
            this.ID = ID;
            this.name = name;
            this.price = price;
        }

        public void SetPlan()
        { 
            throw new NotImplementedException();
        }
    }
}
