using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : Motorcycle, IElectricVehicle
    {
        public ElectricMotorcycle()
        {

        }

        public float GetRemainingBatteryHours
        {
            get { return EnergyLeftPercents; }
        }

        public float GetMaxBatteryTime
        {
            get { return 2.5f; }
        }

        void IElectricVehicle.ChargeBattery(float i_AmountOfHoursToCharge)
        {

        }
    }
}
