using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderDatabaseLibrary.PlanStrategyBridge.Interface;

namespace ProviderDatabaseLibrary.Package.Bridge
{
    public class InternetPlanImplementation : IPlanImplementation
    {
        public string GetBasicInfo()
        {
            // Implementacija osnovnih podataka za Internet paket
            return "Internet Package Basic Info";
        }
    }
}
