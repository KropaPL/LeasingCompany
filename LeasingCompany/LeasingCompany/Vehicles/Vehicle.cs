using LeasingCompany.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeasingCompany
{
    internal abstract class Vehicle : IVehicle
    {
        private static int IDNumber = 0;
        public int ID { get ; set ; }
        public string Brand { get ; set ; }
        public string Model { get ; set ; }
        public int YearOfManufacture { get ; set ; }
        public string Color { get ; set ; }
        public decimal Price { get ; set ; }
        public string RegistrationNumber { get ; set ; }
        public decimal Coefficient { get; set; }
        public decimal Mileage { get ; set; }

        public Vehicle(string brand, 
            string model, 
            int yearOfManufacture, 
            string color, 
            decimal price,
            string registrationNumber,
            decimal coefficient,
            decimal mileage)
        {
            ID = IDNumber;
            IDNumber++;
            Brand = brand;
            Model = model;
            YearOfManufacture = yearOfManufacture;
            Color = color;
            Price = price;
            RegistrationNumber = registrationNumber;
            Coefficient = coefficient;
            Mileage = mileage;
        }

        public int CalculateComfortLevel()
        {
            int yearsDifference = DateTime.Now.Year - YearOfManufacture;

            decimal yearCoefficient = 1;
            decimal priceCoefficient = 2;

            int ComfortLevel = (int)(Price * priceCoefficient / (yearsDifference * yearCoefficient));

            return ComfortLevel;
        }

    }
}
