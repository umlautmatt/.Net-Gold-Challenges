using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge_Repository
{
    public class MenuItem
    {
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MealIngredients { get; set; }
        public decimal MealPrice { get; set; }
        public int MealNumber { get; set; }

        public MenuItem(string mealName, string mealDescription, string mealIngredients, decimal mealPrice, int mealNumber)
        {
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
            MealPrice = mealPrice;
            MealNumber = mealNumber;
        }

        public MenuItem(){}
    }
}
