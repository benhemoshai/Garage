using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    class ElectricMotorcycle : Motorcycle, IElectricVehicle
    {
        private string m_ModelName;
        private string m_LicenseID;
        private float m_EnergyLeft;
        private List<Wheel> m_Wheels;

        private eLicenseType m_licenseType;
        private int m_EngineVolume;

        public float GetRemainingBatteryHours
        {
            get { return m_EnergyLeft; }
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
