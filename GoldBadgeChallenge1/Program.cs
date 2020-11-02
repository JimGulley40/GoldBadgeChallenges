using GoldBadgeChallenge1Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge1
{
    class Program
    {

        static void Main(string[] args)
        {
            C1ProgramUI ui = new C1ProgramUI();
            ui.Run();
        }

        public class C1ProgramUI
        {
            private Methods _menu = new Methods();

            public void Run()
            {
                SeedContent();
                Menu();
            }

            private void SeedContent()
            {
                C1MenuItems One = new C1MenuItems(
                    1,
                    "Burger",
                    "A tasty Burger",
                    4.95,
                    "Burger, Bun, Lettuce, Tomato, Mayo, Ketchup"
                );
                C1MenuItems Two = new C1MenuItems(
                    2,
                    "Cheese Burger",
                    "A tasty Burger",
                    4.95,
                    "Burger, Cheese, Bun, Lettuce, Tomato, Mayo, Ketchup"
                );
                _menu.AddMenuItemToMenu(One);
                _menu.AddMenuItemToMenu(Two);

            }

            private void Menu()
            {
                bool continueToRun = true;
                while (continueToRun)
                {
                    Console.Clear();

                    Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                        "1. Show all Menu Items\n" +
                        "2. Find menu Items by number\n" +
                        "3. Add new menu items\n" +
                        "4. Update existing menu Items\n" +
                        "5. Remove menu Items\n" +
                        "6. Exit");

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            // Show all content
                            _menu.ShowMenuItems();
                            break;
                        case "2":
                            //Get content by title
                            _menu.ShowMenuItemByNumber();
                            break;
                        case "3":
                            //Create new streaming content
                            _menu.CreateNewMenuItems();
                            break;
                        case "4":
                            // Update existing content
                            Console.WriteLine("This fucionality is yet to be implimented");
                            break;
                        case "5":
                            // Delete existing content
                            _menu.DeleteMenuItemByNumber();
                            break;
                        case "6":
                            //Exit
                            continueToRun = false;
                            break;
                        default:
                            Console.WriteLine("Please choose a valid option");
                            Console.ReadKey();
                            break;
                    }
                }
            }
           
        }
    }
}
