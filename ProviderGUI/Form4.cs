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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProviderGUI
{
    public partial class Form4 : Form
    {
        private IProvider db;
        Provider provider = Provider.Instance;
        public Form4()
        {
            InitializeComponent();
            this.Text = provider.getName() + "/Add new plan:";



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string planName = txtplanName.Text;
            float downloadSpeed;
            float uploadSpeed;
            float numberOfChannels;
            float price;

            // Attempt to parse the price input as a float
            if (!float.TryParse(floatprice.Text, out price) || float.IsNaN(price))
            {
                MessageBox.Show("Price must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!float.TryParse(txtdownloadSpeed.Text, out downloadSpeed) || float.IsNaN(downloadSpeed))
            {
                MessageBox.Show("Download speed must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!float.TryParse(txtuploadSpeed.Text, out uploadSpeed) || float.IsNaN(uploadSpeed))
            {
                MessageBox.Show("Upload speed must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!float.TryParse(txtnumberOfChannels.Text, out numberOfChannels) || float.IsNaN(numberOfChannels))
            {
                MessageBox.Show("Number of channels must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(planName))
            {
                MessageBox.Show("Plan name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

       
    }
}
