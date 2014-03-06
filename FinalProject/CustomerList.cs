using System;
using System.Collections.Generic;

namespace FinalProject
{
    class CustomerList
    {
        private List<Customer> customerList;

        private object customerListLock = new object();
        private Random ran = new Random();

        private UIHelper uiHelper;

        public CustomerList(int numCustomers, decimal initialAmount, UIHelper uiHelper) 
        {
            this.uiHelper = uiHelper;
            
            lock (customerListLock)
            {
                Customer tempCust;
                customerList = new List<Customer>();

                for (int i = 0; i < numCustomers; i++)
                {
                    tempCust = new Customer("cust" + i, initialAmount);

                    customerList.Add(tempCust);
                    //uiHelper.GeneralMessage("Added customer cust" + i+" to customerList="+customerList.ToString());
                }
            }
        }
        public int GetCustomerCount()
        {
            int listCount;
            try
            {
                lock (customerListLock)
                {
                    listCount = customerList.Count;
                    return listCount;
                }
            }
            catch (Exception ex)
            {
                uiHelper.GeneralMessage("Exception in GetCustomerCount().  Message="+ex.Message);
                listCount = -1;
            }
            return listCount;
        }
        public Customer GetRandomCustomer()
        {
            Customer tempCustomer;

            int listCount;
            int customerIndex;
            try
            {
                lock (customerListLock)
                {
                    listCount = customerList.Count;

                    if (listCount > 0)
                    {
                        customerIndex = ran.Next(customerList.Count);
                        tempCustomer = customerList[customerIndex];
                        customerList.Remove(tempCustomer);
                        //int tempCustomerCount = customerList.Count + 1;
                        //int tempIndex = customerIndex + 1;
                        //uiHelper.GeneralMessage("Selected Customer #" + tempIndex.ToString() + " of " + tempCustomerCount.ToString() + " available customers.");
                        //Thread.Sleep(60);
                    }
                    else
                    {
                        uiHelper.GeneralMessage("Return NULL! No available customers found. listCount=" + listCount.ToString());
                        tempCustomer =  null;
                    }
                    return tempCustomer;
                }
            }
            catch (Exception except)
            {
                uiHelper.GeneralMessage("Exception in GetRandomCustomer().  message="+except.Message);
            }

            return null;
        }        
        

        public void SetCustomer(Customer customer) 
        {
            lock (customerListLock)
            {
                int listCount = customerList.Count;
                uiHelper.GeneralMessage("Customer being returned to the available list!  count="+listCount);
                customerList.Add(customer);
                listCount = customerList.Count;
                uiHelper.GeneralMessage("Customer has been returned to the available list!  count=" + listCount);
            }
        }
    }
}
