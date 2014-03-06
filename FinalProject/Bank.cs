using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProject
{
    class Bank
    {
        private List<Teller> tellerList;
        public BankQueue BankQueue { get; set; }
        public CustomerList Customers { get; set; }
        public BankVault Vault { get; set; }
        public Bank(UIHelper uiHelper, CancellationToken ct, int numTellers, int numCustomers, decimal custInitialAmount, decimal initialBankVaultBalance) 
        {
            //Task buildBank = Task.Factory.StartNew(() => {
            //    BankQueue = new BankQueue(ct);
            //    Customers = new CustomerList(numCustomers, custOpeningBalance, uiHelper);
            //    Vault = new BankVault(initialBankVaultBalance);
            //}, ct).ContinueWith((antecedent) =>
            //{
            //    uiHelper.GeneralMessage("Bank created.");
            //    uiHelper.GeneralMessage("BankQueue created. " + BankQueue.ToString());
            //    uiHelper.GeneralMessage("CustomerList created. " + Customers.ToString());
            //    uiHelper.GeneralMessage("BankVault created. " + Vault.ToString());


            //    tellerList = new List<Teller>();
            //    for (int i = 0; i < numTellers; i++)
            //    {
            //        tellerList.Add(new Teller(uiHelper, ct, this));
            //    }
            //}, ct);


            BankQueue = new BankQueue(ct);
            Customers = new CustomerList(numCustomers, custInitialAmount, uiHelper);
            Vault = new BankVault(initialBankVaultBalance);
            tellerList = new List<Teller>();
            for (int i = 0; i < numTellers; i++)
            {
                tellerList.Add(new Teller(uiHelper, ct, this));
            }

        }


    }
}
