using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge_Repository
{
    public class MenuRepository
    {
        List<MenuItem> _menuItems = new List<MenuItem>();


        public void CreateNewMenuItem(MenuItem newItem)
        {
            _menuItems.Add(newItem);
        }


        public void DeleteMenuItem(int menuId)
        {
            foreach (MenuItem item in _menuItems)
            {
                if (item.MealNumber == menuId)
                {
                    _menuItems.Remove(item);
                    break;
                }
            }
        }


        public List<MenuItem> GetAllMenuItems()
        {
            return _menuItems;
        }
    }
}
