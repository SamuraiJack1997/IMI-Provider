using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderDatabaseLibrary.Connections;
using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Models;

namespace ProviderDatabaseLibrary.Queries
{
    internal class ClientMySQL : IClient
    {
        private SqlConnection _connection = MySqlConnection.Connection;

        public List<Client> getAllClients()
        {
            List<Client> clients = new List<Client>();
            _connection.Open();

            String query = @"select * from Clients";
            SqlCommand cmd=new SqlCommand(query, _connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                clients.Add(new Client(
                    int.Parse(reader["ID"].ToString()),
                    reader["Username"].ToString(),
                    reader["Name"].ToString(),
                    reader["Surname"].ToString()
                    ));
            }
            _connection.Close();
            return clients;
        }

    }
}
