using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderDatabaseLibrary.PlanStrategyBridge.Interface;

namespace ProviderDatabaseLibrary.Package.Bridge
{
    public class TvPlanImplementation : IPlanImplementation
    {

        public int brojKanala;


        public TvPlanImplementation(int brojKanala) {
            this.brojKanala = brojKanala;
        }

        public int dajBriznuUpload()
        {
            throw new NotImplementedException();
        }

        public int dajBrojKanala()
        {
            return brojKanala;
        }

        public int dajBrzinuDownload()
        {
            throw new NotImplementedException();
        }

        
    }
}
