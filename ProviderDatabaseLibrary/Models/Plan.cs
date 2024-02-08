using ProviderDatabaseLibrary.PlanBridgeStrategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProviderDatabaseLibrary.Models
{
    public abstract class Plan
    {
   
        public IPlanImplementation implementation;
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
            else if(Internet_Plan_ID != 0 && TV_Plan_ID != 0 && Combo_Plan_ID !=0)
            {
                PlanType = "Combo Plan";
            }
            else if (Internet_Plan_ID == 0 && TV_Plan_ID == 0 && Combo_Plan_ID != 0)
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

        public abstract void setPlanPriceImplementation(IPlanImplementation implementation);
        public abstract float GetFullPrice();
        public abstract void SetPriceStrategy();
    }
}
