using ProviderDatabaseLibrary.PlanStrategyBridge.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Package.Paketi
{
    internal class InternetPlan : Plan
    {
        private IPlanDetailsStrategy detailsStrategy;

        public InternetPlan(IPlanImplementation implementation)
            : base(implementation)
        {
        }

        public override string GetFullInfo()
        {
            string basicInfo = implementation.GetBasicInfo();
            string details = detailsStrategy != null ? detailsStrategy.GetDetails() : "";
            return $"Internet Plan - {basicInfo}, {details}";
        }

        public override void SetDetailsStrategy(IPlanDetailsStrategy strategy)
        {
            detailsStrategy = strategy;
        }
    }
}
