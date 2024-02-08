using ProviderDatabaseLibrary.Connections;
using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Models;
using ProviderDatabaseLibrary.Models.Plans;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Reflection.PortableExecutable;
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
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
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
        public List<Plan> getAllPlans()
        {
            List<Plan> plans = new List<Plan>();
            if (_connection.State == ConnectionState.Open)
                _connection.Close();

            _connection.Open();

            String outerQuery = @"select * from Plans";
            SQLiteCommand outerCommand = new SQLiteCommand(outerQuery, _connection);
            SQLiteDataReader outerReader = outerCommand.ExecuteReader();
            try
            {
                int ID, Internet_Plan_ID, TV_Plan_ID, Combo_Plan_ID, Download_Speed, Upload_Speed, Channel_Number;
                string Name;
                float Price;

                while (outerReader.Read())
                {
                    ID = int.Parse(outerReader["ID"].ToString());
                    Name = outerReader["Name"].ToString();
                    Price = float.Parse(outerReader["Price"].ToString());
                    Internet_Plan_ID = outerReader.IsDBNull(outerReader.GetOrdinal("Internet_Plan_ID")) ? 0 : int.Parse(outerReader["Internet_Plan_ID"].ToString());
                    TV_Plan_ID = outerReader.IsDBNull(outerReader.GetOrdinal("TV_Plan_ID")) ? 0 : int.Parse(outerReader["TV_Plan_ID"].ToString());
                    Combo_Plan_ID = outerReader.IsDBNull(outerReader.GetOrdinal("Combo_Plan_ID")) ? 0 : int.Parse(outerReader["Combo_Plan_ID"].ToString());

                    String innerQuery = "";
                    SQLiteCommand innerCommand;
                    SQLiteDataReader innerReader;

                    if (Internet_Plan_ID != 0 && TV_Plan_ID == 0 && Combo_Plan_ID == 0)
                    {
                        innerQuery = @"select ip.Download_Speed,ip.Upload_Speed
                                    from Internet_Plan ip
                                    where ip.ID=@planID and ip.ID in(
	                                    select p.Internet_Plan_ID
	                                    from Plans p)";
                        innerCommand = new SQLiteCommand(innerQuery, _connection);
                        innerCommand.Parameters.AddWithValue("@planID", Internet_Plan_ID);
                        innerReader = innerCommand.ExecuteReader();
                        while (innerReader.Read())
                        {
                            Download_Speed = int.Parse(innerReader["Download_Speed"].ToString());
                            Upload_Speed = int.Parse(innerReader["Upload_Speed"].ToString());
                            plans.Add(new Internet_Plan(ID, Name, Price, Internet_Plan_ID, TV_Plan_ID, Combo_Plan_ID, Download_Speed, Upload_Speed));
                        }
                        innerReader.Close();
                    }
                    else if (Internet_Plan_ID == 0 && TV_Plan_ID != 0 && Combo_Plan_ID == 0)
                    {
                        innerQuery = @"select tp.Channel_Number
                                    from TV_Plan tp
                                    where tp.ID=@planID and tp.ID in(
	                                    select p.TV_Plan_ID
	                                    from Plans p)";
                        innerCommand = new SQLiteCommand(innerQuery, _connection);
                        innerCommand.Parameters.AddWithValue("@planID", TV_Plan_ID);
                        innerReader = innerCommand.ExecuteReader();
                        while (innerReader.Read())
                        {
                            Channel_Number = int.Parse(innerReader["Channel_Number"].ToString());
                            plans.Add(new TV_Plan(ID, Name, Price, Internet_Plan_ID, TV_Plan_ID, Combo_Plan_ID, Channel_Number));
                        }
                        innerReader.Close();
                    }
                    else if (Internet_Plan_ID == 0 && TV_Plan_ID == 0 && Combo_Plan_ID != 0)
                    {
                        innerQuery = @"select p.ID,p.Name,p.Price,p.Combo_Plan_ID,cp.Internet_Plan_ID,cp.TV_Plan_ID,ip.Download_Speed,ip.Upload_Speed,tp.Channel_Number
                                    from Plans p join Combo_Plan cp on p.Combo_Plan_ID=cp.ID
			                        join Internet_Plan ip on ip.ID=cp.Internet_Plan_ID
			                        join TV_Plan tp on tp.ID=cp.TV_Plan_ID
                                        where p.Combo_Plan_ID=@planID";
                        innerCommand = new SQLiteCommand(innerQuery, _connection);
                        innerCommand.Parameters.AddWithValue("@planID", Combo_Plan_ID);
                        innerReader = innerCommand.ExecuteReader();
                        while (innerReader.Read())
                        {
                            Internet_Plan_ID = int.Parse(innerReader["Internet_Plan_ID"].ToString());
                            TV_Plan_ID = int.Parse(innerReader["TV_Plan_ID"].ToString());
                            Download_Speed = int.Parse(innerReader["Download_Speed"].ToString());
                            Upload_Speed = int.Parse(innerReader["Upload_Speed"].ToString());
                            Channel_Number = int.Parse(innerReader["Channel_Number"].ToString());
                            plans.Add(new Combo_Plan(ID, Name, Price, Internet_Plan_ID, TV_Plan_ID, Combo_Plan_ID, Download_Speed, Upload_Speed, Channel_Number));
                        }
                        innerReader.Close();
                    }
                }
            }
            finally
            {
                outerReader.Close();
                _connection.Close();
            }

            return plans;
        }

        public List<Plan> getActivatedClientPlansByClientID(int clientID)
        {
            List<Plan> plans = new List<Plan>();
            _connection.Open();

            String query = @"
                            select Client_ID,Plan_ID,Name,Price,Internet_Plan_ID,TV_Plan_ID,Combo_Plan_ID
                            from Clients_Plans_Activated cp join Plans p on cp.Plan_ID=p.ID
                            where Client_ID=@clientID";
            SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            cmd.Parameters.AddWithValue("@clientID", clientID);
            SQLiteDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    int Plan_ID = int.Parse(reader["Plan_ID"].ToString());
                    string Name = reader["Name"].ToString();
                    float Price = float.Parse(reader["Price"].ToString());
                    int Internet_Plan_ID = reader.IsDBNull(reader.GetOrdinal("Internet_Plan_ID")) ? 0 : int.Parse(reader["Internet_Plan_ID"].ToString());
                    int TV_Plan_ID = reader.IsDBNull(reader.GetOrdinal("TV_Plan_ID")) ? 0 : int.Parse(reader["TV_Plan_ID"].ToString());
                    int Combo_Plan_ID = reader.IsDBNull(reader.GetOrdinal("Combo_Plan_ID")) ? 0 : int.Parse(reader["Combo_Plan_ID"].ToString());

                    if (Internet_Plan_ID != 0 && TV_Plan_ID == 0 && Combo_Plan_ID == 0)
                        plans.Add(new Internet_Plan(Plan_ID, Name, Price, Internet_Plan_ID, TV_Plan_ID, Combo_Plan_ID));
                    else if (Internet_Plan_ID == 0 && TV_Plan_ID != 0 && Combo_Plan_ID == 0)
                        plans.Add(new TV_Plan(Plan_ID, Name, Price, Internet_Plan_ID, TV_Plan_ID, Combo_Plan_ID));
                    else if (Internet_Plan_ID == 0 && TV_Plan_ID == 0 && Combo_Plan_ID != 0)
                        plans.Add(new Combo_Plan(Plan_ID, Name, Price, Internet_Plan_ID, TV_Plan_ID, Combo_Plan_ID));
                }
            }
            finally
            {
                reader.Close();
                _connection.Close();
            }

            return plans;
        }

        public int insertClient(string username, string name, string surname)
        {
            int rowsAffected = 0;
            _connection.Open();
            try
            {
                string usernameQuery = @"select * from clients where username=@username";
                SQLiteCommand cmd= new SQLiteCommand(usernameQuery, _connection);
                cmd.Parameters.AddWithValue("@username", username);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    string query = @"insert into clients(username,name,surname) values (@username,@name,@surname)";
                    cmd = new SQLiteCommand(query, _connection);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    rowsAffected = cmd.ExecuteNonQuery();
                }
                else
                {
                    reader.Close();
                    rowsAffected = 0;
                }
            }
            catch
            {
                rowsAffected = -1;
            }
            finally
            {
                _connection.Close();
            }
            return rowsAffected;
        }

        public int getClientIdByUsername(string username)
        {
            _connection.Open();
            int ID = -1;
            SQLiteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = @"select id from clients where username=@username";
            cmd.Parameters.AddWithValue("@username", username);
            SQLiteDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    ID=int.Parse(reader["ID"].ToString());
                }
            }
            finally
            {
                reader.Close();
                _connection.Close();
            }
            return ID;
        }

        public int removeClientByID(int clientID)
        {
            int affectedRows = -1;
            List<Client> clients = new List<Client>();
            _connection.Open();
            String query = @"delete from Clients_Plans_Activated where Client_ID=@clientID";
            SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            cmd.Parameters.AddWithValue("@clientID", clientID);
            int result = cmd.ExecuteNonQuery();
            if (result >= 0)
            {
                try
                {
                    query = @"delete from clients where id=@clientID";
                    cmd = new SQLiteCommand(query, _connection);
                    cmd.Parameters.AddWithValue("@clientID", clientID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        affectedRows = 1;
                    }
                    else
                    {
                        affectedRows = -1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occured while deleting client!");
                    affectedRows = -1;
                }
                finally
                {
                    _connection.Close();
                }
            }
            else
            {
                Console.WriteLine($"An error occured while deleting client!");
                _connection.Close();
                affectedRows = -1;
            }

            return affectedRows;
        }

        public int updateClientByID(int clientID, string username, string name, string surname)
        {
            int affectedRows = 0;
            List<Client> clients = new List<Client>();
            _connection.Open();

            try
            {
                String query = @"select * from clients where ID=@clientID";
                SQLiteCommand cmd = new SQLiteCommand(query, _connection);
                cmd.Parameters.AddWithValue("@clientID", clientID);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    query = @"UPDATE Clients SET Username = @username, Name = @name, Surname = @surname WHERE ID = @clientID";
                    cmd = new SQLiteCommand(query, _connection);
                    cmd.Parameters.AddWithValue("@clientID", clientID);
                    cmd.Parameters.AddWithValue("@username", clientID);
                    cmd.Parameters.AddWithValue("@name", clientID);
                    cmd.Parameters.AddWithValue("@surname", clientID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        affectedRows = 1;
                    }
                    else
                    {
                        affectedRows = -1;
                    }
                }
                else
                {
                    affectedRows = -1;
                }
            }
            catch
            {
                Console.WriteLine($"An error occured while deleting client!");
                affectedRows = -1;
            }
            finally
            {
                _connection.Close();
            }

            return affectedRows;
        }

        public int insertClientPlanByClientID(int clientID, int planID)
        {
            throw new NotImplementedException();
        }
    }
}

