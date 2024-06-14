using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string,Vehicle> m_VehiclesInGarage = new Dictionary<string, Vehicle>();


        public Dictionary<string, Vehicle> VehicelsInGarage
        {
            get { return m_VehiclesInGarage; }
            set { m_VehiclesInGarage = value; }
        }

        public void addVehicleToGarage()
        {
            GasCar car = new GasCar();
            car.LicenseID = "175399";
            m_VehiclesInGarage.Add(car.LicenseID, car);
      
        }

/*
        public static void Main()
        {
            *//*GasCar hyundai = new GasCar("i-10", "17422111", "Shai Ben Hemo", "0500000000", Vehicle.eVehicleStatus.InFix, Car.eCarColor.White, Car.eNumOfDoors.Four);
            Truck tetra = new Truck("scania", "1112222", "Bar Azulay", "0540000000", Vehicle.eVehicleStatus.Paid, true, 100f);
            hyundai.ModelName = "i-20";

            ElectricMotorcycle suzuki = new ElectricMotorcycle("R750", "1132222", "Ben", "000000000", Vehicle.eVehicleStatus.Fixed, Motorcycle.eLicenseType.AA, 750);
            Console.WriteLine(suzuki.Equals(tetra));*//*
            //print all the details about the car

            GasCar toyota = new GasCar();
            toyota.ModelName = "corolla";
            toyota.CarColor = Car.eCarColor.White;
            toyota.EnergyLeftPercents = 30;
            toyota.Owner = "Shai";
            toyota.LicenseID = "175399";

        }
*/
        public bool IsVehicleInGarage(string i_LicenseID)
        {
            bool isVehicleInGarage = false;

            foreach (KeyValuePair<string,Vehicle> vehicle in m_VehiclesInGarage)
            {
                //if (vehicle.Equals(i_LicenseID))
                if (vehicle.Key == i_LicenseID)
                { 
                    isVehicleInGarage = true;
                }
            }

            return isVehicleInGarage;
        }
    }
}
