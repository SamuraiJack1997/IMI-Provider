using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderDatabaseLibrary.PlanStrategyBridge.Interface;

namespace ProviderDatabaseLibrary.Package.Bridge
{
    public class ComboPlanImplementation : IPlanImplementation
    {
        public string GetBasicInfo()
        {
            // Implementacija osnovnih podataka za Kombinovani paket
            return "Combined Package Basic Info";
        }
    }
}
