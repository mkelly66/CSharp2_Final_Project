using System;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;

namespace FinalProject
{
    public partial class BankSimulatorForm : Form
    {
        internal BankSimulator bankSimulator;
        //internal BankSimulator BankSimulator { get; private set; }
        public WindowsFormsSynchronizationContext syncContext2;
        public SynchronizationContext syncContext;
        private UIHelper uiHelper;
      
        private int numTellers;
        private int numCustomers;
        internal decimal custGoalAmount;
        private decimal initialBankVaultBalance;
        private decimal maxTransAmount;
        private decimal custInitialAmount;

        private bool formDataLoadComplete = false;

        public void AddListBoxItem(string s) { }
        public void AddListBoxItems(string s, string[] sa) { }
        
        public BankSimulatorForm()
        {
            InitializeComponent();
            //syncContext2 = WindowsFormsSynchronizationContext.Current;
            syncContext = WindowsFormsSynchronizationContext.Current;
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            if (ValidateInputFields())
            {
                if (uiHelper == null)
                {
                    uiHelper = new UIHelper(this);
                }

                //if (bankSimulator == null)
                //{
                    //form.bankGroupBox1.Enabled = false;
                    //form.transactionsGroupBox2.Enabled = false;
                    //form.txbxCustGoalAmount.Enabled = false;

                    this.bankSimulator = new BankSimulator(uiHelper, numTellers, numCustomers, custGoalAmount, initialBankVaultBalance, maxTransAmount, custInitialAmount);
                //}
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (bankSimulator != null)
            {
                this.bankSimulator.Stop();
                //this.bankSimulator = null;
                bankGroupBox1.Enabled = true;
            }
            else
            {
                string temp = "Error: There is no bankSimulator object present to stop!";
                MessageBox.Show(temp);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private int GetConfigurationInt32(string s1, string s2, int number) { return number; }

        public void StartButtonState(bool b) { }
        public void StopButtonState(bool b) { }





        private void CalculateInitialCustomerAmount(string debug_called_from_what_location="<none given>")
        {
            if (!ValidateInputFieldsForInitCustomerAmount())
            {
                this.txbxCustInitialAmount.Text = "<undefined>";
                return;
            }
            string bankInitialVaultAmount = this.txbxBankInitialVaultAmount.Text;
            string bankNumberOfCustomers = this.txbxBankNumberOfCustomers.Text;
            int numberOfCustomers = Int32.Parse(bankNumberOfCustomers);

            if (numberOfCustomers == 0)
            {
                this.txbxCustInitialAmount.Text = "<undefined>";
                string temp = "The number of Customers must be greater than zero.  Please change that value.";
                MessageBox.Show(temp);
                this.txbxBankNumberOfCustomers.Focus();
                return;
            }

            custInitialAmount = decimal.Parse(bankInitialVaultAmount) / numberOfCustomers;
            this.txbxCustInitialAmount.Text = custInitialAmount.ToString();
        }



        private void BankSimulatorForm_Load(object sender, EventArgs e)
        {           
            string bankInitialVaultAmount;
            string bankNumberOfCustomers;
            string bankNumberOfTellers;
            string customerGoalAmount;
            string transMaxTransAmount;

            try
            {
                bankInitialVaultAmount = ConfigurationManager.AppSettings["BankInitialVaultAmount"];
                bankNumberOfCustomers = ConfigurationManager.AppSettings["BankNumberOfCustomers"];
                bankNumberOfTellers = ConfigurationManager.AppSettings["BankNumberOfTellers"];
                customerGoalAmount = ConfigurationManager.AppSettings["CustGoalAmount"];
                transMaxTransAmount = ConfigurationManager.AppSettings["TransMaxTransAmount"];

                // Check for Null or zero. If not, use it. If so, use a default.
                numCustomers = (!String.IsNullOrEmpty(bankNumberOfCustomers)) ? Int32.Parse(bankNumberOfCustomers) : 10;
                numTellers = (!String.IsNullOrEmpty(bankNumberOfTellers)) ? Int32.Parse(bankNumberOfTellers) : 2;
                custGoalAmount = (!String.IsNullOrEmpty(customerGoalAmount))
                    ? decimal.Parse(customerGoalAmount)
                    : (decimal) 600;
                initialBankVaultBalance = (!String.IsNullOrEmpty(bankInitialVaultAmount))
                    ? decimal.Parse(bankInitialVaultAmount)
                    : 5000;
                maxTransAmount = (!String.IsNullOrEmpty(transMaxTransAmount))
                    ? decimal.Parse(transMaxTransAmount)
                    : (decimal) 200;


                this.txbxBankNumberOfCustomers.Text = numCustomers.ToString();
                this.txbxBankNumberOfTellers.Text = numTellers.ToString();
                this.txbxCustGoalAmount.Text = custGoalAmount.ToString();
                this.txbxBankInitialVaultAmount.Text = initialBankVaultBalance.ToString();
                this.txbxTransMaxTransAmount.Text = maxTransAmount.ToString();

                formDataLoadComplete = true;

                CalculateInitialCustomerAmount("BankSimulatorForm_Load()");
            }
            catch (Exception except)
            {
                uiHelper.GeneralMessage("Exception thrown in BankSimulatorForm Load event.  Message="+except.Message);
            }

            bool fieldsGood = ValidateInputFields();
        }

        private bool ValidateInputFields()
        {
            if (!ValidateInputFieldsForInitCustomerAmount() ||
                !ValidateInputFieldNumberOfTellers() ||
                !ValidateInputFieldCustomerGoalAmount() ||
                !ValidateInputFieldMaximumTransactionAmount() ||
                !ValidateInputFieldInitialVaultBalance() ||
                !ValidateInputFieldNumberOfCustomers())
            {
                return false;
            }

            return true;
        }


        private bool ValidateInputFieldsForInitCustomerAmount()
        {

            if (!ValidateInputFieldInitialVaultBalance())
            {
                return false;
            }

            if (!ValidateInputFieldNumberOfCustomers())
            {
                return false;
            }
            return true;
        }

        private bool ValidateInputFieldInitialVaultBalance()
        {
            decimal bankInitialVaultAmount;
            int bankNumberOfCustomers;

            bool validate1 = Decimal.TryParse(txbxBankInitialVaultAmount.Text, out bankInitialVaultAmount);
            if (!validate1)
            {
                string temp = "The value in the bank's InitialValueAmount is incorrect. Please fix it.";
                MessageBox.Show(temp);
                this.txbxBankInitialVaultAmount.Focus();
                return false;
            }
            initialBankVaultBalance = bankInitialVaultAmount;
            return true;
        }

        private bool ValidateInputFieldNumberOfCustomers()
        {
            int bankNumberOfCustomers;

            bool validate2 = Int32.TryParse(txbxBankNumberOfCustomers.Text, out bankNumberOfCustomers);
            if (!validate2)
            {
                string temp = "The value in the bank's NumberOfCustomers is incorrect. Please fix it.";
                MessageBox.Show(temp);
                this.txbxBankNumberOfCustomers.Focus();
                return false;
            }
            if (bankNumberOfCustomers == 0)
            {
                string temp = "The number of customers cannot be zero. Please fix it.";
                MessageBox.Show(temp);
                this.txbxBankNumberOfCustomers.Focus();
                return false;
            }
            numCustomers = bankNumberOfCustomers;
            return true;   
        }

        private bool ValidateInputFieldNumberOfTellers()
        {
            int bankNumberOfTellers;

            bool validate3 = Int32.TryParse(txbxBankNumberOfTellers.Text, out bankNumberOfTellers);
            if (!validate3)
            {
                string temp = "The value in the bank's NumberOfTellers is incorrect. Please fix it.";
                MessageBox.Show(temp);
                this.txbxBankNumberOfTellers.Focus();
                return false;
            }
            numTellers = bankNumberOfTellers;
            return true;
        }

        private bool ValidateInputFieldCustomerGoalAmount()
        {
            decimal customerGoalAmount;

            bool validate4 = Decimal.TryParse(txbxCustGoalAmount.Text, out customerGoalAmount);
            if (!validate4)
            {
                string temp = "The value in the customer's Goal Amount is incorrect. Please fix it.";
                MessageBox.Show(temp);
                this.txbxCustGoalAmount.Focus();
                return false;
            }
            custGoalAmount = customerGoalAmount;
            return true;
        }

        private bool ValidateInputFieldMaximumTransactionAmount()
        {
            decimal transMaxTransAmount;

            bool validate5 = Decimal.TryParse(txbxTransMaxTransAmount.Text, out transMaxTransAmount);
            if (!validate5)
            {
                string temp = "The value in the Maximum Transaction Amount is incorrect. Please fix it.";
                MessageBox.Show(temp);
                this.txbxTransMaxTransAmount.Focus();
                return false;
            }
            maxTransAmount = transMaxTransAmount;
            return true;
        }




        private void UpdateCustomerInitialAmount(string s1, string s2) { }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txbxBankInitialVaultAmount_TextChanged(object sender, EventArgs e)
        {
            if (formDataLoadComplete)
            {
                CalculateInitialCustomerAmount("txbxBankInitialVaultAmount_TextChanged()");
            }
        }

        private void txbxBankNumberOfCustomers_TextChanged(object sender, EventArgs e)
        {
            if (formDataLoadComplete)
            {
                CalculateInitialCustomerAmount("txbxBankNumberOfCustomers_TextChanged()");
            }
        }

        private void txbxCustGoalAmount_TextChanged(object sender, EventArgs e)
        {
            ValidateInputFieldCustomerGoalAmount();
        }

        private void txbxBankNumberOfTellers_TextChanged(object sender, EventArgs e)
        {
            ValidateInputFieldNumberOfTellers();
        }

        private void txbxTransMaxTransAmount_TextChanged(object sender, EventArgs e)
        {
            ValidateInputFieldMaximumTransactionAmount();
        }

    }
}
