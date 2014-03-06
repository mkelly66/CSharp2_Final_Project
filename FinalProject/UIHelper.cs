using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class UIHelper
    {
        private BankSimulatorForm form;
        public void AddBankOutOfFundsCustomerTransaction(Transaction t, decimal number1) { }
        public void AddCustomerTransaction(Transaction t, decimal number1, bool b) { }
        public void AddListBoxItems(string s, string[] sa) { }
        public void AddTellerStartedMessage(int? taskID)
        {
            bool b = true;
            form.syncContext.Post((b1) =>
            {
                form.listBox1.Items.Add("Teller started (TaskID="+taskID+").");
                form.listBox1.SelectedIndex = form.listBox1.Items.Count - 1;
            }, b);
        }
        public void AddTellerStoppedMessage()
        {
            bool b = true;
            form.syncContext.Post((b1) =>
            {
                form.listBox1.Items.Add("Teller stopped.");
                form.listBox1.SelectedIndex = form.listBox1.Items.Count - 1;
            }, b);
        }
        public void AddThreadIdMessage(string s1, string s2)
        {
            //object obj = new Object() {s1, s2};
            //bool b = true;
            //form.syncContext.Send((obj1) =>
            //{
            //    form.listBox1.Items.Add("Thread id("+(string)obj1.s1+")("+(string)obj1.s2 +").");
            //    form.listBox1.SelectedIndex = form.listBox1.Items.Count - 1;
            //}, obj);
        }
        public void AddTransactionGeneratorStartedMessage() 
        {
            bool b = true;
            form.syncContext.Post((b1) =>
            {
                form.listBox1.Items.Add("Transaction Generator Started.");
                form.listBox1.SelectedIndex = form.listBox1.Items.Count - 1;
            }, b);       
        }
        public void AddTransactionGeneratorStoppedMessage()
        {
            bool b = true;
            form.syncContext.Post((b1) =>
            {
                form.listBox1.Items.Add("Transaction Generator Stopped.");
                form.listBox1.SelectedIndex = form.listBox1.Items.Count - 1;
            }, b);   
        }
        public void StartButton(bool b) 
        {
            form.syncContext.Post((b1)=>{
                form.listBox1.Items.Add("Simulation started!");
                form.listBox1.SelectedIndex = form.listBox1.Items.Count - 1;
                form.btnStart.Enabled = false;
                form.btnStop.Enabled = true;

                form.bankGroupBox1.Enabled = false;
                form.transactionsGroupBox2.Enabled = false;
                form.txbxCustGoalAmount.Enabled = false;
            },  b);
        }
        public void StopButton(bool b)
        {
            form.syncContext.Post((b1) =>
            {
                form.listBox1.Items.Add("Simulation stopped!");
                form.listBox1.SelectedIndex = form.listBox1.Items.Count - 1;
                form.btnStart.Enabled = true;
                form.btnStop.Enabled = false;

                form.bankGroupBox1.Enabled = true;
                form.transactionsGroupBox2.Enabled = true;
                form.txbxCustGoalAmount.Enabled = true;

            }, b);
            
        }
        public void GeneralMessage(string message)
        {
            form.syncContext.Post((msg) =>
            {
                form.listBox1.Items.Add(msg);
                form.listBox1.SelectedIndex = form.listBox1.Items.Count - 1;
            }, message);
        }
        public UIHelper(BankSimulatorForm bsf) 
        {
            this.form = bsf;
        }

        public decimal GetCustomerGoalAmount()
        {
            return form.custGoalAmount;
        }
        public void StopSimulation()
        {
            BankSimulatorForm bsf = this.form;
            BankSimulator bs = bsf.bankSimulator;

            bs.Stop();
        }

    }
}
