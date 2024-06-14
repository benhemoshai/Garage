using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{

    public class Program
    {
        public static void Main()
        {
            GarageManager garageManager = new GarageManager();
            garageManager.addVehicleToGarage();

            DisplayMainMenu();
            int userFuncionalityChoice = InputValidator.getUserSelection(1);

            if (userFuncionalityChoice == 1)
            {

                // Ask for vehicle license plate
                string licensePlate = InputValidator.GetLicensePlate();

                // Check if the vehicle is already in the garage
                if (garageManager.IsVehicleInGarage(licensePlate))
                {
                    Console.WriteLine("Vehicle is already in the garage!");
                    Console.WriteLine("Vehicle status changed to 'InFix'");
                    garageManager.VehicelsInGarage[licensePlate].VehicleStatus = Vehicle.eVehicleStatus.InFix;
                }
                else
                {
                    Console.WriteLine("Vehicle is new!");
                    DisplayVehicleOptions();
                    int vehicleType = InputValidator.getUserSelection(2);
                }

                



                /* bool isRunning = true;
                 Dictionary<object, string> userInputs = new Dictionary<object, string>();
                 GarageManager garageManager = new GarageManager();




                 *//*GarageLogic.GarageManager garageManager = new GarageManager();
                 DisplayWelcomeMessage();*//*


                 while (isRunning)
                 {
                     string userChoice = Console.ReadLine();
                     int userChoiceInt = int.Parse(userChoice); // This will throw an exception if the user input is not a number

                     if (userChoiceInt == 1)
                     {
                         // Ask for vehicle license plate
                         string licensePlate = InputValidator.GetLicensePlate();
                         userInputs.Add("licensePlate", licensePlate);

                         // Check if the vehicle is already in the garage
                         if (garageManager.IsVehicleInGarage(licensePlate))
                         {
                             System.Console.WriteLine("Vehicle is already in the garage!");
                             System.Console.WriteLine("Vehicle status changed to 'InFix'");
                         }
                         else
                         {


                             // Dictionary<object, string> newVehicleDetails = InputValidator.GetVehicleDetails();
                         }
                     }
                     else
                     {
                         isRunning = false;
                     }

                 }

                 System.Console.WriteLine("Goodbye!");

             }*/

                // Check
            }
        }


            private static void DisplayMainMenu()
            {
                Console.Clear();
                Console.WriteLine(

    @"####################################################
Hello and welcome to the garage!
####################################################
Choose an action from the following list:
####################################################
(1) - Insert a new vehicle to the garage
(2) - Display a list of license plates in the garage
(3) - Change a vehicle's status
(4) - Inflate a vehicle's wheels to maximum
(5) - Refuel a vehicle
(6) - Charge an electric vehicle
(7) - Display a vehicle's full details
(8) - Exit the garage
####################################################
");
            }

            private static void DisplayVehicleOptions()
            {

                Console.Clear();
                Console.WriteLine(
    @"Enter the vehicle type:
(1) - Gas car 
(2) - Electric car 
(3) - Motorcycle on gas
(4) - Electric Motorcycle
(5) - Truck");

            }

            private static void AskForVehicleStatus()
            {
                Console.Clear();
                Console.WriteLine("");
            }



    }
}
