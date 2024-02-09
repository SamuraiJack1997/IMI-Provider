using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBuider.Models
{
    public class PlanBuilderModel
    {
        private String name;
        private int price;
        private int channelNumber;
        private int downloadSpeed;
        private int uploadSpeed;
        private int internetPlanID;
        private int tVPlanID;

        public String Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public int ChannelNumber { get => channelNumber; set => channelNumber = value; }
        public int DownloadSpeed { get => downloadSpeed; set => downloadSpeed = value; }
        public int UploadSpeed { get => uploadSpeed; set => uploadSpeed = value; }
        public int InternetPlanID { get => internetPlanID; set => internetPlanID = value; }
        public int TVPlanID { get => tVPlanID; set => tVPlanID = value; }


        public PlanBuilderModel()
        {
            this.channelNumber = 0;
            this.downloadSpeed = 0;
            this.uploadSpeed = 0;
            this.internetPlanID = 0;
            this.TVPlanID = 0;
        }

        public void ExecuteInsertPlanQuery()
        {
            if (this.channelNumber != 0)
            {

            }
            else if (this.downloadSpeed != 0)
            {

            }
            else if (this.internetPlanID != 0)
            {

            }
        }
    }
}
