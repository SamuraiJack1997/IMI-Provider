using ProviderDatabaseLibrary.ClientMementoCommand.Interfaces;
using ProviderDatabaseLibrary.ClientMementoCommand.Models;
using ProviderDatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.ClientMementoCommand.ClientCommands
{
    public class UpdateClientCommand : IClientCommand
    {
        Provider provider = Provider.Instance;

        private readonly Client _client;
        private readonly ClientMemento _previousState;
        

        public ClientMemento getPreviousState()
        {
            return _previousState;
        }

        public UpdateClientCommand(Client client, ClientMemento previousState)
        {
            _client = client;
            _previousState = previousState;
        }
        
        public void Execute()
        {
            // Perform the update operation
            Console.WriteLine($"Updating client {_client.ID}...");

            // For simplicity, let's assume the update operation involves changing the name
            _client.Name = "UpdatedName";            

            Console.WriteLine($"Client {_client.ID} updated. New state: {_client}");
        }
    }
}
