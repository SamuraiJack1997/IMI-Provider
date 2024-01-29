using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Models.Plans
{
    public class TV_Plan : Plan
    {
        public int Channel_Number { get; set; }

        public TV_Plan(int iD, string name, float price, int internet_Plan_ID, int tV_Plan_ID, int combo_Plan_ID, int Channel_Number) : base(iD, name, price, internet_Plan_ID, tV_Plan_ID, combo_Plan_ID)
        {
            this.Channel_Number = Channel_Number;
        }

        public override string? ToString()
        {
            return base.ToString() + " Channels:" + Channel_Number;
        }
    }
}
