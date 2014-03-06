using System.Threading;


namespace FinalProject
{
    class BankSimulator
    {
        private Bank bank;
        private CancellationTokenSource cancelTokenSource;
        private TransactionGenerator transactionGenerator;

        private UIHelper uiHelper;

        public BankSimulator(UIHelper uiHelper, int numTellers, int numCustomers, decimal custGoalAmount, decimal initialBankVaultBalance, 
                                decimal maxTransactionAmount, decimal custInitialAmount) 
        {
            uiHelper.StartButton(true);

            this.uiHelper = uiHelper;
            this.cancelTokenSource = new CancellationTokenSource();
            CancellationToken ct = cancelTokenSource.Token;
            int timeoutThrottle = 10;


            this.bank = new Bank(uiHelper, ct, numTellers, numCustomers, custInitialAmount, initialBankVaultBalance);
                        

            // Cannot start the transaction Generator until the CustomerList is ready (ie not null)
            while (bank.Customers==null) {
                Thread.Sleep(100);
            }

            this.transactionGenerator = new TransactionGenerator(uiHelper, ct, bank.BankQueue, bank.Customers, maxTransactionAmount, timeoutThrottle);
        }

        public void Stop() 
        {
            cancelTokenSource.Cancel();
            uiHelper.StopButton(true);
        }
    }
}
