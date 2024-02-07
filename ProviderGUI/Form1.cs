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
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace ProviderGUI
{
    public partial class Form1 : Form
    {
        private IProvider db;
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
                if (provider.getDatabaseType() == "MySQL")
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = provider.getConnectionString();
                    try
                    {
                        connection.Open();
                        connection.Close();
                        MessageBox.Show("File successfully loaded. Connection successful.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button1.Enabled = false;
                        button1.Text = "Success";
                        button1.BackColor = Color.Green;
                        button2.Enabled = true;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Connection error.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        button1.Enabled = true;
                        button1.Text = "Try again";
                        button1.BackColor = Color.Red;
                        button2.Enabled = false;
                    }
                }
                else if (provider.getDatabaseType() == "SQLite")
                {
                    SQLiteConnection connection = new SQLiteConnection();
                    connection.ConnectionString = provider.getConnectionString();
                    try
                    {
                        connection.Open();
                        connection.Close();
                        MessageBox.Show("File successfully loaded. Connection successful.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button1.Enabled = false;
                        button1.Text = "Success";
                        button1.BackColor = Color.Green;
                        button2.Enabled = true;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Connection error.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        button1.Enabled = true;
                        button1.Text = "Try again";
                        button1.BackColor = Color.Red;
                        button2.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Enabled = true;
                button1.Text = "Try again";
                button1.BackColor = Color.Red;
                button2.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            provider.setDatabaseType("MySQL");
            button1.Enabled = true;
            button1.Text = "Load config file";
            button1.BackColor = Color.White;
            button2.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            provider.setDatabaseType("SQLite");
            button1.Enabled = true;
            button1.Text = "Load config file";
            button1.BackColor = Color.White;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileLoaded = false;
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
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while loading file: ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        fileLoaded = false;
                    }
                }
            }
            finally
            {
                openFileDialog.Dispose();
                if (fileLoaded)
                {
                    checkConnection();
                }
                else
                {
                    MessageBox.Show("File not loaded.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button1.Text = "Try again";
                    button1.BackColor = Color.Red;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }
    }

}
