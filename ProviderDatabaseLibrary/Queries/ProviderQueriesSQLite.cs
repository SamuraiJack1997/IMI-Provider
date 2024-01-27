using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Queries
{
    public class ProviderQueriesSQLite : IProvider
    {
        public List<Client> getAllClients()
        {
            throw new NotImplementedException();
        }

        public List<Plan> getActivatedClientPlansByClientID(int clientID)
        {
            throw new NotImplementedException();
        }
    }
}
