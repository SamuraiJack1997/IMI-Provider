using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderDatabaseLibrary.PlanStrategyBridge.Interface;

namespace ProviderDatabaseLibrary.Package.Strategy
{
    public class TvChannelsDetailsStrategy : IPlanDetailsStrategy
    {
        int brojKanala;
        public TvChannelsDetailsStrategy(int brojKanala) 
        {
            this.brojKanala = brojKanala;
        
        }

        public float dajCenu()
        {
           return brojKanala*10;//10 treba da bude neka cena globalna
        }

       
    }
}
