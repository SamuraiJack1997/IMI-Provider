using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBridgeStrategy.Interfaces
{
    public interface IPlanImplementation
    {
        public int getUploadSpeed();
        public int getChannelNumber();
        public int getDownloadSpeed();
    }
}
