using LeasingCompany.Driver;
using LeasingCompany.Payment;
using LeasingCompany.Trips;
using LeasingCompany.Fleet;
using LeasingCompany.Vehicles;
using Newtonsoft.Json;

namespace LeasingCompany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CargoVehicle cargoVehicle = new CargoVehicle(3400, "Ford", "transit", 2018, "White", 1580.88m, "EWE50E1", 1.05m, 190000);
            CargoVehicle cargoVehicle2 = new CargoVehicle(3400, "Ford", "vivaro", 2018, "Silver", 1580.88m, "EWE69E2", 1.25m, 340000);
            CargoVehicle cargoVehicle3 = new CargoVehicle(3400, "Ford", "vivaro", 2020, "Silver", 1580.88m, "EWE61E2", 1.25m, 840000);
            CargoVehicle cargoVehicle4 = new CargoVehicle(3400, "Ford", "vivaro", 2022, "Silver", 1580.88m, "EWE62E2", 1.25m, 50000);
            CargoVehicle cargoVehicle5 = new CargoVehicle(3400, "Ford", "vivaro", 1998, "Silver", 1580.88m, "EWE65E2", 1.25m, 40000);

            VehicleFleet vehicleFleet = new VehicleFleet();

            vehicleFleet.AddVehicle(cargoVehicle);
            vehicleFleet.AddVehicle(cargoVehicle2);
            vehicleFleet.AddVehicle(cargoVehicle3);
            vehicleFleet.AddVehicle(cargoVehicle4);
            vehicleFleet.AddVehicle(cargoVehicle5);

            CustomerDriver driver = new CustomerDriver(1);
            Trip trip = new Trip(5, 230);
            RentalPayment payment = new RentalPayment();

            List<IVehicle> cos = vehicleFleet.GetVehiclesByBrand("Ford");
            List<IVehicle> cos2 = vehicleFleet.GetVehiclesByBrandAndColor("Ford", "silver");

                Console.WriteLine($"ID   Brand    Model   Comfort Level");
            foreach (var vehicle in cos2)
            {
                Console.WriteLine($"{vehicle.ID} {vehicle.Brand} {vehicle.Model} {vehicle.CalculateComfortLevel()}");
            }

            //Console.WriteLine(payment.CalculateRentalCost(cargoVehicle, driver, trip));
        }
    }
}