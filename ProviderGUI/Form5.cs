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
using System.Data.Entity.Core.Mapping;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProviderGUI
{
    public partial class Form5 : Form
    {
        private IProvider db;
        Provider provider = Provider.Instance;
        private bool button3Clicked = false;
        List<Plan> plans;
        List<TV_Plan> tv_plans;
        List<Internet_Plan> internet_plans;
        Plan plan;
        public Form5()
        {
            InitializeComponent();
            db = ProviderFactory.Provider(provider.getDatabaseType());
            this.Text = provider.getName() + "/Add new plan:";

            button1.Enabled = false;
            txtdownloadSpeed.Enabled = false;
            txtnumberOfChannels.Enabled = false;
            txtuploadSpeed.Enabled = false;            
            floatprice.Enabled = true;
            floatprice.ReadOnly = true;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            plans = new List<Plan>();
            tv_plans = new List<TV_Plan>();
            internet_plans = new List<Internet_Plan>();
            plans = db.getAllPlans();
            foreach (Plan plan in plans)
            {
                if (plan is TV_Plan) tv_plans.Add((TV_Plan)plan);
                if (plan is Internet_Plan) internet_plans.Add((Internet_Plan)plan);
            }
            comboBox1.DisplayMember = "Name";
            comboBox2.DisplayMember = "Name";

            foreach (Plan tv_plan in tv_plans)            
                comboBox1.Items.Add(tv_plan.Name);
                            
            foreach (Plan internet_plan in internet_plans)            
                comboBox2.Items.Add(internet_plan);

            comboBox1.DataSource = tv_plans;
            comboBox2.DataSource = internet_plans;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string planName = txtplanName.Text;
            float downloadSpeed;
            float uploadSpeed;
            float numberOfChannels;
            float price;
            int flag;
            TV_Plan tv_plan;
            Internet_Plan internet_plan;
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a plan type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Enabled = false;
                return;
            }
            else tv_plan = (TV_Plan)comboBox1.SelectedItem;

            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select a plan type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Enabled = false;
                return;
            }
            else internet_plan = (Internet_Plan)comboBox2.SelectedItem;

            if (txtdownloadSpeed.Enabled == true)
            {
                if (!float.TryParse(txtdownloadSpeed.Text, out downloadSpeed) || float.IsNaN(downloadSpeed))
                {
                    MessageBox.Show("Download speed must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button1.Enabled = false;
                    return;
                }
            }
            if (txtuploadSpeed.Enabled == true)
            {
                if (!float.TryParse(txtuploadSpeed.Text, out uploadSpeed) || float.IsNaN(uploadSpeed) && txtuploadSpeed.Enabled == true)
                {
                    MessageBox.Show("Upload speed must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button1.Enabled = false;
                    return;
                }
            }

            if (txtnumberOfChannels.Enabled == true)
            {
                if (!float.TryParse(txtnumberOfChannels.Text, out numberOfChannels) || float.IsNaN(numberOfChannels) && txtnumberOfChannels.Enabled == true)
                {
                    MessageBox.Show("Number of channels must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button1.Enabled = false;
                    return;
                }
            }

            if (txtplanName.Enabled == true)
            {
                if (string.IsNullOrWhiteSpace(planName) && txtplanName.Enabled == true)
                {
                    MessageBox.Show("Plan name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button1.Enabled = false;
                    return;
                }
            }
                        
            flag = db.insertComboPlan((Combo_Plan)plan);
            if(flag == -1)
            {
                MessageBox.Show("Error while inserting plan." + flag, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Enabled = false;
                refresh();
            }
            if(flag == 0)
            {
                MessageBox.Show("Combo plan with the same name or with the same parameters already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Enabled = false;
                refresh();
            }
            if(flag > 0)
            {
                MessageBox.Show("Successfully inserted plan.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refresh();
                this.Close();
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
            Internet_Plan internet_plan;
            TV_Plan tv_plan;
            bool comboB = false;
            string planName = txtplanName.Text;
            button3Clicked = true;
            
            tv_plan = (TV_Plan)comboBox1.SelectedItem;                
            internet_plan = (Internet_Plan)comboBox2.SelectedItem;
            
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
                comboB = true;
            else
                comboB = false;

            if(planName != "")
            {
                if (comboB)
                {
                    PlanBuilderModel comboPlan = Director.SetComboPlan(txtplanName.Text, internet_plan.Internet_Plan_ID, tv_plan.TV_Plan_ID, internet_plan.Download_Speed, internet_plan.Upload_Speed, tv_plan.Channel_Number);
                    plan = comboPlan.ExecutePlanCreation();                
                    floatprice.Text = plan.Price.ToString();
                    button1.Enabled = true;                
                }
            }
            else
            {
                MessageBox.Show("Please enter plane name.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                refresh();
            }
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                TV_Plan tv_plan = (TV_Plan)comboBox1.SelectedItem;             
                txtnumberOfChannels.Text = tv_plan.Channel_Number.ToString();                                                    
            }
            else
            {
                txtnumberOfChannels.Text = "";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                Internet_Plan internet_plan = (Internet_Plan)comboBox2.SelectedItem;
            
                txtdownloadSpeed.Text = internet_plan.Download_Speed.ToString();
                txtuploadSpeed.Text = internet_plan.Upload_Speed.ToString();

            }
            else
            {
                txtdownloadSpeed.Text = "";
                txtuploadSpeed.Text = "";
            }
        }
        private void refresh()
        {
            comboBox1.SelectedItem = -1;
            comboBox2.SelectedItem = -1;
            txtdownloadSpeed.Text = "";
            txtuploadSpeed.Text = "";
            txtnumberOfChannels.Text = "";
            floatprice.Text = "";
            button1.Enabled = false;
        }
    }
}
