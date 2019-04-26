using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Challenge_Repository
{
    public class VehicleRepository
    {
        private List<Vehicle> _vehicleList = new List<Vehicle>();

        public void AddCarToList(Vehicle newVehicle)
        {
            _vehicleList.Add(newVehicle);
        }
        public void RemoveCarFromList(Vehicle vehicle)
        {
            //foreach (Vehicle car in _vehicleList)
            //{
            //    if (car.VehicleID == carID)
            //    {
            //        _vehicleList.Remove(car);
            //    }
            //} 
            _vehicleList.Remove(vehicle);

        }
        public List<Vehicle> GetVehicleList()
        {
            return _vehicleList;
        }
        public Vehicle SeeVehiclePropsById(int carID)
        {
           
            foreach(Vehicle v in _vehicleList)
            {
                if(v.VehicleID == carID)
                {
                    return v;
                }
            }return null;
        }

        //public void EditVehicleList(int carID)
        //{
        //    foreach (Vehicle car in _vehicleList)
        //    {
        //        if (car.VehicleID == carID)
        //        {
        //            _vehicleList.Remove(car);

        //        }
        //    }
        //}

        public VehicleType GetVehicleListByType(int typeChoice)
        {

            VehicleType type = new VehicleType();
            switch (typeChoice)
            {
                case 1:
                    type = VehicleType.Gas;
                    break;
                case 2:
                    type = VehicleType.Hybrid;
                    break;
                case 3:
                    type = VehicleType.Electric;
                    break;
            }
            return type;
        }

    }
}
