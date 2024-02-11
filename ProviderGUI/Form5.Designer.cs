namespace ProviderGUI
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtplanName = new TextBox();
            txtdownloadSpeed = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label7 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            txtuploadSpeed = new TextBox();
            label4 = new Label();
            txtnumberOfChannels = new TextBox();
            label5 = new Label();
            floatprice = new TextBox();
            label6 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 68);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "Plan name:";
            // 
            // txtplanName
            // 
            txtplanName.Location = new Point(154, 65);
            txtplanName.Name = "txtplanName";
            txtplanName.Size = new Size(141, 23);
            txtplanName.TabIndex = 1;
            // 
            // txtdownloadSpeed
            // 
            txtdownloadSpeed.Location = new Point(154, 96);
            txtdownloadSpeed.Name = "txtdownloadSpeed";
            txtdownloadSpeed.Size = new Size(141, 23);
            txtdownloadSpeed.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 96);
            label2.Name = "label2";
            label2.Size = new Size(136, 15);
            label2.TabIndex = 2;
            label2.Text = "Download speed(mbps):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 4;
            label3.Text = "Select TV plan:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 38);
            label7.Name = "label7";
            label7.Size = new Size(111, 15);
            label7.TabIndex = 4;
            label7.Text = "Select Internet plan:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(154, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(141, 23);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(154, 35);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(141, 23);
            comboBox2.TabIndex = 6;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(12, 222);
            button1.Name = "button1";
            button1.Size = new Size(136, 48);
            button1.TabIndex = 7;
            button1.Text = "Add plan";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(154, 222);
            button2.Name = "button2";
            button2.Size = new Size(141, 49);
            button2.TabIndex = 8;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtuploadSpeed
            // 
            txtuploadSpeed.Location = new Point(154, 125);
            txtuploadSpeed.Name = "txtuploadSpeed";
            txtuploadSpeed.Size = new Size(141, 23);
            txtuploadSpeed.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 128);
            label4.Name = "label4";
            label4.Size = new Size(120, 15);
            label4.TabIndex = 9;
            label4.Text = "Upload speed(mpbs):";
            // 
            // txtnumberOfChannels
            // 
            txtnumberOfChannels.Location = new Point(154, 156);
            txtnumberOfChannels.Name = "txtnumberOfChannels";
            txtnumberOfChannels.Size = new Size(141, 23);
            txtnumberOfChannels.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 159);
            label5.Name = "label5";
            label5.Size = new Size(118, 15);
            label5.TabIndex = 11;
            label5.Text = "Number of channels:";
            // 
            // floatprice
            // 
            floatprice.BackColor = SystemColors.Info;
            floatprice.Location = new Point(154, 185);
            floatprice.Name = "floatprice";
            floatprice.Size = new Size(141, 23);
            floatprice.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(112, 188);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 13;
            label6.Text = "Price:";
            // 
            // button3
            // 
            button3.Location = new Point(12, 184);
            button3.Name = "button3";
            button3.Size = new Size(94, 24);
            button3.TabIndex = 15;
            button3.Text = "Calculate";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(311, 279);
            Controls.Add(button3);
            Controls.Add(floatprice);
            Controls.Add(label6);
            Controls.Add(txtnumberOfChannels);
            Controls.Add(label5);
            Controls.Add(txtuploadSpeed);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(comboBox2);
            Controls.Add(label3);
            Controls.Add(label7);
            Controls.Add(txtdownloadSpeed);
            Controls.Add(label2);
            Controls.Add(txtplanName);
            Controls.Add(label1);
            Name = "Form5";
            Text = "Form5";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtplanName;
        private TextBox txtdownloadSpeed;
        private Label label2;
        private Label label3;
        private Label label7;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button1;
        private Button button2;
        private TextBox txtuploadSpeed;
        private Label label4;
        private TextBox txtnumberOfChannels;
        private Label label5;
        private TextBox floatprice;
        private Label label6;
        private Button button3;
    }
}