using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Challenge_Repository
{
    public enum CustomerType
    {
        Potential = 1, Current, Past   
    }
    public class Customer
    {
        public CustomerType CType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CustomerId { get; set; }

        public Customer() { }

        public Customer (CustomerType Ctype, string firstName, string lastName, string email, int customerId)
        {
            CType = Ctype;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CustomerId = customerId;
        }

    }
}
