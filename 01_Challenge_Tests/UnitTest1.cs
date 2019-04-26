using System;
using System.Collections.Generic;
using _01_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Challenge_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddMenuItemToListTest()
        {
            //Arrange
            MenuRepository menuRepo = new MenuRepository();
            MenuItem item = new MenuItem("Pepperoni Pizza", "pizza with pepperonis", "pizza, salad, and drink", 5.99m, 1);

            //Act
            menuRepo.CreateNewMenuItem(item);
            List<MenuItem> list = menuRepo.GetAllMenuItems();

            int actual = list.Count;
            int expected = 1;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(list.Contains(item));
        }

        [TestMethod]
        public void RemoveMenuItemFromListTest()
        {
            MenuRepository _menuRepo = new MenuRepository();

            MenuItem itemOne = new MenuItem();
            MenuItem itemTwo = new MenuItem();
            MenuItem itemThree = new MenuItem();

            _menuRepo.CreateNewMenuItem(itemOne);
            _menuRepo.CreateNewMenuItem(itemTwo);
            _menuRepo.CreateNewMenuItem(itemThree);

            _menuRepo.DeleteMenuItem(itemOne.MealNumber);


            int actual = _menuRepo.GetAllMenuItems().Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }
    }
}