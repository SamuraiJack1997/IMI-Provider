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
        public int id;
        public string naziv;
        protected Plan(IPlanImplementation implementation, int id, string naziv)
        {
            this.implementation = implementation;
            this.id = id;
            this.naziv = naziv;
            
        }

    
        public abstract float GetFullPrice();
        public abstract void SetDetailsStrategy();
    }
}
