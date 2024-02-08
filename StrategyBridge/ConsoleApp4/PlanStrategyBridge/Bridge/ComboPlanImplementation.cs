using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderDatabaseLibrary.PlanStrategyBridge.Interface;

namespace ProviderDatabaseLibrary.Package.Bridge
{
    public class ComboPlanImplementation : IPlanImplementation
    {
        private int downloadSpeed;
        private int uploadSpeed;
        private int brojKanala;

        public ComboPlanImplementation(int downloadSpeed, int uploadSpeed, int brojKanala)
        {
            this.downloadSpeed = downloadSpeed;
            this.uploadSpeed = uploadSpeed;
            this.brojKanala = brojKanala;
        }

        public int dajBriznuUpload()
        {
            return uploadSpeed;

        }

        public int dajBrojKanala()
        {
           return brojKanala;
        }

        public int dajBrzinuDownload()
        {
            return downloadSpeed;
        }
    }
}
