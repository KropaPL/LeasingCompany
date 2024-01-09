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
            // Example customer driver with starting rating 1
            CustomerDriver driver = new CustomerDriver(1);

            RentalPayment payment = new RentalPayment();

            VehicleFleet vehicleFleet = new VehicleFleet();

            PassengerVehicle skoda = new PassengerVehicle(5, "Skoda", "fabia", 2003, "Silver", 4000m, "EWE50C5", 1m, 1500000000);
            vehicleFleet.AddVehicle(skoda);


            // Example trip
            Trip trip = new Trip(5, 230);

            string fileName = "Demo/DemoFleet.json";
            string projectDirectory = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string filePath = System.IO.Path.Combine(projectDirectory, fileName);

            // Loading Fleet
            vehicleFleet.LoadFleetFromJson(filePath);

            List <IVehicle> lista = vehicleFleet.GetVehiclesExceedingTenure("Skoda");
            foreach (Vehicle v in lista)
            {
                Console.WriteLine(v.ID);
            }

            Menu menu = new Menu(driver, vehicleFleet, payment, trip);
            menu.ShowMenu();


        }
    }
}