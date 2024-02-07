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
       
        public int internetPrice;
        public int internetDownload;
        public int internetUpload;
        public void enterValues(int internetDownload,int internetUpload)
        {
            this.internetDownload = internetDownload;
            this.internetUpload= internetUpload;
        }
        public string GetDetails()
        {
            return "Internet Speed: Download: " + internetDownload + " Upload: " + internetUpload;
        }
    }
    
    
}
