using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.Motorcycle;

namespace GarageLogic
{
    class Truck : Vehicle
    {
        private string m_ModelName;
        private string m_LicenseID;
        private float m_EnergyLeft;
        private Wheel [] m_Wheels;

        private bool m_HasDangerousMaterials;
        private float m_CargoVolume;

        public Truck()
        {
            m_Wheels = new Wheel[12];
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.MaxAirPressure = 28f;
            }
        }

        public float EnergyLeft
        {
            get { return m_EnergyLeft; }
        }
    }
}
