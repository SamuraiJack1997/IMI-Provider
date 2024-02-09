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
    public class InsertClientCommand : IClientCommand
    {
        Provider provider = Provider.Instance;
        private IProvider db;        

        private readonly Client _client;
        private readonly ClientMemento _previousState;


        public ClientMemento getPreviousState()
        {
            return _previousState;
        }

        public InsertClientCommand(Client client, ClientMemento previousState)
        {            
            _client = client;
            _previousState = previousState;                
        }

        public int Execute()
        {
            
            // Perform the insert operation
            db = ProviderFactory.Provider(provider.getDatabaseType());
            
            Console.WriteLine($"Inserting client {_client.ID}...");

            // Inserting clients
            int result = db.insertClient(_client.Username, _client.Name, _client.Surname);
            _client.ID = db.getClientIdByUsername(_client.Username);
            _previousState.ID = db.getClientIdByUsername(_previousState.Username);            
            Console.WriteLine($"Client {_client.ID} inserted. New state: {_client}");
            return result;
        }
    }
}
