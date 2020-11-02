using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge5_Repo
{
    public class C5Emails
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType CustomerType { get; set; }
        public C5Emails() { }

        public C5Emails(string id, string firstName, string lastName, CustomerType customerType)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerType = customerType;
            ID = id;
        }
    }
    public enum CustomerType
    {
        Current,
        Past,
        Potential
    }

}

