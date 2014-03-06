namespace FinalProject
{
    partial class BankSimulatorForm
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.bankGroupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbxBankNumberOfTellers = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbxBankNumberOfCustomers = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbxBankInitialVaultAmount = new System.Windows.Forms.TextBox();
            this.transactionsGroupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbxTransMaxTransAmount = new System.Windows.Forms.TextBox();
            this.CustomerGroupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbxCustGoalAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbxCustInitialAmount = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bankGroupBox1.SuspendLayout();
            this.transactionsGroupBox2.SuspendLayout();
            this.CustomerGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(12, 516);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(93, 516);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(648, 516);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // bankGroupBox1
            // 
            this.bankGroupBox1.Controls.Add(this.label3);
            this.bankGroupBox1.Controls.Add(this.txbxBankNumberOfTellers);
            this.bankGroupBox1.Controls.Add(this.label2);
            this.bankGroupBox1.Controls.Add(this.txbxBankNumberOfCustomers);
            this.bankGroupBox1.Controls.Add(this.label1);
            this.bankGroupBox1.Controls.Add(this.txbxBankInitialVaultAmount);
            this.bankGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.bankGroupBox1.Name = "bankGroupBox1";
            this.bankGroupBox1.Size = new System.Drawing.Size(346, 179);
            this.bankGroupBox1.TabIndex = 3;
            this.bankGroupBox1.TabStop = false;
            this.bankGroupBox1.Text = "Bank";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Number of Tellers";
            // 
            // txbxBankNumberOfTellers
            // 
            this.txbxBankNumberOfTellers.Location = new System.Drawing.Point(145, 16);
            this.txbxBankNumberOfTellers.Name = "txbxBankNumberOfTellers";
            this.txbxBankNumberOfTellers.Size = new System.Drawing.Size(100, 20);
            this.txbxBankNumberOfTellers.TabIndex = 8;
            this.txbxBankNumberOfTellers.TextChanged += new System.EventHandler(this.txbxBankNumberOfTellers_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Number of Customers";
            // 
            // txbxBankNumberOfCustomers
            // 
            this.txbxBankNumberOfCustomers.Location = new System.Drawing.Point(145, 59);
            this.txbxBankNumberOfCustomers.Name = "txbxBankNumberOfCustomers";
            this.txbxBankNumberOfCustomers.Size = new System.Drawing.Size(100, 20);
            this.txbxBankNumberOfCustomers.TabIndex = 7;
            this.txbxBankNumberOfCustomers.TextChanged += new System.EventHandler(this.txbxBankNumberOfCustomers_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Initial Vault Amount";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txbxBankInitialVaultAmount
            // 
            this.txbxBankInitialVaultAmount.Location = new System.Drawing.Point(145, 103);
            this.txbxBankInitialVaultAmount.Name = "txbxBankInitialVaultAmount";
            this.txbxBankInitialVaultAmount.Size = new System.Drawing.Size(100, 20);
            this.txbxBankInitialVaultAmount.TabIndex = 6;
            this.txbxBankInitialVaultAmount.TextChanged += new System.EventHandler(this.txbxBankInitialVaultAmount_TextChanged);
            // 
            // transactionsGroupBox2
            // 
            this.transactionsGroupBox2.Controls.Add(this.label6);
            this.transactionsGroupBox2.Controls.Add(this.txbxTransMaxTransAmount);
            this.transactionsGroupBox2.Location = new System.Drawing.Point(378, 12);
            this.transactionsGroupBox2.Name = "transactionsGroupBox2";
            this.transactionsGroupBox2.Size = new System.Drawing.Size(345, 146);
            this.transactionsGroupBox2.TabIndex = 4;
            this.transactionsGroupBox2.TabStop = false;
            this.transactionsGroupBox2.Text = "Transactions";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Max Transaction Amount";
            // 
            // txbxTransMaxTransAmount
            // 
            this.txbxTransMaxTransAmount.Location = new System.Drawing.Point(142, 16);
            this.txbxTransMaxTransAmount.Name = "txbxTransMaxTransAmount";
            this.txbxTransMaxTransAmount.Size = new System.Drawing.Size(100, 20);
            this.txbxTransMaxTransAmount.TabIndex = 11;
            this.txbxTransMaxTransAmount.TextChanged += new System.EventHandler(this.txbxTransMaxTransAmount_TextChanged);
            // 
            // CustomerGroupBox3
            // 
            this.CustomerGroupBox3.Controls.Add(this.label4);
            this.CustomerGroupBox3.Controls.Add(this.txbxCustGoalAmount);
            this.CustomerGroupBox3.Controls.Add(this.label5);
            this.CustomerGroupBox3.Controls.Add(this.txbxCustInitialAmount);
            this.CustomerGroupBox3.Location = new System.Drawing.Point(12, 207);
            this.CustomerGroupBox3.Name = "CustomerGroupBox3";
            this.CustomerGroupBox3.Size = new System.Drawing.Size(711, 100);
            this.CustomerGroupBox3.TabIndex = 5;
            this.CustomerGroupBox3.TabStop = false;
            this.CustomerGroupBox3.Text = "Customer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Goal Amount";
            // 
            // txbxCustGoalAmount
            // 
            this.txbxCustGoalAmount.Location = new System.Drawing.Point(145, 16);
            this.txbxCustGoalAmount.Name = "txbxCustGoalAmount";
            this.txbxCustGoalAmount.Size = new System.Drawing.Size(100, 20);
            this.txbxCustGoalAmount.TabIndex = 9;
            this.txbxCustGoalAmount.TextChanged += new System.EventHandler(this.txbxCustGoalAmount_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(372, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Initial Amount";
            // 
            // txbxCustInitialAmount
            // 
            this.txbxCustInitialAmount.Location = new System.Drawing.Point(508, 16);
            this.txbxCustInitialAmount.Name = "txbxCustInitialAmount";
            this.txbxCustInitialAmount.ReadOnly = true;
            this.txbxCustInitialAmount.Size = new System.Drawing.Size(100, 20);
            this.txbxCustInitialAmount.TabIndex = 10;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(12, 350);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(711, 160);
            this.listBox1.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 334);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Transaction History";
            // 
            // BankSimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 551);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.CustomerGroupBox3);
            this.Controls.Add(this.transactionsGroupBox2);
            this.Controls.Add(this.bankGroupBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "BankSimulatorForm";
            this.Text = "Bank Teller Simultion";
            this.Load += new System.EventHandler(this.BankSimulatorForm_Load);
            this.bankGroupBox1.ResumeLayout(false);
            this.bankGroupBox1.PerformLayout();
            this.transactionsGroupBox2.ResumeLayout(false);
            this.transactionsGroupBox2.PerformLayout();
            this.CustomerGroupBox3.ResumeLayout(false);
            this.CustomerGroupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox CustomerGroupBox3;
        private System.Windows.Forms.TextBox txbxBankInitialVaultAmount;
        private System.Windows.Forms.TextBox txbxBankNumberOfCustomers;
        private System.Windows.Forms.TextBox txbxBankNumberOfTellers;
        private System.Windows.Forms.TextBox txbxCustInitialAmount;
        private System.Windows.Forms.TextBox txbxTransMaxTransAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ListBox listBox1;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.Button btnStop;
        internal System.Windows.Forms.GroupBox bankGroupBox1;
        internal System.Windows.Forms.GroupBox transactionsGroupBox2;
        internal System.Windows.Forms.TextBox txbxCustGoalAmount;
    }
}

