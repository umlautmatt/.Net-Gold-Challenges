using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Challenge_Repository
{
    public enum VehicleType
    {
        Gas = 1, Hybrid, Electric
    }

    public class Vehicle
    {
        public VehicleType VType { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int VehicleID { get; set; }

        public Vehicle() { }

        public Vehicle (VehicleType Vtype, int year, string make, string model, decimal price, int vehicleId)
        {
            VType = Vtype;
            Year = year;
            Make = make;
            Model = model;
            Price = price;
            VehicleID = vehicleId;
        }
    }
}
