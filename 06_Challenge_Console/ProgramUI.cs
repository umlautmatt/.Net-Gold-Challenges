using _06_Challenge_Repository;
using System;
using System.Collections.Generic;

namespace _06_Challenge_Console
{
    class ProgramUI
    {
        VehicleRepository _vehicleRepo = new VehicleRepository();
        
        List<Vehicle> _vehicleList = new List<Vehicle>();
        int _response;

        internal void Run()
        {
            while (_response != 7)
            {
                PrintMenu();
                SeedCarData();
                switch (_response)
                {
                    case 1:
                        SeeAllVehicles();
                        break;
                    case 2:
                        CallVehiclesByTypeList();
                        break;
                    case 3: SeeVehicleById();
                        break;            
                    case 4:
                        var car = GetUserInputForCar();
                        _vehicleRepo.AddCarToList(car);
                        break;
                    case 5:
                        CallRemoveVehicleFromList();
                        break;
                    case 6: 
                        UpdateVehicle();
                        break;
                    case 7:
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

        private Vehicle GetUserInputForCar()
        {
            
            var Vtype = SelectAVehicleType();
            var year = EnterAYear();
            var make = EnterNewMake();
            var model = EnterNewModel();
            var price = EnterNewPrice();
            var vehicleId = EnterNewVehicleID();
 
            return new Vehicle(Vtype, year, make, model, price, vehicleId);
        }

        private void PrintMenu()
        {
            Console.WriteLine("What would you like to do?\n\t" +
                "1. See All Cars\n\t" +
                "2. View Cars by Vehicle Type\n\t" +
                "3. View Car by Vehicle ID\n\t" +
                "4. Add A New Car\n\t" +
                "5. Remove A Car\n\t" +
                "6. Update A Car\n\t" +
                "7. Exit Program");
            _response = int.Parse(Console.ReadLine());
        }

        //private void PrintCars()
        //{
        //    Console.WriteLine("Type\tYear\tMake\tModel\t?");
        //    foreach (Vehicle car in _vehicleList)
        //        Console.WriteLine($"{car.VType}\t{car.Year}\t{car.Make}\t{car.Model}");
        //}
        private void CallVehiclesByTypeList()
        {
            List<Vehicle> _vehicleList = _vehicleRepo.GetVehicleList();
            Console.WriteLine("View list of cars by type:\n\t" +
               "1. Gas\n\t" +
               "2. Hybrid\n\t" +
               "3. Electric\n\t");
            var typeResponse = int.Parse(Console.ReadLine());
           
            foreach (Vehicle v in _vehicleList)
            {
                if (v.VType == (VehicleType)typeResponse)
                {
                    Console.WriteLine($"{v.VType} {v.Year} {v.Make} {v.Model} {v.VehicleID}");
                }
                
            }
        }
        private void SeeAllVehicles()
        {
            List<Vehicle> list = _vehicleRepo.GetVehicleList();

            foreach (Vehicle v in list)
            {
                Console.WriteLine($"Vehicle Type: {v.VType}\t " +
                    $"Year: {v.Year}\t " +
                    $"Make: {v.Make}\t " +
                    $"Model:{v.Model}\t " +
                    $"Price: {v.Price}\t " +
                    $"VehicleID: {v.VehicleID}");
            }
            Console.ReadLine();
        }
        private void SeeVehicleById()
        {
            Console.WriteLine("Enter the VehicleID: ");

            int carID = int.Parse(Console.ReadLine());
            Vehicle v = _vehicleRepo.SeeVehiclePropsById(carID);

            if (v != null)
            {
                Console.WriteLine($"{v.Year}\n {v.Make}\n {v.Model}\n {v.VType}\n {v.Price}\n {v.VehicleID}");
            }

        }
        //private Vehicle SelectACar(string action)
        //{
        //    List<Vehicle> list = _vehicleRepo.GetVehicleList();
        //    Console.WriteLine($"Which car would you like to {action}?");

        //    foreach (var c in list)
        //    {
        //        Console.WriteLine($" {c.VehicleID}");

        //    }
        //    var carInt = int.Parse(Console.ReadLine());
        //    return _vehicleList[carInt];
        //}
        private void CallRemoveVehicleFromList()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID Number of the car that you would like to remove from the list.");

            int carID = int.Parse(Console.ReadLine());

            Vehicle v = _vehicleRepo.SeeVehiclePropsById(carID);

            if (v != null)
            {
                Console.WriteLine($"{v.Year}\n {v.Make}\n {v.Model}\n {v.VType}\n {v.Price}\n {v.VehicleID}");
            }
            else
            {
                Console.WriteLine("There are no cars that match the entered ID.");
            }
            Console.ReadLine();

            Console.WriteLine("Please confirm that this is the car that you would like to remove from the list. (Y/N)");
            string confirmAsString = Console.ReadLine().ToLower(); // Converts to all lowercase
            bool confirm = false;

            switch (confirmAsString)
            {
                case "y":
                case "yes":
                    confirm = true;
                    break;
                case "n":
                case "no":
                default: // Makes it default to false if y, yes, n, no is not entered
                    confirm = false;
                    break;
            }
            _vehicleRepo.RemoveCarFromList(v);

            Console.WriteLine("The car has been removed from the list.");
            Console.ReadLine();
        }
        private void UpdateVehicle()
        {
            Console.WriteLine("Enter the ID for the vehicle you would like to update: ");
            int carID = int.Parse(Console.ReadLine());
            Vehicle vehicle = _vehicleRepo.SeeVehiclePropsById(carID);

            if (vehicle != null)
            {
                Console.WriteLine($"{vehicle.Year}\n {vehicle.Make}\n {vehicle.Model}\n {vehicle.VType}\n {vehicle.Price}\n {vehicle.VehicleID}");
            }

            Console.WriteLine("Which property would you like to update?\n\t" +
                "1.  Vehicle Type\n\t" +
                "2.  Year\n\t" +
                "3.  Make\n\t" +
                "4.  Model\n\t" +
                "5.  Price\n\t" +
                "6.  VehicleId\n\t" +
                "7.  See all vehicle properties\n\t" +
                "8.  No change");
            int propertyChoice = int.Parse(Console.ReadLine());
            switch (propertyChoice)
            {
                case 1: 
                    Console.WriteLine($"The current car typs is {vehicle.VType}");
                    vehicle.VType = SelectAVehicleType();
                    break;

                case 2:
                    Console.WriteLine($"The current car year is {vehicle.Year}");
                    vehicle.Year = EnterAYear();
                    break;

                case 3:
                    Console.WriteLine($"The current make is {vehicle.Make}");
                    vehicle.Make = EnterNewMake();
                    break;

                case 4:
                    Console.WriteLine($"The current model is {vehicle.Model}");
                    vehicle.Model = EnterNewModel();
                    break;

                case 5:
                    Console.WriteLine($"The current price is {vehicle.Price}");
                    vehicle.Price = EnterNewPrice();
                    break;

                case 6:
                    Console.WriteLine($"The current Vehicle ID is {vehicle.VehicleID}");
                    vehicle.VehicleID = EnterNewVehicleID();
                    break;

                case 7:
                    Console.WriteLine("Enter Vehicle ID to view details");
                    var carId = int.Parse(Console.ReadLine());
                    _vehicleRepo.SeeVehiclePropsById(carId);
                    break;
                default:
                    break;
            }
        }

        //update methods
        private VehicleType SelectAVehicleType()
        {
            Console.WriteLine("Please Select A Type Of Vehicle:\n\t" +
                "1. Gas\n\t" +
                "2. Hybrid\n\t" +
                "3. Electric\n\t");
            var typeResponse = int.Parse(Console.ReadLine());
            var Vtype = _vehicleRepo.GetVehicleListByType(typeResponse);
            return Vtype;
        }
        private int EnterAYear()
        {
            Console.Write("Enter the car's year: ");
            return int.Parse(Console.ReadLine());
        }

        private string EnterNewMake()
        {
            Console.WriteLine("Enter the vehicle's make: ");
            return Console.ReadLine();
        }

        private string EnterNewModel()
        {
            Console.WriteLine("Enter the vehicle's model: ");
            return Console.ReadLine();
        }

        private decimal EnterNewPrice()
        {
            Console.WriteLine("What is the price of the vehicle?");
            return int.Parse(Console.ReadLine());
        }

        private int EnterNewVehicleID()
        {
            Console.WriteLine("What is the Vehicle ID?");
            return int.Parse(Console.ReadLine());
        }

        private void SeedCarData()
        {
            _vehicleRepo.AddCarToList(new Vehicle(VehicleType.Electric, 2015, "Ford", "Fusion", 12000, 1));
            _vehicleRepo.AddCarToList(new Vehicle(VehicleType.Electric, 2018, "Toyota", "Prius", 18000, 2));
            _vehicleRepo.AddCarToList(new Vehicle(VehicleType.Electric, 2018, "Tesla", "Model 3", 25000, 3));
            _vehicleRepo.AddCarToList(new Vehicle(VehicleType.Gas, 2018, "Chevy", "Camaro", 28000, 4));

        }
    }
}
