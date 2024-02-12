using ProviderDatabaseLibrary.Interfaces;
using ProviderDatabaseLibrary.Models.Plans;
using ProviderDatabaseLibrary.Models.Singletones;
using ProviderDatabaseLibrary.PlanBuider.Models;
using ProviderDatabaseLibrary.PlanBuider;
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
using ProviderDatabaseLibrary.Factories;

namespace ProviderGUI
{
    public partial class Form4 : Form
    {
        private IProvider db;
        Provider provider = Provider.Instance;
        private bool button3Clicked = false;
        Plan plan;
        public Form4()
        {
            InitializeComponent();
            db = ProviderFactory.Provider(provider.getDatabaseType());
            this.Text = provider.getName() + "/Add new plan:";
            button1.Enabled = false;
            txtdownloadSpeed.Enabled = false;
            txtnumberOfChannels.Enabled = false;
            txtuploadSpeed.Enabled = false;
            txtplanName.Enabled = false;
            floatprice.Enabled = false;
            floatprice.ReadOnly = true;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPlan = comboBox1.SelectedItem.ToString();

            // Enable/disable input fields based on the selected plan
            switch (selectedPlan)
            {
                case "Internet Plan":
                    txtdownloadSpeed.Enabled = true;
                    txtuploadSpeed.Enabled = true;
                    txtnumberOfChannels.Enabled = false;
                    txtplanName.Enabled = true;
                    break;
                case "TV Plan":
                    txtdownloadSpeed.Enabled = false;
                    txtuploadSpeed.Enabled = false;
                    txtnumberOfChannels.Enabled = true;
                    txtplanName.Enabled = true;
                    break;
                default:
                    // If none of the options are selected or if you have more options, handle them here
                    break;
            }
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
            if (txtdownloadSpeed.Enabled == true)
            {
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

            int result = -1;
            if (plan != null)
            {
                string selectedPlan = comboBox1.SelectedItem.ToString();
                switch (selectedPlan)
                {
                    case "Internet Plan":
                        result = db.insertInternetPlan((Internet_Plan)plan);
                        if(result > 0)
                        {
                            MessageBox.Show("Successfully added plan into database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error while adding plan!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "TV Plan":
                        result = db.insertTVPlan((TV_Plan)plan);
                        if (result > 0)
                        {
                            MessageBox.Show("Successfully added plan into database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error while adding plan!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    default:
                        break;
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

        private void button3_Click(object sender, EventArgs e)
        {
            button3Clicked = true;

            // Generate price based on selected plan
            if (comboBox1.SelectedItem != null)
            {
                string selectedPlan = comboBox1.SelectedItem.ToString();
                switch (selectedPlan)
                {
                    case "Internet Plan":
                        if (float.TryParse(txtdownloadSpeed.Text, out float downloadSpeed) &&
                            float.TryParse(txtuploadSpeed.Text, out float uploadSpeed))
                        {
                            PlanBuilderModel internetPlan = Director.SetInternetPlan(txtplanName.Text, 1, (int)downloadSpeed, (int)uploadSpeed);
                            plan = internetPlan.ExecutePlanCreation();
                            floatprice.Text = plan.Price.ToString();
                            button1.Enabled = true;
                        }
                        break;
                    case "TV Plan":
                        if (float.TryParse(txtnumberOfChannels.Text, out float numberOfChannels))
                        {
                            PlanBuilderModel tvPlan = Director.SetTVPlan(txtplanName.Text, 1, (int)numberOfChannels);
                            plan = tvPlan.ExecutePlanCreation();
                            floatprice.Text = plan.Price.ToString();
                            button1.Enabled = true;
                        }
                        break;

                    default:
                        break;
                }
            }
      
        }
    }
}
