using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge1Repo
{
    public class C1MenuItems
    {
        public int MealNum { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Ingredients { get; set; }
        public C1MenuItems() { }

        public C1MenuItems(int mealNum, string mealName, string description, double price, string ingredients)
        {
            MealNum = mealNum;
            MealName = mealName;
            Description = description;
            Price = price;
            Ingredients = ingredients;
        }
    }
}





