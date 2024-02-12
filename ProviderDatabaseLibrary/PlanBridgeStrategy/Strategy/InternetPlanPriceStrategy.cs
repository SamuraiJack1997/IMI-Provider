using ProviderDatabaseLibrary.Models.Singletones;
using ProviderDatabaseLibrary.PlanBridgeStrategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBridgeStrategy.Strategy
{
    public class InternetPlanPriceStrategy : IPlanPriceStrategy
    {
        Provider provider = Provider.Instance;
        private int downloadSpeed;
        private int uploadSpeed;

        public InternetPlanPriceStrategy(int internetDownload, int internetUpload)
        {
            this.downloadSpeed = internetDownload;
            this.uploadSpeed = internetUpload;
        }

        public float getPrice()
        {
            return downloadSpeed * provider.getDownloadPrice() + uploadSpeed * provider.getUploadPrice();
        }

    }
}

