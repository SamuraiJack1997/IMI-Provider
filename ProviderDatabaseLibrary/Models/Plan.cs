using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Models
{
    public class Plan
    {
        private int v1;
        private string? v2;
        private string? v3;
        private string? v4;
        private string? v5;
        private string? v6;

        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int? Internet_Plan_ID {  get; set; }
        public int? TV_Plan_ID { get; set; }
        public int? Combo_Plan_ID { get; set; }
        public Plan(int iD, string name, float price, int internet_Plan_ID, int tV_Plan_ID, int combo_Plan_ID)
        {
            ID = iD;
            Name = name;
            Price = price;
            Internet_Plan_ID = internet_Plan_ID;
            TV_Plan_ID = tV_Plan_ID;
            Combo_Plan_ID = combo_Plan_ID;
        }

        public Plan(int v1, string? v2, string? v3, string? v4, string? v5, string? v6)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
        }

        public string getPlanType()
        {
            string PlanType="";
            if (Internet_Plan_ID !=0 && TV_Plan_ID==0 && Combo_Plan_ID==0)
            {
                PlanType = "Internet Plan";
            }
            else if (Internet_Plan_ID == 0 && TV_Plan_ID !=0 && Combo_Plan_ID == 0)
            {
                PlanType = "TV Plan";
            }
            else if(Internet_Plan_ID == 0 && TV_Plan_ID == 0 && Combo_Plan_ID !=0)
            {
                PlanType = "Combo Plan";
            }
            else
            {
                PlanType = "Neaktiviran plan";
            }
            return PlanType;
        }

        public override string? ToString()
        {
            return "ID plana:"+ID+" Name:"+Name+" Price:"+Price+" Tip plana:"+getPlanType();
        }
    }
}
