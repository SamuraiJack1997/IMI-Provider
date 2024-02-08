using ProviderDatabaseLibrary.PlanBridgeStrategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBridgeStrategy.Strategy
{
    public class TvPlanPriceStrategy : IPlanPriceStrategy
    {
        private int channelNumber;

        public TvPlanPriceStrategy(int channelNumber)
        {
          this.channelNumber = channelNumber;
        }

        public float getPrice()
        {
            return channelNumber * 10; //TODO add price per channel
        }
    }
}
