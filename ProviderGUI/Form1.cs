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
        bool formReset = false;
        private IProvider db;
        private SqlConnection _connectionMySQL;
        private SQLiteConnection _connectionSQLite;
        Provider provider = Provider.Instance;

        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void resetForm()
        {
            Form1 resetedForm = new Form1();
            resetedForm.Show();
            this.Dispose(false);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            provider.setDatabaseType("MySQL");
            button1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            provider.setDatabaseType("SQLite");
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        OpenFileDialog openFileDialog = new OpenFileDialog();

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

                        if (provider.getDatabaseType() == "MySQL")
                        {
                            _connectionMySQL = MySqlConnection.Connection;
                            _connectionMySQL.Open();
                            _connectionMySQL.Close();
                            button1.Text = "Success!";
                            button1.BackColor = Color.Green;
                            button1.Enabled = false;
                            button2.Enabled = true;
                        }
                        if (provider.getDatabaseType() == "SQLite")
                        {
                            _connectionSQLite = ConnectionSQLite.Connection;
                            _connectionSQLite.Open();
                            _connectionSQLite.Close();
                            button1.Text = "Success!";
                            button1.BackColor = Color.Green;
                            button1.Enabled = false;
                            button2.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska prilikom ucitavanja: " + ex.Message+"\nProverite vas konekcioni string!");
                    resetForm();
                }
                finally
                {
                    openFileDialog.Dispose();
                }
            }
        }

    }

}
