using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FinalProject
{
    class Teller
    {
        private Bank bank;
        private CancellationToken cancelToken;
        private Task task;
        private UIHelper uiHelper;
        private decimal customerGoalAmount;

        public Teller(UIHelper uiHelper, CancellationToken ct, Bank b) 
        {
            this.uiHelper = uiHelper;
            this.cancelToken = ct;
            this.bank = b;
            this.customerGoalAmount = uiHelper.GetCustomerGoalAmount();     // a bit of a hack

            task = Task.Factory.StartNew(TellerProc, cancelToken);
            uiHelper.AddTellerStartedMessage(task.Id);
        }

        private void TellerProc()
        {
            Transaction dequeuedTransaction;


            try
            {
                while (true)
                {
                    if (cancelToken.IsCancellationRequested)
                    {
                        TaskStatus ts = Stop();
                        //uiHelper.GeneralMessage("Teller with TaskId=" + Task.CurrentId + " cancellation was requested");
                        cancelToken.ThrowIfCancellationRequested();
                    }
                    //uiHelper.GeneralMessage("1.Teller.................(with TaskID=" + Task.CurrentId + ")");
                    dequeuedTransaction = bank.BankQueue.Dequeue();

                    //uiHelper.GeneralMessage("2.Teller.........................(with TaskID=" + Task.CurrentId + ")");
                    ProcessTransaction(dequeuedTransaction);
                    //uiHelper.GeneralMessage("3.Teller.................................(with TaskID=" + Task.CurrentId +")");
                }
            }
            catch (NullReferenceException nre)
            {
                uiHelper.GeneralMessage("EXCEPTION (NullReferenceException) in TellerProc (with TaskID=" +
                                        Task.CurrentId + "). Message: " + nre.Message);

                uiHelper.GeneralMessage("...StackTrace: " + nre.StackTrace);
                uiHelper.GeneralMessage("...Target Site: " + nre.TargetSite);
            }
            catch (OperationCanceledException oce)
            {
                //uiHelper.GeneralMessage("EXCEPTION (OperationCanceledException) in TellerProc (with TaskID=" +
                //                        Task.CurrentId + "). Message: " +
                //                        "   StackTrace: " + oce.StackTrace + "  Target Site: " + oce.TargetSite);
                throw;
            }
            catch(Exception ex)
            {
                uiHelper.GeneralMessage("EXCEPTION in TellerProc (with TaskID=" + Task.CurrentId + "). Message=" + ex.Message);
            }
        }


        private void ProcessTransaction(Transaction t)
        {
            string tempString;
            decimal balanceOut;
            bool transactionSuccess = false;
            bool overdraftFlag;

            //uiHelper.GeneralMessage("2.5. Teller  started processing transaction...(with TaskID=" + Task.CurrentId + ")");
            
            Customer  activeCustomer = t.Customer;
            TransactionType ttype = t.Type;
            decimal amount = t.Amount;
            decimal customerBalance = activeCustomer.Balance;


            if (!IsAnOverdraft(ttype, customerBalance, amount))
            {

                transactionSuccess = UpdateBankVault(ttype, amount, out balanceOut);
                activeCustomer.AddTransaction(t);   // Update Customer History
                customerBalance = setAndgetNewCustomerBalance(t, transactionSuccess);

                // Output
                string resultString = (transactionSuccess) ? "SUCCEEDED" : "FAILED";
                tempString = string.Format("{0}: {1}  {2}  ${3}  customer balance: ${4}  bank balance: ${5}", resultString, activeCustomer.Name, ttype.ToString(), amount.ToString(), customerBalance.ToString(),balanceOut.ToString());
                uiHelper.GeneralMessage(tempString);

                if (transactionSuccess && ((balanceOut - amount) <= 0))
                {
                    tempString = string.Format("BANK IS OUT OF FUNDS!: Customer: {0}  Transaction Amount: ${1}    Customer Balance:  ${2}  Bank Balance: ${3}", activeCustomer.Name, amount.ToString(), customerBalance.ToString(), balanceOut.ToString());
                    uiHelper.GeneralMessage(tempString);
                    Stop();
                }



                if (customerBalance >= this.customerGoalAmount)
                {
                    tempString = string.Format("{0}: <{1} - ${2}>", "CUSTOMER GOAL ACHIEVED", activeCustomer.Name, customerBalance.ToString());
                    uiHelper.GeneralMessage(tempString);

                    // Display Transaction History
                    displayTransactionHistory(activeCustomer);

                    Stop();
                }
            }
            //uiHelper.GeneralMessage("3. Teller is processing transaction...");

            // Return Customer to customer pool
            bank.Customers.SetCustomer(activeCustomer);
            //uiHelper.GeneralMessage("4.Teller finished processing transaction...");
        }

        private void displayTransactionHistory(Customer activeCustomer)
        {
            List<Transaction> transactionHistory = activeCustomer.TransactionHistory;
            foreach (Transaction trans in transactionHistory)
            {
                
            }
        }


        private decimal setAndgetNewCustomerBalance(Transaction t, bool transactionSuccess)
        {

            Customer activeCustomer = t.Customer;
            TransactionType ttype = t.Type;
            decimal amount = t.Amount;
            decimal customerBalance = activeCustomer.Balance;

            if (transactionSuccess)
            {
                if (ttype == TransactionType.Withdrawal)
                {
                    customerBalance = customerBalance - amount;
                }
                else
                {
                    customerBalance = customerBalance + amount;
                }
                // Save the new customer balance in the customer object
                activeCustomer.Balance = customerBalance;
            }
            return customerBalance;
        }


        private bool IsAnOverdraft(TransactionType ttype, decimal customerBalance, decimal amount)
        {
            bool overdraftFlag;

            if (ttype == TransactionType.Withdrawal)
            {
                overdraftFlag = (customerBalance - amount < 0) ? true : false;
            }
            else
            {
                overdraftFlag = false;
            }
            return overdraftFlag;
        }


        private bool UpdateBankVault(TransactionType ttype, decimal amount, out decimal balanceOut)
        {
            bool transactionSuccess;
            // Update BankVault
            if (ttype == TransactionType.Deposit)
            {
                balanceOut = bank.Vault.Deposit(amount);
                transactionSuccess = true;
            }
            //else if (ttype == TransactionType.Withdrawal)
            else
            {
                if (!bank.Vault.Withdraw(amount, out balanceOut))
                {
                    transactionSuccess = false;
                }
                else
                {
                    transactionSuccess = true;
                }
            }
            return transactionSuccess;
        }


        public TaskStatus Stop()
        {
            //uiHelper.GeneralMessage("Teller Stop() called (with TaskID=" + Task.CurrentId + ").");
            uiHelper.StopSimulation();
            TaskStatus ts = this.task.Status;
            return ts;
        }


    }
}
