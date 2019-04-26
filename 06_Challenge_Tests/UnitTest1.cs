using System;
using System.Collections.Generic;
using _06_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_Challenge_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckAddToVehicleListTest()
        {
            VehicleRepository vehicleRepo = new VehicleRepository();
            Vehicle car = new Vehicle(VehicleType.Electric, 2015, "Volks", "GTI", 19999, 1);

            vehicleRepo.AddCarToList(car);
            List<Vehicle> list = vehicleRepo.GetVehicleList();

            int actual = 1;
            int expected = list.Count;

            
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(list.Contains(car));
        }

        [TestMethod]
        public void CheckRemoveVehicleFromList()
        {
            VehicleRepository vehicleRepo = new VehicleRepository();
            Vehicle car = new Vehicle(VehicleType.Electric, 2015, "Volks", "GTI", 19999, 1);
            Vehicle carTwo = new Vehicle(VehicleType.Gas, 2015, "Chevy", "Equinox", 22999, 2);

            vehicleRepo.AddCarToList(car);
            vehicleRepo.AddCarToList(carTwo);

            vehicleRepo.RemoveCarFromList(car);
            List<Vehicle> list = vehicleRepo.GetVehicleList();

            int actual = vehicleRepo.GetVehicleList().Count;
            int expected = list.Count;

            Assert.AreEqual(expected, actual);
        }

       

       
    }
}
