using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{



    public class Program
    {
        private static GarageManager s_GarageManager = new GarageManager();

        public static void Main()
        {

            s_GarageManager.addVehicleToGarage();

            Display.DisplayMainMenu();
            try
            {
                int userChoiceFromMenu = InputValidator.getUserSelectionFromMenu(1, 8);

                switch (userChoiceFromMenu)
                {
                    case 1:
                        InsertNewVehicle();
                        break;
                    case 2:
                        Display.DisplayFilterOptions();
                        FilterCurrentLicensePlates();
                        break;
                    case 3:
                        ChangeVehicleState();
                        break;

                    case 4:
                        InflateVehicleWheels();
                        break;

                    case 5:
                        FuelGasVehicle();
                        break;

                    case 6:
                        ChargeBattery();
                        break;

                    case 7:
                        PrintVehicleDetails();
                        break; 

                    default:
                        break;
                }


            }
            catch (FormatException ex)
            {
                System.Console.WriteLine("Please enter a number!" + ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye!");
            }
        }

        private static void PrintVehicleDetails()
        {
            string licensePlate = GetExistingVehicleLicensePlate();
            PrintVehicleDetails(licensePlate);
        }

        private static void PrintVehicleDetails(string i_LicensePlate)
        {
            Vehicle vehicle = s_GarageManager.VehicelsInGarage[i_LicensePlate];
            Console.WriteLine(
@"####################################################
These are the vehicle details: 

License number: {0}
Model name: {1}
Owner's name: {2}
Owner's phone number: {3}

Vehicle's status: {4}

Wheels status: {5}"
);
            if (vehicle is GasCar)
            {
                GasCar gascar = vehicle as GasCar;
                Console.WriteLine(
@"Gas type: {0}
Gas left in the tank: {1}
Car color: {2}
Number of doors: {3}"
);
            }
            else if (vehicle is GasMotorcycle)
            {
                Console.WriteLine(
@"Gas type: {0}
Gas left in the tank: {1}
License type: {2}
Engine's volume: {3}"
);
            }
            else if(vehicle is ElectricMotorcycle)
            {
                Console.WriteLine(
@"Battery left: {0}
License type: {1}
Engine's volume: {2}"
);
            }
            else if (vehicle is ElectricCar)
            {
                Console.WriteLine(
@"Battery left: {0}
Car color: {2}
Number of doors: {3}"
);
            }
            else
            {
                Console.WriteLine(
@"Gas type: {0}
Gas left in the tank: {1}
Does it carry dangerous materials: {2}
Cargo's volume: {3}"
);
            }

        }

        private static void InsertNewVehicle()
        {
            Dictionary<string, object> vehicleDetails = new Dictionary<string, object>();

            // Ask for vehicle license plate
            string licensePlate = InputValidator.GetDetailsAboutVehicle("License Plate");

            // Check if the vehicle is already in the garage
            if (s_GarageManager.IsVehicleInGarage(licensePlate))
            {
                Console.WriteLine("Vehicle is already in the garage!");
                Console.WriteLine("Vehicle status changed to 'InFix'");
                s_GarageManager.VehicelsInGarage[licensePlate].VehicleStatus = Vehicle.eVehicleStatus.InFix;
            }
            else
            {
                Console.WriteLine("Vehicle is new!");
                Display.DisplayVehicleOptions();

                string vehicleType = InputValidator.getUserSelectionFromMenu(1, 5).ToString();
                vehicleDetails.Add("VehicleType", vehicleType);

                string ownerName = InputValidator.GetDetailsAboutVehicle("Owner Name");
                vehicleDetails.Add("OwnerName", ownerName);

                string ownerPhoneNumber = InputValidator.GetDetailsAboutVehicle("Owner Phone Number");
                vehicleDetails.Add("OwnerPhoneNumber", ownerPhoneNumber);

                string vehicleCurrentEnergy = InputValidator.GetDetailsAboutVehicle("Energy");
                vehicleDetails.Add("CurrentEnergy", vehicleCurrentEnergy);

                string vehicleCurrentAirPressure = InputValidator.GetDetailsAboutVehicle("Air Pressure");
                vehicleDetails.Add("CurrentAirPressure", vehicleCurrentAirPressure);

                if (vehicleType == "1" || vehicleType == "2") // ElectricCar or GasCar
                {
                    string vehicleColor = InputValidator.GetDetailsAboutVehicle("Color");
                    vehicleDetails.Add("Color", vehicleColor);

                    string vehicleNumOfDoors = InputValidator.GetDetailsAboutVehicle("Number of doors");
                    vehicleDetails.Add("NumOfDoors", vehicleNumOfDoors);
                }
                else if (vehicleType == "3" || vehicleType == "4") // ElectricMotorcycle or GasMotorcycle
                {
                    string vehicleLicenseType = InputValidator.GetDetailsAboutVehicle("License Type");
                    vehicleDetails.Add("LicenseType", vehicleLicenseType);

                    string vehicleEngineVolume = InputValidator.GetDetailsAboutVehicle("Engine Volume");
                    vehicleDetails.Add("EngineVolume", vehicleEngineVolume);
                }
                else if (vehicleType == "5") // Truck
                {
                    string vehicleCarryingCapacity = InputValidator.GetDetailsAboutVehicle("Carrying Capacity");
                    vehicleDetails.Add("CarryingCapacity", vehicleCarryingCapacity);

                    string isCarryingDangerousMaterials = InputValidator.IsCarryingDangerousMaterials();
                    vehicleDetails.Add("IsCarryingDangerousMaterials", isCarryingDangerousMaterials);
                }

                try
                {
                    Dictionary<string, object> validatedVehicleDetails = InputValidator.ValidateAndGetVehicleDetails(vehicleDetails);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message + "Please enter a number!");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public static bool isVehicleInGarage(string i_LicensePlate)
        {
            bool isVehicleInGarage = false;
            if (s_GarageManager.IsVehicleInGarage(i_LicensePlate))
            {
                isVehicleInGarage = true;
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with license plate {0} is not in the garage!", i_LicensePlate));
            }
            return isVehicleInGarage;
        }

        private static void FilterCurrentLicensePlates()
        {
            Vehicle.eVehicleStatus status = Vehicle.eVehicleStatus.InFix;
            List<string> licenseIDS = new List<string>();

            int filterOption = InputValidator.getUserSelectionFromMenu(1, 4);

            if (filterOption == 1) //display all the vehicles in the garage
            {
                licenseIDS = s_GarageManager.VehicelsInGarage.Keys.ToList();
            }
            else
            {
                if (filterOption == 2) //infix
                {
                    status = Vehicle.eVehicleStatus.InFix;
                }

                else if (filterOption == 3) //fixed
                {
                    status = Vehicle.eVehicleStatus.Fixed;
                }
                else //paid
                {
                    status = Vehicle.eVehicleStatus.Paid;
                }

                List<Vehicle> v = s_GarageManager.VehicelsInGarage.Values.Where(vehicle => vehicle.VehicleStatus == status).ToList();
                foreach (Vehicle vehicle in v)
                {
                    licenseIDS.Add(vehicle.LicenseID);
                }

            }

            if (licenseIDS.Count == 0)
            {
                Console.WriteLine("There are no {0} vehicles in the garage right now.", status);
            }
            else
            {
                int carNumber = 1;
                foreach (string licenseID in licenseIDS)
                {
                    Console.WriteLine("{0}. {1}", carNumber++, licenseID);
                }
            }
        }


        private static void ChangeVehicleState()
        {
            Vehicle.eVehicleStatus status = Vehicle.eVehicleStatus.InFix;

            string licensePlate = GetExistingVehicleLicensePlate();
            Display.DisplayVehicleStates();
            int vehicleState = InputValidator.getUserSelectionFromMenu(1, 3);

            switch (vehicleState)
            {
                case 1:
                    status = Vehicle.eVehicleStatus.InFix;
                    break;

                case 2:
                    status = Vehicle.eVehicleStatus.Fixed;
                    break;

                case 3:
                    status = Vehicle.eVehicleStatus.Paid;
                    break;
            }

            s_GarageManager.VehicelsInGarage[licensePlate].VehicleStatus = status;
        }


        private static void InflateVehicleWheels()
        {
            string licensePlate = GetExistingVehicleLicensePlate();
            Display.DisplayInflateOptions();
            int userChoice = InputValidator.getUserSelectionFromMenu(1, 2);

            switch (userChoice)
            {
                case 1:

                    int numberOfWheel = 1;

                    foreach (Wheel wheel in s_GarageManager.VehicelsInGarage[licensePlate].Wheels)
                    {
                        float airPressureToAdd = wheel.MaxAirPressure - wheel.CurrentAirPressure;
                        //float airPressureToAdd = 30f; // to check if it handles wrong amount of air pressure

                        try
                        {
                            wheel.Inflate(airPressureToAdd);
                            Console.WriteLine("Great, the air pressure in wheel number {0} is now: {1}", numberOfWheel++ ,wheel.CurrentAirPressure);
                        }
                        catch (ValueOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    break;

                case 2: // add the option to return to the main menu
                    break;

            }
        }

        private static void FuelGasVehicle()
        {
            bool isValidVehicleType = false;
            bool isValidGas = false;

            while (!isValidVehicleType || !isValidGas)
            {
                try
                {
                    string licensePlate = GetExistingVehicleLicensePlate();
                    isValidVehicleType = CheckVehicleType(licensePlate,"GasVehicle");
                    GasVehicle gasVehicle = s_GarageManager.VehicelsInGarage[licensePlate] as GasVehicle;

                    Display.DisplayGasTypes();

                    int chosenGasType = InputValidator.getUserSelectionFromMenu(1, 4);

                    GasVehicle.eGasType gasType = GasVehicle.eGasType.Soler; //initialize the gasType object

                    switch (chosenGasType)
                    {
                        case 1:
                            gasType = GasVehicle.eGasType.Soler; 
                            break;
                        case 2:
                            gasType = GasVehicle.eGasType.Octan95;
                            break;
                        case 3:
                            gasType = GasVehicle.eGasType.Octan96;
                            break;
                        case 4:
                            gasType = GasVehicle.eGasType.Octan98;
                            break;

                    }

                    float gasAmountToAdd = InputValidator.GetEnergyAmountToAdd();

                    gasVehicle.Fuel(gasAmountToAdd, gasType);

                    isValidGas = true;
                    Console.WriteLine("Successfully fueled the vehicle");
                }
                catch (ArgumentException ex) 
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }


        private static void ChargeBattery()
        {
            bool isValidVehicleType = false;
            bool isValidAmountOfBattery = false;
      
            while (!isValidVehicleType || !isValidAmountOfBattery)
            {
                try
                {
                    string licensePlate = GetExistingVehicleLicensePlate();
                    isValidVehicleType = CheckVehicleType(licensePlate, "ElectricVehicle");
                    ElectricVehicle electricVehicle = s_GarageManager.VehicelsInGarage[licensePlate] as ElectricVehicle;

                    float BatteryAmountToAdd = InputValidator.GetEnergyAmountToAdd();

                    electricVehicle.ChargeBattery(BatteryAmountToAdd);

                    isValidAmountOfBattery = true;
                    Console.WriteLine("Successfully charged the vehicle");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    


        private static bool CheckVehicleType(string i_LicensePlate, string i_TypeOfVehicle) // check again
        {
            bool isValidVehicleType = false;
            if (i_TypeOfVehicle.Equals("GasVehicle"))
            {
                if (s_GarageManager.VehicelsInGarage[i_LicensePlate] is GasVehicle)
                {
                    isValidVehicleType = true;
                }
                else
                {
                    throw new ArgumentException("The license plate you gave is not a Gas Vehicle");
                }
            }
            else
            {
                if (s_GarageManager.VehicelsInGarage[i_LicensePlate] is ElectricVehicle)
                {
                    isValidVehicleType = true;
                }
                else
                {
                    throw new ArgumentException("The license plate you gave is not an Electric Vehicle");
                }
            }
            return isValidVehicleType;
        }


        public static string GetExistingVehicleLicensePlate()
        {
            bool isExists = false;
            string licensePlateNumber = "";
            while (!isExists)
            {
                try
                {
                    licensePlateNumber = InputValidator.GetDetailsAboutVehicle("License Plate");
                    isExists = s_GarageManager.IsVehicleInGarage(licensePlateNumber);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return licensePlateNumber;
        }
    }
}
