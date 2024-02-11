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

namespace ProviderGUI
{
    public partial class Form4 : Form
    {
        private IProvider db;
        Provider provider = Provider.Instance;
        private bool button3Clicked = false;
        public Form4()
        {
            InitializeComponent();
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



             void button1_Click(object sender, EventArgs e)
            {
                // Your existing code for adding plan
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
                                Plan plan2 = internetPlan.ExecutePlanCreation();


                                // Insert Internet Plan into the database
                                int rowsAffected2 = db.insertInternetPlan((Internet_Plan)plan2);
                            }
                            break;
                        case "TV Plan":
                            if (float.TryParse(txtnumberOfChannels.Text, out float numberOfChannels))
                            {
                                PlanBuilderModel tvPlan = Director.SetTVPlan(txtplanName.Text, 1, (int)numberOfChannels);
                                Plan plan1 = tvPlan.ExecutePlanCreation();
                                floatprice.Text = plan1.Price.ToString();

                                // Insert TV Plan into the database
                                int rowsAffected1 = db.insertTVPlan((TV_Plan)plan1);
                            }
                            break;
                        default:
                            break;
                    }
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
                            Plan plan2 = internetPlan.ExecutePlanCreation();
                            floatprice.Text = plan2.Price.ToString();
                        }
                        break;
                    case "TV Plan":
                        if (float.TryParse(txtnumberOfChannels.Text, out float numberOfChannels))
                        {
                            PlanBuilderModel tvPlan = Director.SetTVPlan(txtplanName.Text, 1, (int)numberOfChannels);
                            Plan plan1 = tvPlan.ExecutePlanCreation();
                            floatprice.Text = plan1.Price.ToString();
                        }
                        break;
                       
                    default:
                        break;
                }
            }

            // Enable Add Plan button
            button1.Enabled = true;


        }

       

    }
}
