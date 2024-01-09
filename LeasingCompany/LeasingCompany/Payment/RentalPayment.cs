using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeasingCompany.Driver;
using LeasingCompany.Trips;
using LeasingCompany.Vehicles;

namespace LeasingCompany.Payment
{
    internal class RentalPayment : IPayment
    {
        public decimal? CalculateRentalCost(IVehicle vehicle, IDriver driver, ITrip trip)
        {
            decimal? payment = null;
            if (vehicle.GetType() == typeof(PassengerVehicle))
            {
                payment = CalculateRentalCostForPassengerVehicle(vehicle, driver, trip);
            }
            else if (vehicle.GetType() == typeof(CargoVehicle)) 
            {
                payment = CalculateRentalCostForCargoVehicle(vehicle, trip);
            } else
            {
                return null;
            }
            return payment;
        }

        private decimal CalculateRentalCostForPassengerVehicle(IVehicle vehicle, IDriver driver, ITrip trip) 
        {
            decimal payment = vehicle.Coefficient * (trip.Distance * trip.Duration / driver.Rating);
            payment = PaymentRounder(payment);
            return payment;
        }
        private decimal CalculateRentalCostForCargoVehicle(IVehicle vehicle, ITrip trip)
        {
            CargoVehicle cargoVehicle = (CargoVehicle)vehicle;
            decimal payment = vehicle.Coefficient * (trip.Distance * trip.Duration * cargoVehicle.Weight * 0.0005m);
            payment = PaymentRounder(payment);
            return payment;
        }

        private decimal PaymentRounder(decimal payment)
        {
            return Math.Floor(payment * 100) / 100; ;
        }
    }
}
