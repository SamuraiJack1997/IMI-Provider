using ProviderDatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Interfaces
{
    internal interface IClient
    {
        List<Client> getAllClients();
    }
}
