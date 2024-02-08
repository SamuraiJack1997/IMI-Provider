using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanStrategyBridge.Interface
{
    public interface IPlanImplementation
    {
        int dajBrojKanala();
       int dajBrzinuDownload();
        
       int dajBriznuUpload();
    }
}
