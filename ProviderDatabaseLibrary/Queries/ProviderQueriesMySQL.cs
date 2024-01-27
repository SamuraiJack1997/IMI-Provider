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
    public class ProviderQueriesMySQL : IProvider
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

        public List<Plan> getActivatedClientPlansByClientID(int clientID)
        {
            List<Plan> plans = new List<Plan>();
            _connection.Open();

            String query = @"
                            select Client_ID,Plan_ID,Name,Price,Internet_Plan_ID,TV_Plan_ID,Combo_Plan_ID
                            from Clients_Plans_Activated cp join Plans p on cp.Plan_ID=p.ID
                            where Client_ID=@clientID";
            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@clientID", clientID);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                plans.Add(new Plan(
                        int.Parse(reader["Plan_ID"].ToString()),
                        reader["Name"].ToString(),
                        float.Parse(reader["Price"].ToString()),
                        reader.IsDBNull(reader.GetOrdinal("Internet_Plan_ID")) ? 0 : int.Parse(reader["Internet_Plan_ID"].ToString()),
                        reader.IsDBNull(reader.GetOrdinal("TV_Plan_ID")) ? 0 : int.Parse(reader["TV_Plan_ID"].ToString()),
                        reader.IsDBNull(reader.GetOrdinal("Combo_Plan_ID")) ? 0 : int.Parse(reader["Combo_Plan_ID"].ToString())
                    ));
            }
            _connection.Close();
            return plans;
        }
    }
}
