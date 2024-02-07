using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderDatabaseLibrary.PlanStrategyBridge.Interface;

namespace ProviderDatabaseLibrary.Package.Bridge
{
    public class TvPlanImplementation : IPlanImplementation
    {
        public string GetBasicInfo()
        {
            // Implementacija osnovnih podataka za TV paket
            return "TV Package Basic Info";
        }
    }
}
