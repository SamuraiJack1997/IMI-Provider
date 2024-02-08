using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderDatabaseLibrary.PlanStrategyBridge.Interface;

namespace ProviderDatabaseLibrary.Package.Strategy
{
    public class ComboDetailsStrategy : IPlanDetailsStrategy
    {
        public int brojKanala;

        public int internetDownload;
        public int internetUpload;

        public ComboDetailsStrategy(int internetDownload, int internetUpload ,int brojKanala)
        {

            this.internetDownload = internetDownload;
            this.internetUpload = internetUpload;
            this.brojKanala = brojKanala;
        }

        public float dajCenu()
        {
            return internetDownload * 4 + internetUpload * 5+ brojKanala *10; //4 i 5,10 treba da budu neke globalne vrednosti cene;
        }

    }
}
