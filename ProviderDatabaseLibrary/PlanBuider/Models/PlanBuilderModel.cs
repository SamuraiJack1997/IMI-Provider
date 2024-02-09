using ProviderDatabaseLibrary.Factories;
using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Models.Plans;
using ProviderDatabaseLibrary.Models.Singletones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.PlanBuider.Models
{
    
    public class PlanBuilderModel
    {


        private string name;
        private int internetPlanID;
        private int tVPlanID;
        private int downloadSpeed;
        private int uploadSpeed;
        private int channelNumber;

        public string Name { get => name; set => name = value; }
        public int InternetPlanID { get => internetPlanID; set => internetPlanID = value; }
        public int TVPlanID { get => tVPlanID; set => tVPlanID = value; }
        public int DownloadSpeed { get => downloadSpeed; set => downloadSpeed = value; }
        public int UploadSpeed { get => uploadSpeed; set => uploadSpeed = value; }
        public int ChannelNumber { get => channelNumber; set => channelNumber = value; }


        public PlanBuilderModel() {
            InternetPlanID = 0;
            TVPlanID = 0;
            DownloadSpeed = 0;
            UploadSpeed = 0;
            ChannelNumber = 0;
        }

        public Plan ExecutePlanCreation()
        {
            Provider provider = Provider.Instance;
            IProvider db=ProviderFactory.Provider(provider.getDatabaseType());

            Plan plan=null;
            if (TVPlanID != 0 && InternetPlanID==0)//TV PLAN
            {
                plan = new TV_Plan(Name, InternetPlanID,TVPlanID,channelNumber);
            }
            else if (TVPlanID == 0 && InternetPlanID != 0)//INTERNET PLAN
            {
                plan = new Internet_Plan(Name, InternetPlanID, TVPlanID, downloadSpeed,uploadSpeed);
            }
            else if (TVPlanID != 0 && InternetPlanID != 0)//COMBO PLAN//On pravi planove sa pravim id-evima iz baze
            {
                plan = new Combo_Plan(Name, InternetPlanID, TVPlanID, downloadSpeed, uploadSpeed,channelNumber);
            }
            return plan;
        }
    }
}
