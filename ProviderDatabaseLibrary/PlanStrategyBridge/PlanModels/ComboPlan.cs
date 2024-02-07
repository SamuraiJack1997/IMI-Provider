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

        public ComboPlan(IPlanImplementation implementation)
            : base(implementation)
        {
        }

        public override string GetFullInfo()
        {
            string basicInfo = implementation.GetBasicInfo();
            string details = detailsStrategy != null ? detailsStrategy.GetDetails() : "";
            return $"Combo Plan - {basicInfo}, {details}";
        }

        public override void SetDetailsStrategy(IPlanDetailsStrategy strategy)
        {
            detailsStrategy = strategy;
        }
    }
}
