using ProviderDatabaseLibrary.Models.Singletones;
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
        Provider provider = Provider.Instance;
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
            float price = downloadSpeed * provider.getDownloadPrice() + uploadSpeed * provider.getUploadPrice() + channelNumber * provider.getChannelPrice();
            price = price - price*1/5;
            return price;
        }

    }
}
