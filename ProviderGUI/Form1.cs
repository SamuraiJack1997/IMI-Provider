using ProviderDatabaseLibrary;
using ProviderDatabaseLibrary.Factories;
using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Models;
using System.Data;
using System.Windows.Forms;

namespace ProviderGUI
{
    public partial class Form1 : Form
    {
        private IProvider db;
        public Form1()
        {
            InitializeComponent();
            
            ProviderMySQL provider=ProviderMySQL.Instance;
            //TODO Dodavanje podataka za Provajdera iz config.txt fajla pomocu dijaloga
            provider.setProviderData("SBB", @"Data Source=(localdb)\baza2; Initial Catalog = PROVIDER; Integrated Security = True");
            
            //Primer povlacenja podataka
            label1.Text = "";
            db = ProviderFactory.Provider("MySQL");
            List<Client> clients = new List<Client>();
            clients = db.getAllClients();
            foreach (var client in clients)
            {
                label1.Text += client.ToString()+"\n";
            }

            //poziv funkcije za popunjavanje DataGridView-a
            InitDataGridView1();
            InitDataGridView2();

        }

        private void InitDataGridView1()
        {

            db = ProviderFactory.Provider("MySQL");
            List<Client> clients = new List<Client>();
            clients = db.getAllClients();
            
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Username", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Surname", typeof(string));


            // Add some rows to the DataTable
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

        private void InitDataGridView2()
        {

            db = ProviderFactory.Provider("MySQL");
            List<Plan> activatedPlans = new List<Plan>();
            activatedPlans = db.getActivatedClientPlansByClientID(1);

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Price", typeof(float));
            dataTable.Columns.Add("Plan_Type",typeof(string));



            // Add some rows to the DataTable
            foreach (var activatedPlan in activatedPlans)
            {
                

                dataTable.Rows.Add(
                    activatedPlan.Name,
                    activatedPlan.Price,
                    activatedPlan.getPlanName()
                    );
            }

            // Bind the DataTable to the DataGridView
            dataGridView2.DataSource = dataTable;

            // Optionally, you can customize the DataGridView appearance and behavior
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


    }
}
