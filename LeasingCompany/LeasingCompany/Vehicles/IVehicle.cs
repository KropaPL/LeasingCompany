using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeasingCompany.Vehicles
{
    internal interface IVehicle
    {
        int ID { get; set; }
        decimal Coefficient { get; set; }
        string Brand { get; set; }
        string Model { get; set; }
        int YearOfManufacture { get; set; }
        string Color { get; set; }
        decimal Price { get; set; }
        string RegistrationNumber { get; set; }
        decimal Mileage { get; set; }

    }
}
