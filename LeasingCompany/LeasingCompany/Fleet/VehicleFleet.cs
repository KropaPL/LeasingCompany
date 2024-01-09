using LeasingCompany.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeasingCompany.Fleet
{
    internal class VehicleFleet : IVehicleFleet
    {

        public List<IVehicle> vehicles { get; set; }

        public VehicleFleet()
        {
            vehicles = new List<IVehicle>();
        }


        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public List<IVehicle> GetVehiclesByBrand(string brand)
        {
            List <IVehicle> result = vehicles.Where(v => v.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)).ToList();
            if (result == null)
            {
                return null;
            }
            return result;
        }



    }
}
