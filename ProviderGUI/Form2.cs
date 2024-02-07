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
        public Form2()
        {
            InitializeComponent();            
            this.Text = provider.getName();
            button3.Enabled = false;
            button4.Enabled = false;
            InitDataGridView1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
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

    }
}
