using LeasingCompany.Driver;
using LeasingCompany.Trips;
using LeasingCompany.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeasingCompany.Payment
{
    internal interface IPayment
    {
        public decimal? CalculateRentalCost(IVehicle vehicle, IDriver driver, ITrip trip);
    }
}
