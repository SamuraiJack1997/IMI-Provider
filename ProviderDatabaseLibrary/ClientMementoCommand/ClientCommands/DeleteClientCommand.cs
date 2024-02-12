using ProviderDatabaseLibrary.ClientMementoCommand.Interfaces;
using ProviderDatabaseLibrary.ClientMementoCommand.Models;
using ProviderDatabaseLibrary.Factories;
using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Models;
using ProviderDatabaseLibrary.Models.Singletones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.ClientMementoCommand.ClientCommands
{
    public class DeleteClientCommand : IClientCommand
    {                
        Provider provider = Provider.Instance;
        private IProvider? db;

        private readonly Client _client;
        private readonly ClientMemento _previousState;
        

        public ClientMemento getPreviousState()
        {
            return _previousState;
        }

        public DeleteClientCommand(Client client, ClientMemento previousState)
        {
            _client = client;
            _previousState = previousState;
        }
        
        public int Execute()
        {
            db = ProviderFactory.Provider(provider.getDatabaseType());
                        
            Console.WriteLine($"Updating client {_client.ID}...");

            _client.ID = db.getClientIdByUsername(_client.Username);
            _previousState.ID = db.getClientIdByUsername(_previousState.Username);
            _previousState.ActivatedPlans = db.getActivatedClientPlansByClientID(_client.ID);
            int result = db.removeClientByID(_client.ID);
            Console.WriteLine($"Client {_client.ID} deleted. New state: {_client}");
            return result;
        }
    }
}
