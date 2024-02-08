using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderDatabaseLibrary.PlanStrategyBridge.Interface;

namespace ProviderDatabaseLibrary.Package.Strategy
{
    public class InternetSpeedDetailsStrategy : IPlanDetailsStrategy
    {
       
        public int internetDownload;
        public int internetUpload;

        public InternetSpeedDetailsStrategy(int internetDownload, int internetUpload)
        {
           
            this.internetDownload = internetDownload;
            this.internetUpload = internetUpload;
        }

        public float dajCenu()
        {
            return internetDownload * 4 + internetUpload * 5; //4 i 5 treba da budu neke globalne vrednosti cene;
        }

    

       
      
    }
    
    
}
