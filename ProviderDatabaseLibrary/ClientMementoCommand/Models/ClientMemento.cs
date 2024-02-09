using ProviderDatabaseLibrary.Models.Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.ClientMementoCommand.Models
{
    public class ClientMemento
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Plan> ActivatedPlans { get; set; }

        public List<Plan> DeactivatedPlans { get; set; }

        public ClientMemento(int iD, string username, string name, string surname,List<Plan> activatedPlans)
        {
            ID = iD;
            Username = username;
            Name = name;
            Surname = surname;
            ActivatedPlans = activatedPlans;
            DeactivatedPlans = new List<Plan>();
        }        
        
    }
}
