﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Models.Plans.Decorators
{
    public class Combo_Plan_Decorator : Combo_Plan
    {
        private readonly Combo_Plan plan;
        public Combo_Plan_Decorator(Combo_Plan plan) : base(plan.ID, plan.Name, plan.Price, plan.Internet_Plan_ID, plan.TV_Plan_ID, plan.Combo_Plan_ID, plan.Download_Speed, plan.Upload_Speed, plan.Channel_Number)
        {
            this.plan = plan;
        }

        public override string ToString()
        {
            return $"COMBO PLAN: " + plan.Name + ". \nOvim planom dobijate: " + plan.Channel_Number + " kanala \nInternet brzine: "+plan.Download_Speed+"/"+plan.Upload_Speed+" mbps. \nMesecna naknada: " + plan.Price + "dinara.";
        }
    }
}
