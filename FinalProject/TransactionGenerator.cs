using System;

using System.Threading.Tasks;
using System.Threading;

using System.Configuration;

namespace FinalProject
{
    class TransactionGenerator
    {
        private CancellationToken cancelToken;
        private CustomerList customerList;
        private decimal maxTransAmount;
        private Random rand = new Random();
        private Task task;
        private int timeoutThrottle;
        private UIHelper uiHelper;

        private BankQueue bankQueue;

        public TransactionGenerator(UIHelper uiHelper, CancellationToken ct, BankQueue bq, CustomerList cl, decimal maxTransactionAmount, int timeoutThrottle) 
        {
            try
            {
                this.uiHelper = uiHelper;
                this.cancelToken = ct;
                this.maxTransAmount = maxTransactionAmount;
                if (cl == null)
                {
                    uiHelper.GeneralMessage("DEBUG: The 'cl' (CustomerList) IS NULL!!!!");
                }
                this.customerList = cl;

                if (timeoutThrottle < 1) timeoutThrottle = 1;
                this.timeoutThrottle = timeoutThrottle;

                this.bankQueue = bq;

                this.task = Task.Factory.StartNew(TransactionGeneratorProc, cancelToken);
            }
            catch(Exception ex)
            {
                uiHelper.GeneralMessage("Exception in the Transaction Generator().  Message=" + ex.Message);
            }
        }

        private void TransactionGeneratorProc(object arg)
        {
            try
            {
                int counter = 0;
                Transaction tempTransaction;

                while (true)
                {
                    counter++;
                    if (cancelToken.IsCancellationRequested)
                    {
                        TaskStatus ts = this.Stop();
                        //uiHelper.GeneralMessage("TransactionGenerator Stopped with TaskStatus=" + ts.ToString());
                        cancelToken.ThrowIfCancellationRequested();
                    }
                    Thread.Sleep(this.timeoutThrottle);

                    tempTransaction = CreateTransaction();
                    bankQueue.Enqueue(tempTransaction);
                    //uiHelper.GeneralMessage("444. Finished TransactionGeneratorProc...count=" + counter.ToString());
                }
            }
            catch (OperationCanceledException oce)
            {
                //uiHelper.GeneralMessage("EXCEPTION (OperationCanceledException) in TransactionGeneratorProc() (with TaskID=" +
                //                        Task.CurrentId + "). Message: " +
                //                        "   StackTrace: " + oce.StackTrace + "  Target Site: " + oce.TargetSite);

            }
            catch(Exception except)
            {
                uiHelper.GeneralMessage("Exception in TransactionGeneratorProc. Message: "+except.Message);
            }
        }
        private Transaction CreateTransaction() 
        {
            Customer tempCustomer;

            //try
            //{
                Thread.Sleep(timeoutThrottle);

                // Set random Transaction 
                int randTranType = rand.Next(2);
                TransactionType tranType = (randTranType == 0) ? TransactionType.Withdrawal : TransactionType.Deposit;
                //////TransactionType tranType = TransactionType.Withdrawal;    // Force everything to be a withdrawal (for testing)

                int randTranAmountTemp = rand.Next((int)(this.maxTransAmount+1));
                decimal randTranAmount = (decimal)randTranAmountTemp;

                if (customerList == null)
                {
                    uiHelper.GeneralMessage("CustomerList is NULL!!!!!!!!!!!!!!!");
                }

                //uiHelper.GeneralMessage("CreateTransaction().CustomerCount = " + customerList.GetCustomerCount());

                // Set random Available Customer
                while ((tempCustomer = customerList.GetRandomCustomer()) == null)
                {
                    uiHelper.GeneralMessage("Waiting while polling the getRandomCustomer() to get an available Customer. ");
                    Thread.Sleep(30000);
                }



                //uiHelper.GeneralMessage("After while loop to get an available Customer. tempCustomer="+tempCustomer.ToString());

                //uiHelper.GeneralMessage("TransGen: Generating Transaction  for " + tempCustomer.ToString() + " " + tranType.ToString() + "  $" + randTranAmount.ToString());
                return new Transaction(tempCustomer, randTranAmount, tranType);
            //}
            //catch (Exception except)
            //{
            //    uiHelper.GeneralMessage("Exception in CREATETRANSACTION(). Message: " + except.Message+" other: "+except.StackTrace);
            //    Thread.Sleep(4000);
            //}
            //return new Transaction(new Customer("Mike", 1), 100, TransactionType.Deposit);
        }
        public TaskStatus Stop() 
        {
            //uiHelper.GeneralMessage("TransactionGenerator Stop() called.");
            return new TaskStatus();  // placeholder
        }

        


    }
}
