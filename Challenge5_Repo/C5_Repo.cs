using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge5_Repo
{
    public class C5_Repo
    {
        public List<C5Emails> customers = new List<C5Emails>();
        public void AddToList() { }
        public bool AddToList(C5Emails newItem)
        {
            int startingCount = customers.Count;
            customers.Add(newItem);
            bool wasAdded = (customers.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<C5Emails> GetCustomers()
        {
            return customers;
        }

        public C5Emails GetCustomerByID(string id)
        {
            foreach (C5Emails customer in customers)
            {
                if (customer.ID == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public bool UpdateExistingCustomer(string originalID, C5Emails newCustomer)
        {
            C5Emails oldcustomer = GetCustomerByID(originalID);

            if (oldcustomer != null)
            {
                oldcustomer.ID = newCustomer.ID;
                oldcustomer.FirstName = newCustomer.FirstName;
                oldcustomer.LastName = newCustomer.LastName;
                oldcustomer.CustomerType = newCustomer.CustomerType;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteExisting(C5Emails existingCustomer)
        {
            bool deleteResult = customers.Remove(existingCustomer);
            return deleteResult;
        }
    }
}
