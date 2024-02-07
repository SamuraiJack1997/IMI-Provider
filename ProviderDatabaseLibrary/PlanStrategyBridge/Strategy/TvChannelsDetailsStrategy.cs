using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderDatabaseLibrary.PlanStrategyBridge.Interface;

namespace ProviderDatabaseLibrary.Package.Strategy
{
    public class TvChannelsDetailsStrategy : IPlanDetailsStrategy
    {
        public string GetDetails()
        {
            return "Number of Channels: 100";
        }
    }
}
