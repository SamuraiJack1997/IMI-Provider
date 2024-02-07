using ProviderDatabaseLibrary.ClientMementoCommand.ClientCommands;
using ProviderDatabaseLibrary.Factories;
using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProviderGUI
{
    public partial class Form2 : Form
    {
        private IProvider db;
        Provider provider = Provider.Instance;
        ClientSingleton clientSingleton = ClientSingleton.Instance;        
        InsertClientCommand insertClientCommand;
        Client insertedClient;
        UpdateClientCommand updateClientCommand;
        //DeleteClientCommand deleteClientCommand;

        public Form2()
        {
            InitializeComponent();
            this.Text = provider.getName();
            button3.Enabled = false;
            button4.Enabled = false;
            InitDataGridView1();
        }

        private void lockForm()
        {
            foreach (Control control in this.Controls) { control.Enabled = false; }
        }
        private void unlockForm()
        {
            foreach (Control control in this.Controls) { control.Enabled = true; }
        }

        private void refresh()
        {
            button3.Enabled = false;
            InitDataGridView1();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lockForm();
            using (Form3 form3 = new Form3(insertedClient))
            {
                var result = form3.ShowDialog();
                if (result == DialogResult.OK)
                {
                    unlockForm();
                    button4.Enabled = true;
                    refresh();
                }
                else if (result == DialogResult.Cancel)
                {
                    unlockForm();
                    button4.Enabled = false;
                    refresh();
                    //TODO - AKO SE ADUJE KORISNIK PA SE POSLE OPET HOCEMO DA ADDUJEMO ALI KLIKNEMO CANCEL, UNDO BUTTON JE FALSE
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void InitDataGridView1()
        {
            db = ProviderFactory.Provider(provider.getDatabaseType());
            List<Client> clients = new List<Client>();
            clients = db.getAllClients();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Username", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Surname", typeof(string));
            foreach (var client in clients)
            {
                dataTable.Rows.Add(
                    client.Username,
                    client.Name,
                    client.Surname
                    );
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = dataTable;

            // Optionally, you can customize the DataGridView appearance and behavior
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int selectedUserId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);

            
            InitDataGridView2(selectedUserId);
        }

        private void InitDataGridView2(int id)
        {

            db = ProviderFactory.Provider(provider.getDatabaseType());
            List<Plan> activatedPlans = new List<Plan>();
            activatedPlans = db.getActivatedClientPlansByClientID(id);

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Price", typeof(float));
            dataTable.Columns.Add("Plan_Type", typeof(string));



            // Add some rows to the DataTable
            foreach (var activatedPlan in activatedPlans)
            {


                dataTable.Rows.Add(
                    activatedPlan.Name,
                    activatedPlan.Price
                    //   activatedPlan.getPlanType
                    );
            }

            // Bind the DataTable to the DataGridView
            dataGridView2.DataSource = dataTable;

            // Optionally, you can customize the DataGridView appearance and behavior
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            insertClientCommand = clientSingleton.icc;
            insertedClient = clientSingleton.client;            
            insertedClient.RestoreClientMemento(insertClientCommand.getPreviousState());
            db = ProviderFactory.Provider(provider.getDatabaseType());
            db.removeClientByID(insertedClient.ID);
            button4.Enabled = false;
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {                
                try
                {
                    db = ProviderFactory.Provider(provider.getDatabaseType());
                    string username = (string)dataGridView1.SelectedRows[0].Cells[0].Value;                    
                    int clientId = db.getClientIdByUsername(username);
                    if (clientId == -1) MessageBox.Show("Fail to retrieve username id from database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int result = db.removeClientByID(clientId);                    
                    if (result >= 0)
                    {
                        MessageBox.Show("Client successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);                                                
                        button4.Enabled = true;                        
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        button4.Enabled = false;                        
                    }
                }
                catch
                {
                    MessageBox.Show("Please select a client to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                }
                finally
                {
                    refresh();
                }
            }
            else
            {
                MessageBox.Show("Select client row that you want to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button4.Enabled = false;
                refresh();
            }
        }
    }
}
