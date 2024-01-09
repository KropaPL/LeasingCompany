using LeasingCompany.Driver;
using LeasingCompany.Fleet;
using LeasingCompany.Payment;
using LeasingCompany.Trips;
using LeasingCompany.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeasingCompany
{
    internal class Menu
    {

        IDriver Driver;
        IVehicleFleet VehicleFleet;
        IPayment Payment;
        ITrip Trip;
        
        public Menu(IDriver driver, IVehicleFleet vehicleFleet, IPayment payment, ITrip trip)
        {
            Driver = driver;
            VehicleFleet = vehicleFleet;
            Payment = payment;
            Trip = trip;
        }

        public void ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1 - List vehicles of specified Brand");
            Console.WriteLine("2 - List of vehicles of a chosen model that have exceeded a predetermined operational tenure");
            Console.WriteLine("3 - Calculate total value of the entire vehicle fleet owned");
            Console.WriteLine("4 - Given a preference for vehicle brand and color");
            Console.WriteLine("5 - Show a list of vehicles that are requiring maintenance");
            Console.WriteLine("Enter choice");

            bool madeChoice = false;
            int choiceNumber = 0; // Define outside the loop scope

            while (!madeChoice)
            {
                string choice = Console.ReadLine();

                if (int.TryParse(choice, out choiceNumber))
                {
                    switch (choiceNumber)
                    {
                        case 1:
                            Console.WriteLine("Enter brand of a car");
                            string brand = Console.ReadLine();
                            List <IVehicle> vehiclesByBrand = VehicleFleet.GetVehiclesByBrand(brand);
                            Console.WriteLine("ID  Brand  Model YearOfManufacture Price");
                            foreach (IVehicle vehicle in vehiclesByBrand)
                            {
                                Console.WriteLine($"{vehicle.ID} {vehicle.Model} {vehicle.YearOfManufacture} {Payment.CalculateRentalCost(vehicle, Driver, Trip)}");
                            }
                            madeChoice = true;
                            break;
                        case 2:
                            Console.WriteLine("Enter brand of a car");
                            string brandTendure = Console.ReadLine();
                            List<Vehicle> vehiclesTendure = VehicleFleet.GetVehiclesExceedingTenure(brandTendure);
                            Console.WriteLine("List of vehicles of a chosen model that have exceeded a predetermined operational tenure: ");
                            Console.WriteLine("ID  Brand  Model YearOfManufacture Mileage");
                            foreach (Vehicle vehicle in vehiclesTendure)
                            {
                                Console.WriteLine($"{vehicle.ID} {vehicle.Model} {vehicle.YearOfManufacture} {vehicle.Mileage}");
                            }
                            madeChoice = true;
                            break;
                        case 3:
                            Console.WriteLine($"Total fleet value: {VehicleFleet.CalculateTotalFleetValue}");
                            madeChoice = true;
                            break;
                        case 4:
                            Console.WriteLine("Enter brand of a car");
                            string brandWithColor = Console.ReadLine();
                            Console.WriteLine("Enter color of a car");
                            string CarsColor = Console.ReadLine();

                            List<IVehicle> vehiclesByBrandAndColor = VehicleFleet.GetVehiclesByBrandAndColor(brandWithColor, CarsColor);

                            Console.WriteLine("ID  Brand  Model  Color  YearOfManufacture Price");
                            foreach (IVehicle vehicle in vehiclesByBrandAndColor)
                            {
                                Console.WriteLine($"{vehicle.ID} {vehicle.Model} {vehicle.Color} {vehicle.YearOfManufacture} {Payment.CalculateRentalCost(vehicle, Driver, Trip)}");
                            }

                            madeChoice = true;
                            break;
                        case 5:
                            List<IVehicle> vehiclesRequiringMaintenance = VehicleFleet.GetVehiclesRequiringMaintenance();
                            foreach (IVehicle vehicle in vehiclesRequiringMaintenance)
                            {
                                Console.WriteLine($"{vehicle.ID} {vehicle.Model} {vehicle.Color} {vehicle.YearOfManufacture}");
                            }
                            madeChoice = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number corresponding to the menu choice.");
                }
            }
        }

    }
}
