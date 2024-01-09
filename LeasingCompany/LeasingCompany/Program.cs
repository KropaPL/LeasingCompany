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
            VehicleFleet vehicleFleet = new VehicleFleet();
            vehicleFleet.AddVehicle(cargoVehicle);
            vehicleFleet.AddVehicle(cargoVehicle2);

            CustomerDriver driver = new CustomerDriver(1);
            Trip trip = new Trip(5, 230);
            RentalPayment payment = new RentalPayment();

            List <IVehicle> cos = vehicleFleet.GetVehiclesByBrand("Mon");

            foreach (var vehicle in cos)
            {
                Console.WriteLine(vehicle.ID);
            }

            //Console.WriteLine(payment.CalculateRentalCost(cargoVehicle, driver, trip));
            
        }
    }
}