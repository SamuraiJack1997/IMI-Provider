using ProviderDatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Interfaces
{
    public interface IProvider
    {
        List<Client> getAllClients();
        List<Plan> getActivatedClientPlansByClientID(int clientID);
    }
}
