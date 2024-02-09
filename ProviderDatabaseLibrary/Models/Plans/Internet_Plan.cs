using ProviderDatabaseLibrary.PlanBridgeStrategy.Bridge;
using ProviderDatabaseLibrary.PlanBridgeStrategy.Interfaces;
using ProviderDatabaseLibrary.PlanBridgeStrategy.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Models.Plans
{
    public class Internet_Plan : Plan
    {
        private IPlanPriceStrategy priceStrategy;
        public int Download_Speed { get; set; }
        public int Upload_Speed { get; set; }

        public Internet_Plan(int iD, string name, float price, int internet_Plan_ID, int tV_Plan_ID, int combo_Plan_ID, int Download_Speed, int Upload_Speed) 
            : base(iD, name, price, internet_Plan_ID, tV_Plan_ID, combo_Plan_ID)
        {
            this.Download_Speed = Download_Speed;
            this.Upload_Speed = Upload_Speed;
        }

        public Internet_Plan(int iD, string name, float price, int internet_Plan_ID, int tV_Plan_ID, int combo_Plan_ID)
            : base(iD, name, price, internet_Plan_ID, tV_Plan_ID, combo_Plan_ID) { }

        public Internet_Plan(string name, int internet_Plan_ID, int tV_Plan_ID, int Download_Speed, int Upload_Speed)
            : base(name, internet_Plan_ID, tV_Plan_ID)
        {
            this.Download_Speed= Download_Speed;
            this.Upload_Speed= Upload_Speed;
            Combo_Plan_ID = 0;
            Implementation = new InternetPlanImplementation(Download_Speed, Upload_Speed);
            Price = GetFullPrice();
        }
        public override string? ToString()
        {
            return base.ToString() + " Download:" + Download_Speed + " Upload:" + Upload_Speed;
        }

        public override  float GetFullPrice()
        {
            SetPriceStrategy();
            float price = priceStrategy != null ? priceStrategy.getPrice() : 0;
            return price;
        }

        public override void SetPriceStrategy()
        {
            priceStrategy = new InternetPlanPriceStrategy(Implementation.getDownloadSpeed(), Implementation.getUploadSpeed());
        }
    }
}
