using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricVehicle : Vehicle
    {
        private float m_EnergyLeft;
        private float m_MaxBatteryTime;

        public float BatteryLeft
        {
            get { return m_EnergyLeft; }
            set { m_EnergyLeft = value; }
        }

        public float MaxBatteryTime
        {
            get { return m_MaxBatteryTime; }
            set { m_MaxBatteryTime = value; }
        }

        public void ChargeBattery(float i_AmountOfHoursToCharge)
        {
            if (i_AmountOfHoursToCharge + BatteryLeft <= MaxBatteryTime)
            {
                BatteryLeft += i_AmountOfHoursToCharge;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaxBatteryTime - BatteryLeft);
            }
        }


    }
}
