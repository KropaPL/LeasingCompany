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
        public List<Vehicle> GetVehiclesExceedingTenure(string chosenModel);
        public List<IVehicle> GetVehiclesByBrandAndColor(string preferredBrand, string preferredColor);
        public List<IVehicle> GetVehiclesRequiringMaintenance();
        public decimal CalculateTotalFleetValue();
    }
}
