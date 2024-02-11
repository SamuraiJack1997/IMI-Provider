using ProviderDatabaseLibrary.PlanBridgeStrategy.Bridge;
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
    public class TV_Plan : Plan
    {
        private IPlanPriceStrategy priceStrategy;
        public int Channel_Number { get; set; }

        public TV_Plan(int iD, string name, float price, int internet_Plan_ID, int tV_Plan_ID, int combo_Plan_ID, int Channel_Number) : base(iD, name, price, internet_Plan_ID, tV_Plan_ID, combo_Plan_ID)
        {
            this.Channel_Number = Channel_Number;
        }

        public TV_Plan(int iD, string name, float price, int internet_Plan_ID, int tV_Plan_ID, int combo_Plan_ID)
            : base(iD, name, price, internet_Plan_ID, tV_Plan_ID, combo_Plan_ID){ }

        public TV_Plan(string name, int internet_Plan_ID, int tV_Plan_ID,int Channel_Number) 
            : base( name, internet_Plan_ID, tV_Plan_ID)
        {
            this.Channel_Number = Channel_Number;
            Combo_Plan_ID = 0;
            Implementation = new TvPlanImplementation(Channel_Number);
            Price =GetFullPrice();
        }

        public override string? ToString()
        {
            return base.ToString() + " Channels:" + Channel_Number;
        }

        public override float GetFullPrice()
        {

            SetPriceStrategy();

            float price  = priceStrategy != null ? priceStrategy.getPrice() : 0;
            return price;
        }

        public override void SetPriceStrategy()
        {
            priceStrategy = new TvPlanPriceStrategy(Implementation.getChannelNumber());
        }

        public static implicit operator string?(TV_Plan? v)
        {
            throw new NotImplementedException();
        }
    }
}
