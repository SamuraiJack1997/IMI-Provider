using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderDatabaseLibrary.PlanStrategyBridge.Interface;

namespace ProviderDatabaseLibrary.Package.Strategy
{
    public class ComboDetailsStrategy : IPlanDetailsStrategy
    {
        public string GetDetails()
        {
            return "TV Package ID: 101, Internet Package ID: 201";
        }
        
    }
}
