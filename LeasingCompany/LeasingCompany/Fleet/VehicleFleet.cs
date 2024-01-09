using LeasingCompany.Vehicles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            List<IVehicle> result = vehicles.Where(v => v.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)).ToList();
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public List<Vehicle> GetVehiclesExceedingTenure(string chosenModel)
        {
            const int passengerMileageThreshold = 100000;
            const int passengerYearsThreshold = 5;
            const int cargoMileageThreshold = 1000000;
            const int cargoYearsThreshold = 15;

            var result = new List<Vehicle>();

            foreach (var vehicle in vehicles)
            {
                if (vehicle.Model.Equals(chosenModel, StringComparison.OrdinalIgnoreCase))
                {
                    if (vehicle.GetType() == typeof(PassengerVehicle))
                    {
                        var passengerVehicle = (PassengerVehicle)vehicle;
                        if (passengerVehicle.Mileage > passengerMileageThreshold ||
                            (DateTime.Now.Year - passengerVehicle.YearOfManufacture) > passengerYearsThreshold)
                        {
                            result.Add(passengerVehicle);
                        }
                    }
                    else if (vehicle.GetType() == typeof(CargoVehicle))
                    {
                        var cargoVehicle = (CargoVehicle)vehicle;
                        if (cargoVehicle.Mileage > cargoMileageThreshold ||
                            (DateTime.Now.Year - cargoVehicle.YearOfManufacture) > cargoYearsThreshold)
                        {
                            result.Add(cargoVehicle);
                        }
                    }
                }
            }

            if (result == null)
            {
                return null;
            }

            return result;
        }

        public List<IVehicle> GetVehiclesByBrandAndColor(string preferredBrand, string preferredColor)
        {
            var matchingVehicles = vehicles
                .Where(v => v.Brand.Equals(preferredBrand, StringComparison.OrdinalIgnoreCase) &&
                            v.Color.Equals(preferredColor, StringComparison.OrdinalIgnoreCase))
                .ToList();

            matchingVehicles.Sort((v1, v2) => v2.CalculateComfortLevel().CompareTo(v1.CalculateComfortLevel()));

            return matchingVehicles;
        }

        public List<IVehicle> GetVehiclesRequiringMaintenance()
        {
            // Filter vehicles that are close to requiring maintenance
            var vehiclesForMaintenance = vehicles
                .Where(v =>
                {
                    if (v.GetType() == typeof(PassengerVehicle))
                    {
                        return (v.Mileage % 5000) >= 4000; // For Passenger Vehicles (maintenance every 5000 km)
                    }
                    else if (v.GetType() == typeof(CargoVehicle))
                    {
                        return (v.Mileage % 15000) >= 14000; // For Cargo Vehicles (maintenance every 15000 km)
                    }
                    else
                    {
                        return false; // Handle other vehicle types 
                    }
                })
                .ToList();

            return vehiclesForMaintenance;
        }

        public void LoadFleetFromJson(string jsonFilePath)
        {
            string jsonText = System.IO.File.ReadAllText(jsonFilePath);

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            JArray jsonArray = JArray.Parse(jsonText);

            foreach (JObject vehicleObject in jsonArray)
            {
                string type = vehicleObject["Type"].ToString();

                if (type == "Passenger")
                {
                    PassengerVehicle passengerVehicle = vehicleObject.ToObject<PassengerVehicle>(JsonSerializer.Create(settings));
                    vehicles.Add(passengerVehicle);
                }
                else if (type == "Cargo")
                {
                    CargoVehicle cargoVehicle = vehicleObject.ToObject<CargoVehicle>(JsonSerializer.Create(settings));
                    vehicles.Add(cargoVehicle);
                }
            }
        }

        public decimal CalculateTotalFleetValue()
        {
            decimal totalValue = 0;
            foreach (var vehicle in vehicles)
            {
                int yearsOwned = DateTime.Now.Year - vehicle.YearOfManufacture;
                decimal depreciationRate = (vehicle.GetType() == typeof(PassengerVehicle)) ? 0.10m : 0.07m;
                decimal initialPrice = (decimal)vehicle.Price;
                decimal depreciation = initialPrice * (decimal)Math.Pow((double)(1 - depreciationRate), yearsOwned);
                totalValue += depreciation;
            }
            return totalValue;
        }




    }
}
