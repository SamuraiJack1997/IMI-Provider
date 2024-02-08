using ProviderDatabaseLibrary.PlanBridgeStrategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBridgeStrategy.Bridge
{
    public class TvPlanImplementation : IPlanImplementation
    {

        public int channelNumber;


        public TvPlanImplementation(int channelNumber)
        {
            this.channelNumber = channelNumber;
        }

        public int getUploadSpeed()
        {
            return 0;

        }

        public int getChannelNumber()
        {
            return channelNumber;
        }

        public int getDownloadSpeed()
        {
            return 0;
        }


    }
}
