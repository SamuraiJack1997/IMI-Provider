using ProviderDatabaseLibrary;
using ProviderDatabaseLibrary.ClientMementoCommand.ClientCommands;
using ProviderDatabaseLibrary.Connections;
using ProviderDatabaseLibrary.Factories;
using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace ProviderGUI
{
    public partial class Form1 : Form
    {
        private IProvider db;
        Provider provider = Provider.Instance;
        private SqlConnection _connection = MySqlConnection.Connection;
       

        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;


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
                    string[]lines= File.ReadAllLines(openFileDialog.FileName);
                    if(lines.Length == 2)
                    {
                          provider.setName(lines[0]);
                          provider.setConnectionString(lines[1]);
                        db=ProviderFactory.Provider(provider.getDatabaseType());
                           label1.Text = lines[0] + "\n" + lines[1]+ "\n" + "@'"+ provider.getConnectionString() + "'";
                    }
                   _connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska prilikom ucitavanja " + ex.Message + _connection);
                }
                finally { 
                    _connection.Close();
                    openFileDialog.Dispose(); }
            }
        }

      
    }

}
