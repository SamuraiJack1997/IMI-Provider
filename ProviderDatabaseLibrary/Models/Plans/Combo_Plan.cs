using ProviderDatabaseLibrary.PlanBridgeStrategy.Interfaces;
using ProviderDatabaseLibrary.PlanBridgeStrategy.Strategy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Models.Plans
{
    internal class Combo_Plan : Plan
    {
        private IPlanPriceStrategy priceStrategy;
        public int Download_Speed { get; set; }
        public int Upload_Speed { get; set; }
        public int Channel_Number { get; set; }

        public Combo_Plan(int iD, string name, float price, int internet_Plan_ID, int tV_Plan_ID, int combo_Plan_ID, int Download_Speed, int Upload_Speed, int Channel_Number) 
            : base(iD, name, price, internet_Plan_ID, tV_Plan_ID, combo_Plan_ID)
        {
            this.Download_Speed = Download_Speed;
            this.Upload_Speed = Upload_Speed;
            this.Channel_Number = Channel_Number;
        }

        public Combo_Plan(int iD, string name, float price, int internet_Plan_ID, int tV_Plan_ID, int combo_Plan_ID)
            : base(iD, name, price, internet_Plan_ID, tV_Plan_ID, combo_Plan_ID){ }

        public override string? ToString()
        {
            return base.ToString() + " Download:" + Download_Speed + " Upload:" + Upload_Speed + " Channels:" + Channel_Number;
        }
        public override void setPlanPriceImplementation(IPlanImplementation implementation)
        {
            this.implementation = implementation;
            GetFullPrice();
        }
        public override float GetFullPrice()
        {
            SetPriceStrategy();

            float price = priceStrategy != null ? priceStrategy.getPrice() : 0;
            this.Price = price;
            return price;
        }

        public override void SetPriceStrategy()
        {
            priceStrategy = new ComboPlanPriceStrategy(
                implementation.getDownloadSpeed(),
                implementation.getUploadSpeed(),
                implementation.getChannelNumber());
        }
    }
}
