using System;
using System.Collections.Generic;
using _05_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_Challenge_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckAddCustomerToList()
        {
            CustomerRepository customerRepo = new CustomerRepository();
            Customer customer = new Customer(CustomerType.Current, "Joe", "Montana", "joe@49ers.com", 2157);

            customerRepo.AddCustomerToList(customer);
            List<Customer> list = customerRepo.GetCustomerList();

            int actual = 1;
            int expected = list.Count;

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(list.Contains(customer));
        }

        [TestMethod]
        public void CheckRemoveCustomerFromList()
        {
            CustomerRepository customerRepo = new CustomerRepository();
            Customer customer = new Customer(CustomerType.Current, "Joe", "Montana", "joe@49ers.com", 2157);
            Customer customerTwo = new Customer(CustomerType.Past, "Barry", "Sanders", "joe@49ers.com", 2157);


            customerRepo.AddCustomerToList(customer);
            customerRepo.AddCustomerToList(customerTwo);

            customerRepo.RemoveCustomerFromList(customer);
            List<Customer> list = customerRepo.GetCustomerList();

            int actual = customerRepo.GetCustomerList().Count;
            int expected = list.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckViewCustomerProfileById()
        {
            CustomerRepository customerRepo = new CustomerRepository();
            Customer customer = new Customer(CustomerType.Current, "Joe", "Montana", "joe@49ers.com", 2157);

            customerRepo.ViewCustomerProfileById(2157);

            int actual = customer.CustomerId;
            int expected = 2157;

            Assert.AreEqual(expected, actual);

        }
    } 
}
