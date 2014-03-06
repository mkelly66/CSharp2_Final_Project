using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    class Transaction
    {
        public Transaction(Customer cust, decimal transactionAmount, TransactionType ttype) 
        {
            Amount = transactionAmount;
            Customer = cust;
            Type = ttype;
        }

        public decimal Amount { get; set; }

        public Customer Customer { get; set; }

        public TransactionType Type { get; set; }

    }
}
