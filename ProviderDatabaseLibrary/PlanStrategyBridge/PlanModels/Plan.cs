using ProviderDatabaseLibrary.PlanStrategyBridge.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Package.Paketi
{
    public abstract class Plan
    {
        protected IPlanImplementation implementation;

        protected Plan(IPlanImplementation implementation)
        {
            this.implementation = implementation;
        }

        public abstract string GetFullInfo();
        public abstract void SetDetailsStrategy(IPlanDetailsStrategy strategy);
    }
}
