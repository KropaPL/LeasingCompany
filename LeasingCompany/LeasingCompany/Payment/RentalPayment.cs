using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeasingCompany.Driver;
using LeasingCompany.Vehicles;

namespace LeasingCompany.Payment
{
    internal class RentalPayment
    {
        public decimal? CalculateRentalCost(IVehicle vehicle, IDriver driver)
        {
            decimal? payment = null;
            if (vehicle.GetType() == typeof(PassengerVehicle))
            {
                payment = CalculateRentalCostForPassengerVehicle(vehicle, driver);
            }
            else if (vehicle.GetType() == typeof(CargoVehicle)) 
            {
                payment = CalculateRentalCostForCargoVehicle(vehicle);
            }
            return payment;
        }

        public decimal CalculateRentalCostForPassengerVehicle(IVehicle vehicle, IDriver driver) 
        {
            decimal payment = 0;
            return payment;
        }
        public decimal CalculateRentalCostForCargoVehicle(IVehicle vehicle)
        {
            decimal payment = 0;
            return payment;
        }
    }
}
