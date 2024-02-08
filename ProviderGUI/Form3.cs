using ProviderDatabaseLibrary.ClientMementoCommand.ClientCommands;
using ProviderDatabaseLibrary.ClientMementoCommand.Models;
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
    public partial class Form3 : Form
    {
        private IProvider db;
        Provider provider = Provider.Instance;
        ClientSingleton clientSingleton = ClientSingleton.Instance;
        Client c;
        public Form3(Client c)
        {
            this.c = c;
            InitializeComponent();
            this.Text = provider.getName() + "/Register client:";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            c = new Client(0, username, firstName, lastName);
            ClientMemento initialState = c.CreateClientMemento();

            InsertClientCommand insertCommand = new InsertClientCommand(c, initialState);
            int result = insertCommand.Execute();
            if(result == 0) 
            {
                MessageBox.Show("Client with that username already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(result < 0)
            {
                MessageBox.Show("Error while adding client.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if( result > 0) 
            {
                clientSingleton.icc = insertCommand;
                clientSingleton.client = c;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }                                                    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
