using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Challenge_Repository
{
    public class CustomerRepository
    {
        private List<Customer> _customerList = new List<Customer>();

        public void AddCustomerToList(Customer newCustomer)
        {
            _customerList.Add(newCustomer);
        }

        public void RemoveCustomerFromList(Customer customer)
        {
            _customerList.Remove(customer);
        }

        public List<Customer> GetCustomerList()
        {
            return _customerList;
        }

        public Customer ViewCustomerProfileById(int ID)
        {
            foreach(Customer c in _customerList)
            {
                if(c.CustomerId == ID)
                {
                    return c;
                }
            }return null;
        }

        public CustomerType ChooseCustomerType(int typeChoice)
        {
            CustomerType type = new CustomerType();
            switch (typeChoice)
            {
                case 1:
                    type = CustomerType.Potential;
                    break;
                case 2:
                    type = CustomerType.Current;
                    break;
                case 3: type = CustomerType.Past;
                    break;
                default:
                    break;
            }
            return type;
        }
    }   

}
