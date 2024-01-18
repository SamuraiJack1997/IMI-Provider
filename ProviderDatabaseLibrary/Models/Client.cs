using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProviderDatabaseLibrary.Models
{
    internal class Client
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Client(int iD, string userName, string name, string surname)
        {
            ID = iD;
            UserName = userName;
            Name = name;
            Surname = surname;
        }

        public int getID()
        {
            return ID;
        }

        public string getUserName()
        {
            return UserName;
        }

        public string getName()
        {
            return Name;
        }

        public string getSurname()
        {
            return Surname;
        }

        public override string? ToString()
        {
            return "Client(ID:"+ID+" Username:"+UserName+" Name:"+Name+" Surname:"+Surname+")";
        }
    }
}
