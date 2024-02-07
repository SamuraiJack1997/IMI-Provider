using ProviderDatabaseLibrary;
using ProviderDatabaseLibrary.ClientMementoCommand.ClientCommands;
using ProviderDatabaseLibrary.Connections;
using ProviderDatabaseLibrary.Factories;
using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace ProviderGUI
{
    public partial class Form1 : Form
    {
        private IProvider db;
        private SqlConnection _connectionMySQL;
        private SQLiteConnection _connectionSQLite;
        Provider provider = Provider.Instance;
        bool fileLoaded = false;

        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void resetForm()
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(true);
        }

        private void checkConnection()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            finally 
            { 
            
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            provider.setDatabaseType("MySQL");
            button1.Enabled = true;
            label1.Text = provider.getConnectionString() + "\n" + provider.getName() + "\n" + provider.getDatabaseType();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            provider.setDatabaseType("SQLite");
            button1.Enabled = true;
            label1.Text = provider.getConnectionString() + "\n" + provider.getName() + "\n" + provider.getDatabaseType();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            try
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    try
                    {
                        string[] lines = File.ReadAllLines(openFileDialog.FileName);
                        if (lines.Length == 2)
                        {
                            provider.setName(lines[0]);
                            provider.setConnectionString(lines[1]);
                            fileLoaded = true;
                            label1.Text = provider.getConnectionString() + "\n" + provider.getName() + "\n" + provider.getDatabaseType();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greska prilikom ucitavanja fajla: " + ex.Message + "\nProverite vas konekcioni string!");
                        fileLoaded = false;
                    }
                }
            }
            finally {
                openFileDialog.Dispose();
                if (fileLoaded)
                {
                    checkConnection();
                }
            }
        }

    }

}
