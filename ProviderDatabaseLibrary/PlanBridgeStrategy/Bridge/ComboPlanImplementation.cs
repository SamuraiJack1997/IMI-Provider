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
        private int brojKanala;

        public ComboPlanImplementation(int downloadSpeed, int uploadSpeed, int brojKanala)
        {
            this.downloadSpeed = downloadSpeed;
            this.uploadSpeed = uploadSpeed;
            this.brojKanala = brojKanala;
        }

        public int getUploadSpeed()
        {
            return uploadSpeed;
        }

        public int getChannelNumber()
        {
            return brojKanala;
        }

        public int getDownloadSpeed()
        {
            return downloadSpeed;
        }
    }
}
