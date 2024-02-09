using ProviderDatabaseLibrary.PlanBridgeStrategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBridgeStrategy.Bridge
{
    public class ComboPlanImplementation : IPlanImplementation
    {
        private int downloadSpeed;
        private int uploadSpeed;
        private int channelNumber;

        public ComboPlanImplementation(int downloadSpeed, int uploadSpeed, int channelNumber)
        {
            this.downloadSpeed = downloadSpeed;
            this.uploadSpeed = uploadSpeed;
            this.channelNumber = channelNumber;
        }

        public int getUploadSpeed()
        {
            return uploadSpeed;
        }

        public int getChannelNumber()
        {
            return channelNumber;
        }

        public int getDownloadSpeed()
        {
            return downloadSpeed;
        }
    }
}
