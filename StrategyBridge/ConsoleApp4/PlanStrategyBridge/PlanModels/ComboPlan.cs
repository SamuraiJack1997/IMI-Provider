using ProviderDatabaseLibrary.Package.Bridge;
using ProviderDatabaseLibrary.Package.Strategy;
using ProviderDatabaseLibrary.PlanStrategyBridge.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Package.Paketi
{
    internal class ComboPlan : Plan
    {
        private IPlanDetailsStrategy detailsStrategy;

        public ComboPlan(IPlanImplementation implementation, int id, string naziv) : base(implementation, id, naziv)
        {
        }

        public override float GetFullPrice()
        {
            SetDetailsStrategy();

            float cena = detailsStrategy != null ? detailsStrategy.dajCenu() : 0;
            return cena;
        }

        public override void SetDetailsStrategy()
        {
            detailsStrategy = new ComboDetailsStrategy(
                implementation.dajBrzinuDownload(), 
                implementation.dajBriznuUpload() ,  
                implementation.dajBrojKanala());
        }

    }
}
