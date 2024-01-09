using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeasingCompany.Vehicles
{
    internal class PassengerVehicle : Vehicle
    {
        public int NumberOfPassengers;

        public PassengerVehicle(int numberOfPassengers,string brand, string model, int yearOfManufacture, string color, decimal price, string registrationNumber, decimal coefficient, decimal mileage) : base(brand, model, yearOfManufacture, color, price, registrationNumber, coefficient, mileage)
        {
            NumberOfPassengers = numberOfPassengers;
        }
    }
}
