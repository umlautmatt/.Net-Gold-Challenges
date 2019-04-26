using _01_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge_Console
{
    public class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();
        //private List<MenuItem> _menuItems = new List<MenuItem>();
       

        public void Run()
        {
         
                Console.Clear();
                Menu();
            
        }

        private void Menu()
        {
            bool running = true;
            while (running)
            {


                Console.WriteLine("1. Create new menu item\n" +
                   "2. Delete menu item\n" +
                   "3. See all menu items\n" +
                   "4. Exit");
                int input = ParseInput();
                switch (input)
                {
                    case 1:
                        CreateMenuItem();
                        break;
                    case 2:
                        DeleteMenuItem();
                        break;
                    case 3:
                        SeeAllMenuItems();
                        break;
                    case 4:
                        running = false;
                        break;
                    default:

                        break;
                }
            }
        }

        private void CreateMenuItem()
        {
            Console.WriteLine("What is the name of the new menu item?");
            string mealName = Console.ReadLine();

            Console.WriteLine("Please enter a description for the new menu item.");
            string mealDescription = Console.ReadLine();

            Console.WriteLine("What will the menu number be for this new menu item?");
            int mealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("What are the ingredients for the new menu item?");
            string mealIngredients = Console.ReadLine();

            Console.WriteLine("Lastly, what will be the price of the new menu item?");
            decimal mealPrice = decimal.Parse(Console.ReadLine());

            MenuItem menuItem = new MenuItem(mealName, mealDescription, mealIngredients, mealPrice, mealNumber);

            _menuRepo.CreateNewMenuItem(menuItem);

        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            SeeAllMenuItems();

            Console.WriteLine("Which menu item would you like to remove?");
            int mealNumber = int.Parse(Console.ReadLine());
            _menuRepo.DeleteMenuItem(mealNumber);

        }

        private void SeeAllMenuItems()
        {
            List<MenuItem> menuItem = _menuRepo.GetAllMenuItems();
            foreach (MenuItem item in menuItem)
            {
                Console.WriteLine($"{item.MealName}\n {item.MealDescription}\n {item.MealIngredients}\n {item.MealNumber}\n {item.MealPrice}");
            }
            Console.ReadLine();
        }

        private int ParseInput()
        {
            int input = int.Parse(Console.ReadLine());
            if (input < 1 || input > 4)
            {
                Console.WriteLine("Your input was invalid, please enter a valid menu number.");
                input = ParseInput();
            }
            return input;
        }
    }
}
