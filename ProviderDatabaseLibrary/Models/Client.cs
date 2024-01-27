using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProviderDatabaseLibrary.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Plan> ActivatedPlans {  get; set; }

        public List<Plan> DeactivatedPlans { get; set; }

        public Client(int iD, string username, string name, string surname)
        {
            ID = iD;
            Username = username;
            Name = name;
            Surname = surname;
            ActivatedPlans = new List<Plan>();
            DeactivatedPlans = new List<Plan>();
        }

        public override string? ToString()
        {
            return "Client(ID:"+ID+" Username:"+ Username + " Name:"+Name+" Surname:"+Surname+")";
        }
    }
}
