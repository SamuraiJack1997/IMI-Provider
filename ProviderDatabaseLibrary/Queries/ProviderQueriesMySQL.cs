using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProviderDatabaseLibrary.Connections;
using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Models;
using ProviderDatabaseLibrary.Models.Plans;

namespace ProviderDatabaseLibrary.Queries
{
    public class ProviderQueriesMySQL : IProvider
    {
        private SqlConnection _connection = MySqlConnection.Connection;

        public List<Client> getAllClients()
        {
            List<Client> clients = new List<Client>();
            if(_connection.State == ConnectionState.Open)
                _connection.Close();

            _connection.Open();

            String query = @"select * from Clients";
            SqlCommand cmd=new SqlCommand(query, _connection);
            SqlDataReader reader = cmd.ExecuteReader();
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
            finally {
                reader.Close();
                _connection.Close();
            }

            return clients;
        }

        public List<Plan> getAllPlans() { 
            List<Plan> plans = new List<Plan>();
            if (_connection.State == ConnectionState.Open)
                _connection.Close();

            _connection.Open();

            String outerQuery = @"select * from Plans";
            SqlCommand outerCommand = new SqlCommand(outerQuery, _connection);
            SqlDataReader outerReader = outerCommand.ExecuteReader();
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
                    SqlCommand innerCommand;
                    SqlDataReader innerReader;

                    if (Internet_Plan_ID!=0 && TV_Plan_ID==0 && Combo_Plan_ID==0)
                    {
                        innerQuery = @"select ip.Download_Speed,ip.Upload_Speed
                                    from Internet_Plan ip
                                    where ip.ID=@planID and ip.ID in(
	                                    select p.Internet_Plan_ID
	                                    from Plans p)";
                        innerCommand=new SqlCommand(innerQuery, _connection);
                        innerCommand.Parameters.AddWithValue("@planID", Internet_Plan_ID);
                        innerReader = innerCommand.ExecuteReader();
                        while (innerReader.Read())
                        {
                            Download_Speed = int.Parse(innerReader["Download_Speed"].ToString());
                            Upload_Speed = int.Parse(innerReader["Upload_Speed"].ToString());
                            plans.Add(new Internet_Plan(ID,Name,Price,Internet_Plan_ID,TV_Plan_ID,Combo_Plan_ID,Download_Speed,Upload_Speed)); 
                        }
                        innerReader.Close();
                    }
                    else if(Internet_Plan_ID == 0 && TV_Plan_ID != 0 && Combo_Plan_ID == 0)
                    {
                        innerQuery = @"select tp.Channel_Number
                                    from TV_Plan tp
                                    where tp.ID=@planID and tp.ID in(
	                                    select p.TV_Plan_ID
	                                    from Plans p)";
                        innerCommand = new SqlCommand(innerQuery, _connection);
                        innerCommand.Parameters.AddWithValue("@planID", TV_Plan_ID);
                        innerReader = innerCommand.ExecuteReader();
                        while (innerReader.Read())
                        {
                            Channel_Number = int.Parse(innerReader["Channel_Number"].ToString());
                            plans.Add(new TV_Plan(ID, Name, Price, Internet_Plan_ID, TV_Plan_ID, Combo_Plan_ID,Channel_Number));
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
                        innerCommand = new SqlCommand(innerQuery, _connection);
                        innerCommand.Parameters.AddWithValue("@planID", Combo_Plan_ID);
                        innerReader = innerCommand.ExecuteReader();
                        while (innerReader.Read())
                        {
                            Internet_Plan_ID = int.Parse(innerReader["Internet_Plan_ID"].ToString());
                            TV_Plan_ID = int.Parse(innerReader["TV_Plan_ID"].ToString());
                            Download_Speed = int.Parse(innerReader["Download_Speed"].ToString());
                            Upload_Speed = int.Parse(innerReader["Upload_Speed"].ToString());
                            Channel_Number = int.Parse(innerReader["Channel_Number"].ToString());
                            plans.Add(new Combo_Plan(ID, Name, Price, Internet_Plan_ID, TV_Plan_ID, Combo_Plan_ID,Download_Speed,Upload_Speed, Channel_Number));
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
            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@clientID", clientID);
            SqlDataReader reader = cmd.ExecuteReader();
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

                    if (Internet_Plan_ID != 0 && TV_Plan_ID==0 && Combo_Plan_ID==0)
                            plans.Add(new Internet_Plan(Plan_ID,Name,Price,Internet_Plan_ID,TV_Plan_ID,Combo_Plan_ID));
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
                SqlCommand cmd = new SqlCommand(usernameQuery, _connection);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    string query = @"insert into clients(username,name,surname) values (@username,@name,@surname)";
                    cmd = new SqlCommand(query, _connection);
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
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = @"select id from clients where username=@username";
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    ID = int.Parse(reader["ID"].ToString());
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
            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@clientID", clientID);
            int result= cmd.ExecuteNonQuery();
            if (result >=0)
            {
                try
                {
                    query = @"delete from clients where id=@clientID";
                    cmd = new SqlCommand(query, _connection);
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
                catch(Exception ex)
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

        public int updateClientByID(int clientID,string username,string name,string surname)
        {
            int affectedRows = 0;
            List<Client> clients = new List<Client>();
            _connection.Open();

            try
            {
            String query = @"select * from clients where ID=@clientID";
            SqlCommand cmd=new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@clientID", clientID);
            SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    query = @"UPDATE Clients SET Username = @username, Name = @name, Surname = @surname WHERE ID = @clientID";
                    cmd = new SqlCommand(query, _connection);
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

        public int insertTVPlan(TV_Plan plan)
        {
            int Plan_ID;
            bool planNumberExists = true;
            int rowsAffected = 0;
            _connection.Open();
            try
            {
                string checkTVPlans = @"select * from TV_Plan where Channel_Number=@Channel_Number";
                SqlCommand cmd = new SqlCommand(checkTVPlans, _connection);
                cmd.Parameters.AddWithValue("@Channel_Number", plan.Channel_Number);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    planNumberExists = false;
                    reader.Close();
                    string insertTVPlanQuery = @"insert into TV_Plan (Channel_Number) values(@Channel_Number)";
                    cmd = new SqlCommand(insertTVPlanQuery, _connection);
                    cmd.Parameters.AddWithValue("@Channel_Number", plan.Channel_Number);
                    rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        string getTVPlanID = @"select ID from TV_Plan where Channel_Number=(@Channel_Number)";
                        cmd = new SqlCommand(getTVPlanID, _connection);
                        cmd.Parameters.AddWithValue("@Channel_Number", plan.Channel_Number);
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        Plan_ID = reader.GetInt32(0);
                        reader.Close();

                        string checkPlanName = @"select * from Plans where Name=@Name";
                        cmd = new SqlCommand(checkPlanName, _connection);
                        cmd.Parameters.AddWithValue("@Name", plan.Name);
                        reader = cmd.ExecuteReader();
                        if (!reader.HasRows)
                        {
                            reader.Close();
                            string insertIntoPlans = @"insert into Plans (Name,Price,Internet_Plan_ID,TV_Plan_ID,Combo_Plan_ID) values (@PlanName,@Price,NULL,@Plan_ID,NULL)";
                            cmd = new SqlCommand(insertIntoPlans, _connection);
                            cmd.Parameters.AddWithValue("@PlanName", plan.Name);
                            cmd.Parameters.AddWithValue("@Price", plan.Price);
                            cmd.Parameters.AddWithValue("@Plan_ID", Plan_ID);
                            rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                rowsAffected = 1;
                            }
                            else
                            {
                                Console.WriteLine("Insert into PLANS table error!");
                                rowsAffected = -1;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Plan with the same name already exists!");
                            if(planNumberExists == false)
                            {
                                string deleteOnError = "delete from TV_PLAN where ID=@Plan_ID";
                                cmd=new SqlCommand(deleteOnError, _connection);
                                cmd.Parameters.AddWithValue("@Plan_ID", Plan_ID);
                                cmd.ExecuteNonQuery();
                            }
                            rowsAffected = 0;
                        } 
                    }
                    else
                    {
                        Console.WriteLine("Insert into TV_PLAN table error!");
                        rowsAffected = -1;
                    }
                }
                else
                {
                    Console.WriteLine("Plan with the same number of channels already exists!");
                    reader.Close();
                    rowsAffected = 0;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Database error!");
                Console.WriteLine(ex.ToString());
                rowsAffected = -1;
            }
            finally
            {
                _connection.Close();
            }
            return rowsAffected;
        }

        public int insertInternetPlan(Internet_Plan plan)
        {
            int Plan_ID;
            bool planNumberExists = true;
            int rowsAffected = 0;
            _connection.Open();
            try
            {
                string checkInternetPlans = @"select * from Internet_Plan where Download_Speed=(@Download_Speed) and Upload_Speed=(@Upload_Speed)";
                SqlCommand cmd = new SqlCommand(checkInternetPlans, _connection);
                cmd.Parameters.AddWithValue("@Download_Speed", plan.Download_Speed);
                cmd.Parameters.AddWithValue("@Upload_Speed", plan.Upload_Speed);
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    planNumberExists = false;
                    reader.Close();
                    string insertInternetPlanQuery = @"insert into Internet_Plan (Download_Speed, Upload_Speed) values(@Download_Speed, @Upload_Speed)";
                    cmd = new SqlCommand(insertInternetPlanQuery, _connection);
                    cmd.Parameters.AddWithValue("@Download_Speed", plan.Download_Speed);
                    cmd.Parameters.AddWithValue("@Upload_Speed", plan.Upload_Speed);
                    rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        string getInternetPlanID = @"select ID from Internet_Plan where Download_Speed=(@Download_Speed) and Upload_Speed=(@Upload_Speed)";
                        cmd = new SqlCommand(getInternetPlanID, _connection);
                        cmd.Parameters.AddWithValue("@Download_Speed", plan.Download_Speed);
                        cmd.Parameters.AddWithValue("@Upload_Speed", plan.Upload_Speed);
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        Plan_ID = reader.GetInt32(0);
                        reader.Close();

                        string checkPlanName = @"select * from Plans where Name=@Name";
                        cmd = new SqlCommand(checkPlanName, _connection);
                        cmd.Parameters.AddWithValue("@Name", plan.Name);
                        reader = cmd.ExecuteReader();
                        if (!reader.HasRows)
                        {
                            reader.Close();
                            string insertIntoPlans = @"insert into Plans (Name,Price,Internet_Plan_ID,TV_Plan_ID,Combo_Plan_ID) values (@PlanName,@Price,@Plan_ID,NULL,NULL)";
                            cmd = new SqlCommand(insertIntoPlans, _connection);
                            cmd.Parameters.AddWithValue("@PlanName", plan.Name);
                            cmd.Parameters.AddWithValue("@Price", plan.Price);
                            cmd.Parameters.AddWithValue("@Plan_ID", Plan_ID);
                            rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                rowsAffected = 1;
                            }
                            else
                            {
                                Console.WriteLine("Insert into PLANS table error!");
                                rowsAffected = -1;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Plan with the same name already exists!");
                            if (planNumberExists == false)
                            {
                                string deleteOnError = "delete from Internet_Plan where ID=@Plan_ID";
                                cmd = new SqlCommand(deleteOnError, _connection);
                                cmd.Parameters.AddWithValue("@Plan_ID", Plan_ID);
                                cmd.ExecuteNonQuery();
                            }
                            rowsAffected = 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Insert into INTERNET_PLAN table error!");
                        rowsAffected = -1;
                    }
                }
                else
                {
                    Console.WriteLine("Plan with the same download and upload speed already exists!");
                    reader.Close();
                    rowsAffected = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error!");
                Console.WriteLine(ex.ToString());
                rowsAffected = -1;
            }
            finally
            {
                _connection.Close();
            }
            return rowsAffected;
        }

        public int insertComboPlan(Combo_Plan plan)
        {
            int Plan_ID;
            int rowsAffected = 0;
            _connection.Open();
            try
            {
                string checkComboPlans = @"select ID from Combo_Plan where Internet_Plan_ID=(@Internet_Plan_ID) and TV_Plan_ID=(@TV_Plan_ID)";
                SqlCommand cmd = new SqlCommand(checkComboPlans, _connection);
                cmd.Parameters.AddWithValue("@Internet_Plan_ID", plan.Internet_Plan_ID);
                cmd.Parameters.AddWithValue("@TV_Plan_ID", plan.TV_Plan_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    Console.WriteLine("Combo plan with this combination of INTERNET_PLAN and TV_PLAN does not exist!");
                    reader.Close();
                    rowsAffected = -1;
                }
                else
                {
                    reader.Read();
                    Plan_ID = reader.GetInt32(0);
                    reader.Close();

                    string checkPlanName = @"select * from Plans where Name=@Name";
                    cmd = new SqlCommand(checkPlanName, _connection);
                    cmd.Parameters.AddWithValue("@Name", plan.Name);
                    reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        reader.Close();
                        string insertIntoPlans = @"insert into Plans (Name,Price,Internet_Plan_ID,TV_Plan_ID,Combo_Plan_ID) values (@PlanName,@Price,NULL,NULL,@Plan_ID)";
                        cmd = new SqlCommand(insertIntoPlans, _connection);
                        cmd.Parameters.AddWithValue("@PlanName", plan.Name);
                        cmd.Parameters.AddWithValue("@Price", plan.Price);
                        cmd.Parameters.AddWithValue("@Plan_ID", Plan_ID);
                        rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            rowsAffected = 1;
                        }
                        else
                        {
                            Console.WriteLine("Insert into PLANS table error!");
                            rowsAffected = -1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Plan with the same name already exists!");
                        rowsAffected = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error!");
                Console.WriteLine(ex.ToString());
                rowsAffected = -1;
            }
            finally
            {
                _connection.Close();
            }
            return rowsAffected;
        }

        public int activateClientPlanByClientID(int clientID, int planID)
        {
            int rowsAffected = 0;
            _connection.Open();
            try
            {
                string query = @"insert into Clients_Plans_Activated (Client_ID,Plan_ID) values (@clientID,@planID)";
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@clientID", clientID);
                cmd.Parameters.AddWithValue("@planID", planID);
                rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    Console.WriteLine("Plan is already activated for selected user!");
                    rowsAffected = 0;
                }
                else
                {
                    Console.WriteLine("Client plan activated successfully!");
                }
            }
            catch
            {
                Console.WriteLine("Error when activating client plan!");
                rowsAffected = -1;
            }
            finally
            {
                _connection.Close();
            }
            return rowsAffected;
        }

        public int deactivateClientPlanByClientID(int clientID,int planID)
        {
            int rowsAffected = 0;
            _connection.Open();
            try
            {
                string query = @"delete from Clients_Plans_Activated
                                    where Client_ID=@clientID and Plan_ID=@planID";
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@clientID", clientID);
                cmd.Parameters.AddWithValue("@planID", planID);
                rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    Console.WriteLine("No rows affected!");
                    rowsAffected = 0;
                }
                else
                {
                    Console.WriteLine("Successfully deleted plan for client!");
                }
            }
            catch
            {
                rowsAffected = -1;
                Console.WriteLine("Error when deleting plan for client!");
            }
            finally
            {
                _connection.Close();
            }
            return rowsAffected;
        }

        public int removeInternetPlan(Plan plan)
        {
            int rowsAffected = 0;
            string query1, query2, query3, query4, query5;

            query1 = @"delete from Clients_Plans_Activated
                        where Plan_ID in (select p.ID
                        from Plans p
                        where p.ID = @planID)";

            query2 = @"delete from Plans
                        where Combo_Plan_ID in (
                            select ID
                            from Combo_Plan
                            where Internet_Plan_ID = @internetPlanID)";

            query3 = @"delete from Combo_Plan
                        where Combo_Plan.Internet_Plan_ID = @internetPlanID";

            query4 = @" DELETE FROM Plans
                        WHERE id = @planID";

            query5 = @"DELETE FROM Internet_Plan
                            where ID = @internetPlanID";

            SqlCommand cmd1, cmd2,cmd3,cmd4,cmd5;
            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            try
            {
                cmd1 = new SqlCommand(query1, _connection, transaction);
                cmd1.Parameters.AddWithValue("@planID", plan.ID);
                cmd1.ExecuteNonQuery();

                cmd2 = new SqlCommand(query2, _connection, transaction);
                cmd2.Parameters.AddWithValue("@internetPlanID", plan.Internet_Plan_ID);
                cmd2.ExecuteNonQuery();

                cmd3 = new SqlCommand(query3, _connection, transaction);
                cmd3.Parameters.AddWithValue("@internetPlanID", plan.Internet_Plan_ID);
                cmd3.ExecuteNonQuery();

                cmd4 = new SqlCommand(query4, _connection, transaction);
                cmd4.Parameters.AddWithValue("@planID", plan.ID);
                cmd4.ExecuteNonQuery();

                cmd5 = new SqlCommand(query5, _connection, transaction);
                cmd5.Parameters.AddWithValue("@internetPlanID", plan.Internet_Plan_ID);
                cmd5.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("Transaction committed.");
                rowsAffected = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing transaction: " + ex.Message);
                try
                {
                    transaction.Rollback();
                    Console.WriteLine("Transaction rolled back.");
                }
                catch (Exception rollbackEx)
                {
                    Console.WriteLine("Rollback failed: " + rollbackEx.Message);
                }
                rowsAffected = -1;
            }
            finally
            {
                _connection.Close();
            }
            return rowsAffected;
        }

        public int removeTVPlan(Plan plan)
        {
            throw new NotImplementedException();
        }

        public int removeComboPlan(Plan plan)
        {
            throw new NotImplementedException();
        }
    }
}
