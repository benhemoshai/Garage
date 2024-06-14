using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricCar : Car, IElectricVehicle
    {
        public float GetRemainingBatteryHours
        {
            get { return EnergyLeftPercents; }
        }

        public float GetMaxBatteryTime
        {
            get { return 3.5f; }
        }

        void IElectricVehicle.ChargeBattery(float i_AmountOfHoursToCharge)
        {

        }
    }
}
