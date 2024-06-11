using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.Motorcycle;

namespace GarageLogic
{
    class GasMotorcycle : Motorcycle, IGasVehicle
    {
        private string m_ModelName;
        private string m_LicenseID;
        private float m_EnergyLeft;
        private List<Wheel> m_Wheels;

        private eLicenseType m_licenseType;
        private int m_EngineVolume;

        public eGasType GasType
        {
            get { return eGasType.Octan98; }
        }

        public float GetCurrentGasAmount
        {
            get { return m_EnergyLeft; }
        }

        public float GetMaxGasAmount
        {
            get { return 5.5f; }
        }

        void IGasVehicle.Fuel(float i_GasAmountToAdd, eGasType i_GasType)
        {

        }

    }
}
