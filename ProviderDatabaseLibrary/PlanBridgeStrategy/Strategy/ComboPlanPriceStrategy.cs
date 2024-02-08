using ProviderDatabaseLibrary.PlanBridgeStrategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBridgeStrategy.Strategy
{
    public class ComboPlanPriceStrategy : IPlanPriceStrategy
    {
        private int channelNumber;
        private int downloadSpeed;
        private int uploadSpeed;

        public ComboPlanPriceStrategy(int internetDownload, int internetUpload, int channelNumber)
        {

            this.channelNumber = channelNumber;
            this.downloadSpeed = internetDownload;
            this.uploadSpeed = internetUpload;
        }

        public float getPrice()
        {
            return downloadSpeed * 4 + uploadSpeed * 5 + channelNumber * 10; //4 i 5,10 treba da budu neke globalne vrednosti cene;
        }

    }
}
