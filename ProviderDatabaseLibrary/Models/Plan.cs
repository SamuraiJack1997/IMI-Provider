using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Models
{
    public class Plan
    {
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

        public string getPlanName()
        {
            string PlanName="";
            if (Internet_Plan_ID == 1)
            {
                PlanName = "Internet Plan";
            }
            else if (TV_Plan_ID == 1)
            {
                PlanName = "TV Plan";
            }
            else
            {
                PlanName = "Combo Plan";
            }
            return PlanName;
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
