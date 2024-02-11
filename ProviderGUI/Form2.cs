using ProviderDatabaseLibrary.ClientMementoCommand.ClientCommands;
using ProviderDatabaseLibrary.ClientMementoCommand.Models;
using ProviderDatabaseLibrary.Factories;
using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Models;
using ProviderDatabaseLibrary.Models.Plans;
using ProviderDatabaseLibrary.Models.Singletones;
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
        List<Client> clients;
        List<Plan> plans;
        DeleteClientCommand deleteClientCommand;
        Client removedClient;
        bool addedClient = false;
        bool deletedClient = false;
        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = provider.getName();            
            button4.Enabled = false;
            InitDataGridView1();
            InitDataGridView2();
            if (clients != null)
            {
                if (clients[0] != null)
                {
                    InitDataGridView3(clients[0].ID);
                }
            }
            this.FormClosing += Form2_FormClosing;

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
            InitDataGridView1();
            InitDataGridView2();
            if (clients != null)
            {
                if (clients[0] != null)
                {
                    InitDataGridView3(clients[0].ID);
                }
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lockForm();
            using (Form3 form3 = new Form3(insertedClient))
            {
                var result = form3.ShowDialog();
                if (result == DialogResult.OK)
                {
                    addedClient = true;
                    deletedClient = false;
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
            lockForm();
            using (Form4 form4 = new Form4()) //TODO -insert plan memento
            {
                var result = form4.ShowDialog();
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

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();

        }

        private void InitDataGridView1()
        {
            db = ProviderFactory.Provider(provider.getDatabaseType());
            clients = new List<Client>();
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
            dataGridView1.ReadOnly = true;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            db = ProviderFactory.Provider(provider.getDatabaseType());
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true; // Select the whole row
                try
                {
                    string username = (string)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                    int clientId = db.getClientIdByUsername(username);
                    if (clientId == -1)
                        MessageBox.Show("Fail to retrieve username id from database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitDataGridView3(clientId);
                }
                catch
                {
                    MessageBox.Show("Please select client row.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



        public void InitDataGridView2()
        {
            db = ProviderFactory.Provider(provider.getDatabaseType());
            plans = new List<Plan>();
            plans = db.getAllPlans();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Price", typeof(float));
            dataTable.Columns.Add("Plan_Type", typeof(string));
            dataTable.Columns.Add("Download / Upload", typeof(string));
            dataTable.Columns.Add("Channel Number", typeof(string));

            foreach (var plan in plans)
            {
                if (plan is Internet_Plan)
                    dataTable.Rows.Add(
                        plan.Name,
                        plan.Price,
                        plan.getPlanType(),
                        ((Internet_Plan)plan).Download_Speed + "/" + ((Internet_Plan)plan).Upload_Speed+"(mpbs)",
                        "           -");
                if (plan is TV_Plan)
                    dataTable.Rows.Add(
                        plan.Name,
                        plan.Price,
                        plan.getPlanType(),
                        "           -",
                        ((TV_Plan)plan).Channel_Number
                        );
                if (plan is Combo_Plan)
                    dataTable.Rows.Add(
                        plan.Name,
                        plan.Price,
                        plan.getPlanType(),
                        ((Combo_Plan)plan).Download_Speed + "/" + ((Combo_Plan)plan).Upload_Speed+"(mbps)",
                        ((Combo_Plan)plan).Channel_Number
                        );
            }
            dataGridView2.DataSource = dataTable;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ReadOnly = true;
        }

        private void InitDataGridView3(int id)
        {

            db = ProviderFactory.Provider(provider.getDatabaseType());
            List<Plan> activatedPlans = new List<Plan>();
            activatedPlans = db.getActivatedClientPlansByClientID(id);

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Price", typeof(float));
            dataTable.Columns.Add("Plan_Type", typeof(string));

            foreach (var activatedPlan in activatedPlans)
            {
                dataTable.Rows.Add(
                    activatedPlan.Name,
                    activatedPlan.Price,
                    activatedPlan.getPlanType()
                    );
            }

            dataGridView3.DataSource = dataTable;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.ReadOnly = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (addedClient == true)
            {
                insertClientCommand = clientSingleton.icc;
                insertedClient = clientSingleton.client;
                insertedClient.RestoreClientMemento(insertClientCommand.getPreviousState());
                db = ProviderFactory.Provider(provider.getDatabaseType());
                db.removeClientByID(insertedClient.ID);
                button4.Enabled = false;
                refresh();
                addedClient = false;
            }
            if (deletedClient == true)
            {

                deleteClientCommand = clientSingleton.dcc;
                removedClient = clientSingleton.client;

                removedClient.RestoreClientMemento(deleteClientCommand.getPreviousState());
                db = ProviderFactory.Provider(provider.getDatabaseType());
                db.insertClient(removedClient.Username, removedClient.Name, removedClient.Surname);
                int clientID = db.getClientIdByUsername(removedClient.Username);
                //TODO dodaj planove za korisnikov id
                button4.Enabled = false;
                refresh();
                deletedClient = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    db = ProviderFactory.Provider(provider.getDatabaseType());
                    string username = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
                    string firstName = (string)dataGridView1.SelectedRows[0].Cells[1].Value;
                    string lastName = (string)dataGridView1.SelectedRows[0].Cells[2].Value;
                    int clientId = db.getClientIdByUsername(username);
                    if (clientId == -1) MessageBox.Show("Fail to retrieve username id from database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        Client c = new Client(0, username, firstName, lastName);
                        c.ActivatedPlans = db.getActivatedClientPlansByClientID(clientId);
                        ClientMemento initialState = c.CreateClientMemento();
                        DeleteClientCommand deleteCommand = new DeleteClientCommand(c, initialState);
                        deleteCommand.Execute();
                        clientSingleton.dcc = deleteCommand;
                        clientSingleton.client = c;
                        deletedClient = true;
                        addedClient = false;
                        MessageBox.Show("Client successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button4.Enabled = true;
                    }
                    catch
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

        private void button3_Click(object sender, EventArgs e)
        {

            lockForm();
            using (Form5 form5 = new Form5()) //TODO -insert plan memento
            {
                var result = form5.ShowDialog();
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
    }
}
