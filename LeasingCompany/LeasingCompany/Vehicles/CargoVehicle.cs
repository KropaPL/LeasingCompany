using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeasingCompany.Vehicles
{
    internal class CargoVehicle : Vehicle
    {
        public CargoVehicle(int weight ,string brand, string model, int yearOfManufacture, string color, decimal price, string registrationNumber, decimal coefficient, decimal mileage) : base(brand, model, yearOfManufacture, color, price, registrationNumber, coefficient, mileage)
        {
            Weight = weight;
        }

        public decimal Weight { get; set; }
    }
}
