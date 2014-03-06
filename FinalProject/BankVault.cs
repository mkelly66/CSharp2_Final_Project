using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class BankVault
    {
        private decimal bankBalance;
        private object vaultLock = new Object();

        public BankVault(decimal bankBalance) 
        {
            lock (vaultLock)
            {
                this.bankBalance = bankBalance;
            }
        }

        public decimal Deposit(decimal amount) 
        {
            lock(vaultLock)
            {
                bankBalance += amount;
                return bankBalance;
            }
            
        }

        public bool Withdraw(decimal withdrawalAmount, out decimal bankBalanceOut) 
        {
            lock (vaultLock)
            {
                decimal temp = this.bankBalance - withdrawalAmount;

                if (temp >= 0)
                {
                    this.bankBalance = temp;
                    bankBalanceOut = this.bankBalance;
                    return true;
                }
                else
                {
                    // CancelTokenSource.Cancel();
                    bankBalanceOut = this.bankBalance;
                    return false;
                }
                
            }
        }

    }
}
