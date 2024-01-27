using ProviderDatabaseLibrary.Connections;
using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Queries
{
    public class ProviderQueriesSQLite : IProvider
    {
        private SQLiteConnection _connection = ConnectionSQLite.Connection;
        public List<Client> getAllClients()
        {
            List<Client> clients = new List<Client>();
            _connection.Open();

            SQLiteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = @"select * from Clients";
            SQLiteDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    clients.Add(new Client(
                     int.Parse(reader["ID"].ToString()),
                     reader["Username"].ToString(),
                     reader["Name"].ToString(),
                     reader["Surname"].ToString()
                     ));
                }
            }
            finally
            {
                reader.Close();
                _connection.Close();
            }
            return clients;
        }

        public List<Plan> getActivatedClientPlansByClientID(int clientID)
        {
            List<Plan> plans = new List<Plan>();
            _connection.Open();

            SQLiteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = @"
                            select Client_ID,Plan_ID,Name,Price,Internet_Plan_ID,TV_Plan_ID,Combo_Plan_ID
                            from Clients_Plans_Activated cp join Plans p on cp.Plan_ID=p.ID
                            where Client_ID=@clientID";
            cmd.Parameters.AddWithValue("@clientID", clientID);
            SQLiteDataReader reader = cmd.ExecuteReader();
            try
            {
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
            }
            finally
            {
                reader.Close();
                _connection.Close();
            }
            return plans;
        }
    }
}
