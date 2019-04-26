using _05_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Challenge_Console
{
    public class ProgramUI
    {
        CustomerRepository _customerRepo = new CustomerRepository();

        List<Customer> _customerList = new List<Customer>();
        int _response;

        internal void Run()
        {
            while (_response != 6)
            {
                PrintMenu();
                SeedCustomerData();
                switch (_response)
                {
                    case 1:
                        SeeAllCustomersAlphabetically();
                        break;
                    case 2:
                        var customer = GetInputForNewUser();
                        _customerRepo.AddCustomerToList(customer);
                        break;
                    case 3:
                        RemoveCustomer();
                        break;
                    case 4:
                        UpdateCustomer();
                        break;
                    case 5:
                        EmailBlast();
                        break;
                    case 6:
                        Console.WriteLine("Have a nice day!");
                        break;
                    default:
                        Console.WriteLine("Please enter a correct value.");
                        break;
                }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("What would you like to do?\n\t" +
                "1. See All Customers\n\t" +
                "2. Add Customer\n\t" +
                "3. Remove Customer\n\t" +
                "4. Update Customer Profile\n\t" + 
                "5. Email Blast\n\t" +
                "6. Exit Program\n\t");
            _response = int.Parse(Console.ReadLine());
        }

        private void EmailBlast()
        {
            Console.WriteLine("Would you like to send emails now to all customers?");
            string yesOrNo = Console.ReadLine().ToLower();

            switch (yesOrNo)
            {
                case "y":
                case "yes": 
            List<Customer> list = _customerRepo.GetCustomerList();

            foreach(Customer c in list)
            {
                if(c.CType == CustomerType.Current)
                {
                    Console.WriteLine("Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
                }
                else if(c.CType == CustomerType.Potential)
                {
                    Console.WriteLine("We currently have the lowest rates on Helicopter Insurance!");
                }
                else if(c.CType == CustomerType.Past)
                {
                    Console.WriteLine("It's been a long time since we've heard from you, we want you back!");
                }
            }
                    break;
                case "n":
                case "no":
                    PrintMenu();
                    break;
            }

        }

        private void SeeAllCustomersAlphabetically()
        {
            List<Customer> list = _customerRepo.GetCustomerList();
            List<Customer> sortedList = list.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();

            Console.WriteLine("First Name  Last Name  Customer Type  Email Address  Customer ID");
            foreach(Customer c in sortedList)
            {
                Console.WriteLine($"{c.FirstName} {c.LastName} {c.CType} {c.Email} {c.CustomerId}");
            }Console.ReadLine();
        }

        private Customer GetInputForNewUser()
        {
            var Ctype = SelectACustomerType();
            var firstName = EnterFirstName();
            var lastName = EnterLastName();
            var email = EnterEmailAddress();
            var customerId = EnterCustomerId();

            return new Customer(Ctype, firstName, lastName, email, customerId);
        }

        private void RemoveCustomer()
        {
            Console.Clear();
            Console.WriteLine("Enter Customer ID to remove a profile.");

            int ID = int.Parse(Console.ReadLine());

            Customer c = _customerRepo.ViewCustomerProfileById(ID);

            if(c != null)
            {
                Console.WriteLine($"{c.CType}\n {c.FirstName}\n {c.LastName}\n {c.Email}\n {c.CustomerId}");
            }
            else
            {
                Console.WriteLine("There are no customers with this ID.");
            }
            //Console.ReadLine();

            _customerRepo.RemoveCustomerFromList(c);
            Console.WriteLine($"Customer ({c.FirstName} {c.LastName}) has been removed.");
            Console.ReadLine();
        }

        private void UpdateCustomer()
        {
            Console.WriteLine("Enter the customer ID for the profile you would like to update: ");
            int ID = int.Parse(Console.ReadLine());
            Customer customer = _customerRepo.ViewCustomerProfileById(ID);

            if(customer != null)
            {
                Console.WriteLine($"{customer.CType}\n {customer.FirstName}\n {customer.LastName}\n {customer.Email}\n {customer.CustomerId}");
            }

            Console.WriteLine("Which property would you like to update?\n\t" +
               "1.  Customer Type\n\t" +
               "2.  First Name\n\t" +
               "3.  Last Name\n\t" +
               "4.  Email\n\t" +
               "5.  Customer ID\n\t" + 
               "8.  No change");
            int propertyChoice = int.Parse(Console.ReadLine());
            switch (propertyChoice)
            {
                case 1:
                    Console.WriteLine($"The current customer type is {customer.CType}");
                    customer.CType = SelectACustomerType();
                    break;

                case 2:
                    Console.WriteLine($"First name: {customer.FirstName}");
                    customer.FirstName = EnterFirstName();
                    break;

                case 3:
                    Console.WriteLine($"Last name: {customer.LastName}");
                    customer.LastName = EnterLastName();
                    break;

                case 4:
                    Console.WriteLine($"Customer Email adddress: {customer.Email}");
                    customer.Email = EnterEmailAddress();
                    break;

                case 5:
                    Console.WriteLine($"Customer ID: ");
                    customer.CustomerId = EnterCustomerId();
                    break;
                default:
                    break;
            }
        }
        
        private CustomerType SelectACustomerType()
        {
            Console.WriteLine("Please select a Customer Type:\n\t" +
                "1. Potential\n\t" +
                "2. Current\n\t" +
                "3. Past\n\t");
            var typeResponse = int.Parse(Console.ReadLine());
            var Ctype = _customerRepo.ChooseCustomerType(typeResponse);
            return Ctype;
        }   

        private string EnterFirstName()
        {
            Console.WriteLine("Enter First Name: ");
            return Console.ReadLine();
        }
        private string EnterLastName()
        {
            Console.WriteLine("Enter Last Name: ");
            return Console.ReadLine();
        }
        private string EnterEmailAddress()
        {
            Console.WriteLine("Enter email address: ");
            return Console.ReadLine();
        }
        private int EnterCustomerId()
        {
            Console.WriteLine("Enter Customer ID: ");
            return int.Parse(Console.ReadLine());
        }

        private void SeedCustomerData()
        {
            _customerRepo.AddCustomerToList(new Customer(CustomerType.Current, "Joe", "Montana", "joe@49ers.com", 324));
            _customerRepo.AddCustomerToList(new Customer(CustomerType.Current, "Barry", "Sanders", "barry@lions.com", 235));
            _customerRepo.AddCustomerToList(new Customer(CustomerType.Current, "Peyton", "Manning", "peyton@colts.com", 302));
        }
    }
}
