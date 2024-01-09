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
        public int ID { get ; set ; }
        public string Brand { get ; set ; }
        public string Model { get ; set ; }
        public int YearOfManufacture { get ; set ; }
        public string Color { get ; set ; }
        public decimal Price { get ; set ; }
        public string RegistrationNumber { get ; set ; }
        public decimal coefficient { get; set; }

    }
}
