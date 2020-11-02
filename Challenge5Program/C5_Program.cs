using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge5_Repo;

namespace Challenge5Program
{
    class C5_Program
    {
        static void Main(string[] args)
        {
            C5ProgramUI ui = new C5ProgramUI();
            ui.Run();
        }

        public class C5ProgramUI
        {
            public List<C5Emails> customers = new List<C5Emails>();
            public C5_Repo repo = new C5_Repo();
            public void Run()
            {
                SeedContent();
                Menu();
            }

            private void SeedContent()
            {
                C5Emails One = new C5Emails(
                    "A1",
                    "James",
                    "Gulley",
                    CustomerType.Potential
                );
                C5Emails Two = new C5Emails(
                    "A2",
                    "Jim",
                    "Gulley",
                    CustomerType.Potential
                );
                C5Emails Three = new C5Emails(
                    "A3",
                    "Jimmy",
                    "Brain",
                    CustomerType.Current
                );
                C5Emails Four = new C5Emails(
                    "A4",
                    "Jimbob",
                    "Gollmister",
                    CustomerType.Current
               );
                C5Emails Five = new C5Emails(
                    "A5",
                    "JimmyBoBob",
                    "Brain",
                    CustomerType.Past
                );
                C5Emails Six = new C5Emails(
                    "A6",
                    "Pinky",
                    "Snarf",
                    CustomerType.Past
               );
                repo.AddToList(One);
                repo.AddToList(Two);
                repo.AddToList(Three);
                repo.AddToList(Four);
                repo.AddToList(Five);
                repo.AddToList(Six);
            }

            private void Menu()
            {
                bool continueToRun = true;
                while (continueToRun)
                {
                    Console.Clear();

                    Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                        "1. Show all customers\n" +
                        "2. Show customer by ID\n" +
                        "3. Add new customer\n" +
                        "4. Update existing customer\n" +
                        "5. Show customer table with emails\n" +
                        "6. Remove customer\n" +
                        "7. Exit");

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            // Show all customers
                            ShowCustomers();
                            break;
                        case "2":
                            //show customer by ID
                            ShowCustomerByID();
                            break;
                        case "3":
                            //Show Toital Cost of All Events
                            AddNewCustomer();
                            break;
                        case "4":
                            // update existing
                            UpdateExistingCustomer();
                            break;
                        case "5":
                            // Delete existing content
                            showCustomerTableWithEmail();
                            break;
                        case "6":
                            // Delete existing content
                            DeleteCustomerByID();
                            break;
                        /* case "7":
                            // Delete existing content
                            Console.WriteLine("this Functionality has not been implimented");
                            break;*/
                        default:
                            Console.WriteLine("Please choose a valid option");
                            Console.ReadKey();
                            break;
                    }
                }
            }
            public void ShowCustomer(C5Emails customer)
            {
                Console.WriteLine($"Customer ID: {customer.ID}");
                Console.WriteLine($"Customer FirstName: {customer.FirstName}");
                Console.WriteLine($"Customer LastName: {customer.LastName}");
                Console.WriteLine($"Customer Type: {customer.CustomerType}");
                if (customer.CustomerType == CustomerType.Current)
                {
                    Console.WriteLine("Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
                }
                else if (customer.CustomerType == CustomerType.Past)
                {
                    Console.WriteLine("It's been a long time since we've heard from you, we want you back");
                }
                else if (customer.CustomerType == CustomerType.Potential)
                {
                    Console.WriteLine("We currently have the lowest rates on Helicopter Insurance!");
                }
            }
            public void ShowCustomers()
            {
                Console.Clear();
                List<C5Emails> listOfCustomers = repo.GetCustomers();
                foreach (C5Emails customer in listOfCustomers)
                {
                    ShowCustomer(customer);
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press any key to continue");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }


            private void ShowCustomerByID()
            {
                Console.Clear();
                Console.WriteLine("Enter the title of the content you'd like to see.");
                string id = Console.ReadLine();

                C5Emails customer = repo.GetCustomerByID(id);

                if (customer != null)
                {
                    ShowCustomer(customer);
                }
                else
                {
                    Console.WriteLine("That title doesn't exist.");
                }
                Console.ReadKey();
            }

            private void UpdateExistingCustomer()
            {
                ShowCustomers();
                Console.WriteLine("Enter the ID for the customer you would like to change.");
                string idToChange = Console.ReadLine();
                C5Emails customerToChange = repo.GetCustomerByID(idToChange);

                Console.WriteLine("Enter the number of the customer type:\n" +
                       "1. Current\n" +
                       "2. Past\n" +
                       "3. Potential\n");
                string input = Console.ReadLine();
                bool stopRunning = false;
                while (!stopRunning)
                {
                    switch (input)
                    {
                        case "1":
                            customerToChange.CustomerType = CustomerType.Current;
                            stopRunning = true;
                            break;
                        case "2":
                            customerToChange.CustomerType = CustomerType.Past;
                            stopRunning = true;
                            break;
                        case "3":
                            customerToChange.CustomerType = CustomerType.Potential;
                            stopRunning = true;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid input.");
                            stopRunning = false;
                            break;
                    }
                }
                Console.WriteLine("Please enter the customer's ID.");
                customerToChange.ID = Console.ReadLine();
                Console.WriteLine("Please enter the customer's first name.");
                customerToChange.FirstName = Console.ReadLine();
                Console.WriteLine("Please enter the customer's last name.");
                customerToChange.LastName = Console.ReadLine();
                bool wasChanged = repo.AddToList(customerToChange); ;

                if (wasChanged)
                {
                    Console.WriteLine("This content was successfully changed.");
                }
                else
                {
                    Console.WriteLine("Content could not be changed");
                }


            }
            private void AddNewCustomer()
            {
                C5Emails newcustomer = new C5Emails();
                Console.Clear();
                Console.WriteLine("Enter the number of the customer type you would like to add:\n" +
                       "1. Current\n" +
                       "2. Past\n" +
                       "3. Potential\n");
                string input = Console.ReadLine();
                bool stopRunning = false;
                while (!stopRunning)
                {

                    switch (input)
                    {
                        case "1":
                            newcustomer.CustomerType = CustomerType.Current;
                            stopRunning = true;
                            break;
                        case "2":
                            newcustomer.CustomerType = CustomerType.Past;
                            stopRunning = true;
                            break;
                        case "3":
                            newcustomer.CustomerType = CustomerType.Potential;
                            stopRunning = true;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid input.");
                            stopRunning = false;
                            break;
                    }
                }
                Console.WriteLine("Please enter the customer's ID.");
                newcustomer.ID = Console.ReadLine();
                Console.WriteLine("Please enter the customer's first name.");
                newcustomer.FirstName = Console.ReadLine();
                Console.WriteLine("Please enter the customer's last name.");
                newcustomer.LastName = Console.ReadLine();

                bool wasAdded = repo.AddToList(newcustomer);
                if (wasAdded == true)
                {
                    Console.WriteLine("Your content was succesfully added.");
                }
                else
                {
                    Console.WriteLine("Oops something went wrong. Your content was not added.");
                }
            }
            private void DeleteCustomerByID()
            {
                ShowCustomers();
                Console.WriteLine("Enter the ID for the customer you would like to delete.");
                string customerIDToDelete = Console.ReadLine();

                C5Emails customerToDelete = repo.GetCustomerByID(customerIDToDelete);
                bool wasDeleted = repo.DeleteExisting(customerToDelete);

                if (wasDeleted)
                {
                    Console.WriteLine("This content was successfully deleted.");
                }
                else
                {
                    Console.WriteLine("Content could not be deleted");
                }
            }

            private void showCustomerTableWithEmail()
            {
                Console.Clear();
                List<C5Emails> listOfCustomers = repo.GetCustomers();
                //sort list alphabeticaly
                listOfCustomers.Sort((left, right) => string.Compare(left.LastName, right.LastName));
                Console.Write("{0,-15}", "FirstName");
                Console.Write("{0,-15}", "LastName");
                Console.Write("{0,-15}", "CustomerType");
                Console.WriteLine("Email");
                foreach (C5Emails customer in listOfCustomers)
                {
                    Console.Write("{0,-15}", customer.FirstName);
                    Console.Write("{0,-15}", customer.LastName);
                    Console.Write("{0,-15}", customer.CustomerType);
                    if (customer.CustomerType == CustomerType.Current)
                    {
                        Console.WriteLine("Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
                    }
                    else if (customer.CustomerType == CustomerType.Past)
                    {
                        Console.WriteLine("It's been a long time since we've heard from you, we want you back");
                    }
                    else if (customer.CustomerType == CustomerType.Potential)
                    {
                        Console.WriteLine("We currently have the lowest rates on Helicopter Insurance!");
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
