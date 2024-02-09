using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBuider.Interfaces
{
    public interface IBuilder
    {
        public void setName(String name);
        public void setPrice(int price);
        public void setDownloadSpeed(int uSpeed);
        public void setUploadSpeed(int dSpeed);
        public void setChannelNumber(int channels);
        public void setInternetPlanID(int ID);
        public void setTVPlanID(int ID);
    }
}
