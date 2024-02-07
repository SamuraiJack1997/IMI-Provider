namespace ProviderGUI
{
    partial class Form2
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
            button1 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            dataGridView2 = new DataGridView();
            label3 = new Label();
            dataGridView3 = new DataGridView();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 353);
            button1.Name = "button1";
            button1.Size = new Size(66, 58);
            button1.TabIndex = 0;
            button1.Text = "Add new client";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(84, 353);
            button2.Name = "button2";
            button2.Size = new Size(62, 58);
            button2.TabIndex = 1;
            button2.Text = "Delete selected client";
            button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(400, 306);
            dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 3;
            label1.Text = "Clients:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(914, 23);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 4;
            label2.Text = "Plans:";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(914, 41);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(328, 306);
            dataGridView2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(430, 23);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 6;
            label3.Text = "Selected client plans:";
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(430, 41);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(478, 306);
            dataGridView3.TabIndex = 7;
            // 
            // button3
            // 
            button3.Location = new Point(152, 353);
            button3.Name = "button3";
            button3.Size = new Size(61, 58);
            button3.TabIndex = 8;
            button3.Text = "Update selected client";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(219, 353);
            button4.Name = "button4";
            button4.Size = new Size(59, 58);
            button4.TabIndex = 9;
            button4.Text = "Undo changes";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(914, 353);
            button5.Name = "button5";
            button5.Size = new Size(96, 58);
            button5.TabIndex = 10;
            button5.Text = "Activate plan for selected client";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(430, 353);
            button6.Name = "button6";
            button6.Size = new Size(94, 58);
            button6.TabIndex = 11;
            button6.Text = "Dectivate plan for selected client";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(1016, 353);
            button7.Name = "button7";
            button7.Size = new Size(93, 58);
            button7.TabIndex = 12;
            button7.Text = "Add new plan";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1254, 420);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(dataGridView3);
            Controls.Add(label3);
            Controls.Add(dataGridView2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private DataGridView dataGridView2;
        private Label label3;
        private DataGridView dataGridView3;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}