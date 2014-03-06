using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    class Customer
    {
        private List<Transaction> customerHistory;

        public void AddTransaction(Transaction transaction)
        {
            customerHistory.Add(transaction);
        }

        public Customer(string name, decimal initialAmount) 
        {
            Name = name;
            Balance = initialAmount;            
            TransactionHistory = new List<Transaction>();
        }

        public decimal Balance { get; set; }
        public string Name { get; set; }
        public List<Transaction> TransactionHistory { get { return customerHistory;  }  set { customerHistory = value; } }

        public override string ToString()
        {
            return Name;
        }
    }
}
