using ProviderDatabaseLibrary.PlanBridgeStrategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBridgeStrategy.Bridge
{
    public class InternetPlanImplementation : IPlanImplementation
    {
        private int downloadSpeed;
        private int uploadSpeed;

        public InternetPlanImplementation(int downloadSpeed, int uploadSpeed)
        {
            this.downloadSpeed = downloadSpeed;
            this.uploadSpeed = uploadSpeed;
        }

        public int getUploadSpeed()
        {
            return uploadSpeed;

        }

        public int getChannelNumber()
        {
            return 0;
        }

        public int getDownloadSpeed()
        {
            return downloadSpeed;
        }


    }
}
