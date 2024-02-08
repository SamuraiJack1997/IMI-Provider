using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderDatabaseLibrary.PlanStrategyBridge.Interface;

namespace ProviderDatabaseLibrary.Package.Bridge
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

        public int dajBriznuUpload()
        {
            return uploadSpeed;
           
        }

        public int dajBrojKanala()
        {
            throw new NotImplementedException();
        }

        public int dajBrzinuDownload()
        {
            return downloadSpeed;
        }

       
    }
}
