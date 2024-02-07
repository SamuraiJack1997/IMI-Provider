using ProviderDatabaseLibrary.ClientMementoCommand.ClientCommands;
using ProviderDatabaseLibrary.ClientMementoCommand.Interfaces;
using ProviderDatabaseLibrary.ClientMementoCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Models
{
    public class ClientSingleton
    {
        private static ClientSingleton? clientSingletonInstance;
        public InsertClientCommand icc {get; set;}
        public UpdateClientCommand ucc { get; set; }
        //public DeleteClientCommand dcc { get; set; }
        public Client client { get; set; }
        public int ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Plan> ActivatedPlans { get; set; }

        public List<Plan> DeactivatedPlans { get; set; }

        public static ClientSingleton Instance
        {
            get
            {
                if (clientSingletonInstance == null)
                {
                    clientSingletonInstance = new ClientSingleton();
                }
                return clientSingletonInstance;
            }
        }

        public ClientSingleton() { }
        
        public override string? ToString()
        {
            return "Client(ID:" + ID + " Username:" + Username + " Name:" + Name + " Surname:" + Surname + ")";
        }

    }
}
