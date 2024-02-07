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

        public Form3()
        {
            InitializeComponent();
            this.Text = provider.getName()+"/Register client:";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }
    }
}
