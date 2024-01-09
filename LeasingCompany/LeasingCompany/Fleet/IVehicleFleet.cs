using LeasingCompany.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeasingCompany.Fleet
{
    internal interface IVehicleFleet
    {
        List<IVehicle> vehicles { get; set; }
        public void AddVehicle(Vehicle vehicle);
        public List<IVehicle> GetVehiclesByBrand(string brand);
    }
}
