﻿using ProviderDatabaseLibrary.Interfaces;
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
  
            txtdownloadSpeed.Enabled = false;
            txtnumberOfChannels.Enabled = false;
            txtuploadSpeed.Enabled = false;
            txtplanName.Enabled = false;
            floatprice.Enabled = true;
            floatprice.ReadOnly = true;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string planName = txtplanName.Text;
            float downloadSpeed;
            float uploadSpeed;
            float numberOfChannels;

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a plan type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtdownloadSpeed.Enabled == true) { 
            if (!float.TryParse(txtdownloadSpeed.Text, out downloadSpeed) || float.IsNaN(downloadSpeed))
            {
                MessageBox.Show("Download speed must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          }
            if (txtuploadSpeed.Enabled == true)
            {
                if (!float.TryParse(txtuploadSpeed.Text, out uploadSpeed) || float.IsNaN(uploadSpeed) && txtuploadSpeed.Enabled == true)
                {
                    MessageBox.Show("Upload speed must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (txtnumberOfChannels.Enabled == true)
            {
                if (!float.TryParse(txtnumberOfChannels.Text, out numberOfChannels) || float.IsNaN(numberOfChannels) && txtnumberOfChannels.Enabled == true)
                {
                    MessageBox.Show("Number of channels must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (txtplanName.Enabled == true)
            {
                if (string.IsNullOrWhiteSpace(planName) && txtplanName.Enabled == true)
                {
                    MessageBox.Show("Plan name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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