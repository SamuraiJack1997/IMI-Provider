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
        private IProvider db;//TODO odabir baze za rad
        Provider provider = Provider.Instance;

        public Form1()
        {
            InitializeComponent();
            //TODO Dodavanje podataka za Provajdera iz config.txt fajla pomocu dijaloga

            ////ODABIR BAZE
            provider.setProviderData("SBB", @"Data Source=(localdb)\baza; Initial Catalog = PROVIDER; Integrated Security = True", "MySQL");
            //   provider.setProviderData("MTS", @"Data Source=D:\Users\Kristina\Documents\GitHub\tim-10\PROVIDER.db;", "SQLite");

            //Primer povlacenja podataka
            db = ProviderFactory.Provider(provider.getDatabaseType());
            List<Client> clients = new List<Client>();
            clients = db.getAllClients();
            foreach (var client in clients)
            {
                label1.Text += client.ToString() + "\n";
            }

            //poziv funkcije za popunjavanje DataGridView-a
            InitDataGridView1();
            InitDataGridView2();

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
            db = ProviderFactory.Provider(provider.getDatabaseType());
            List<Plan> activatedPlans = new List<Plan>();
            activatedPlans = db.getActivatedClientPlansByClientID(1);//TODO selektovani indeks proslediti

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Price", typeof(float));
            dataTable.Columns.Add("Plan_Type", typeof(string));

            // Add some rows to the DataTable
            foreach (var activatedPlan in activatedPlans)
            {
                dataTable.Rows.Add(
                    activatedPlan.Name,
                    activatedPlan.Price,
                    activatedPlan.getPlanType()
                    );
            }

            // Bind the DataTable to the DataGridView
            dataGridView2.DataSource = dataTable;

            // Optionally, you can customize the DataGridView appearance and behavior
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedCheckbox = sender as CheckBox;

            foreach (Control control in groupBox1.Controls) 
            {
                if (control is CheckBox checkBox && checkBox != clickedCheckbox)
                {
                    checkBox.Checked = false;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedCheckbox = sender as CheckBox;

            foreach (Control control in groupBox1.Controls) 
            {
                if (control is CheckBox checkBox && checkBox != clickedCheckbox)
                {
                    checkBox.Checked = false;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool anyCheckboxSelected = false;
            foreach (Control control in groupBox1.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    anyCheckboxSelected = true;
                    break;
                }
            }

           
            if (!anyCheckboxSelected)
            {
                MessageBox.Show("Morate odabrati barem jednu opciju za bazu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                
                string selectedDatabase = GetSelectedDatabase();

               

                MessageBox.Show("Baza " + selectedDatabase + " je uspešno pokrenuta.", "Uspesno pokretanje baze", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške prilikom pokretanja baze: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedCheckbox = sender as CheckBox;

            foreach (Control control in groupBox1.Controls) 
            {
                if (control is CheckBox checkBox && checkBox != clickedCheckbox)
                {
                    checkBox.Checked = false;
                }
            }

        }

        private string GetSelectedDatabase()
        {
            
            foreach (Control control in groupBox1.Controls) 
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    return checkBox.Text;
                }
            }
            return string.Empty;
        }
    }
}
