using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeasingCompany
{
    internal abstract class Vehicle : IVehicle
    {
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Brand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Model { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int YearOfManufacture { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string RegistrationNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public decimal CalculateRentalCost()
        {
            throw new NotImplementedException();
        }
    }
}
