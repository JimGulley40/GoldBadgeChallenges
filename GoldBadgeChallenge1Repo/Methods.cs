using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge1Repo
{
    public class Methods
    {
        public List<C1MenuItems> menuItems = new List<C1MenuItems>();

       
        public List<C1MenuItems> GetMeals()
        {
            return menuItems;
        }
        public void ShowMeal(C1MenuItems menuItem)
        {
            Console.WriteLine($"Meal #: {menuItem.MealNum}");
            Console.WriteLine($"Meal Name: {menuItem.MealName}");
            Console.WriteLine($"Description: {menuItem.Description}");
            Console.WriteLine($"Meal Price: {menuItem.Price}");
            Console.WriteLine($"Ingredients: {menuItem.Ingredients}");
        }
        public void ShowMenuItems()
        {
            Console.Clear();
            List<C1MenuItems> listOfMeals = menuItems;
            foreach (C1MenuItems menuItem in listOfMeals)
            {
                ShowMeal(menuItem);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public C1MenuItems GetMenuItemByNumber(int mealNum)
        {
            foreach (C1MenuItems menuItem in menuItems)
            {
                if (menuItem.MealNum == mealNum)
                {
                    return menuItem;
                }
                else Console.WriteLine("that does not appear to be in the menu");
            }
            return null;
        }
        public void ShowMenuItemByNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of the menu item you'd like to see.");
            int mealNum = Int32.Parse(Console.ReadLine());
            C1MenuItems menuItem = GetMenuItemByNumber(mealNum);
            if (menuItem != null)
            {
                ShowMeal(menuItem);
            }
            else
            {
                Console.WriteLine("That title doesn't exist.");
            }
            Console.ReadKey();
        }
        public void AddMenuItemToMenu() { }
        public bool AddMenuItemToMenu(C1MenuItems newItem)
        {

            int startingCount = menuItems.Count;
            menuItems.Add(newItem);
            bool wasAdded = (menuItems.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public void CreateNewMenuItems()
        {
            Console.Clear();
            //CreateNewMenuItems new 
            C1MenuItems newMenuItem = new C1MenuItems();
            // ask for and take user input for new menu item
            Console.WriteLine("Please enter a menu item number.");
            newMenuItem.MealNum = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a meal name.");
            newMenuItem.MealName = Console.ReadLine();
            Console.WriteLine("Please enter a meal description.");
            newMenuItem.Description = Console.ReadLine();
            Console.WriteLine("Please enter a price for this meal.");
            string priceAsString = Console.ReadLine();
            double priceAsDouble = double.Parse(priceAsString);
            newMenuItem.Price = priceAsDouble;
            Console.WriteLine("Please enter a list of ingredients.");
            newMenuItem.Ingredients = Console.ReadLine();
            AddMenuItemToMenu(newMenuItem);
        }
        public bool DeleteExistingMenuItem(C1MenuItems existingMenuItem)
        {
            bool deleteResult = menuItems.Remove(existingMenuItem);
            return deleteResult;
        }
        public void DeleteMenuItemByNumber()
        {
            Console.Clear();
            ShowMenuItems();
            Console.WriteLine("Enter the number for the menu item you would like to delete.");
            var menuItemToDelete = Int32.Parse(Console.ReadLine());
            C1MenuItems numToDelete = GetMenuItemByNumber(menuItemToDelete);
            bool wasDeleted = DeleteExistingMenuItem(numToDelete);
            if (wasDeleted)
            {
                Console.WriteLine("This content was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Content could not be deleted");
            }
        }
    }
}


