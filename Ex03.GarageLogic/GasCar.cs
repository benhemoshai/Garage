using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    class GasCar : Car, IGasVehicle
    {
        private string m_ModelName;
        private string m_LicenseID;
        private float m_EnergyLeft;
        private List<Wheel> m_Wheels;

        private eCarColor m_Color;
        private eDoors m_NumOfDoors;
        
        public eGasType GasType
        {
            get { return eGasType.Octan95; }
        }

        public float GetCurrentGasAmount
        {
            get { return m_EnergyLeft; }
        }

        public float GetMaxGasAmount
        {
            get { return 45f; }
        }

        void IGasVehicle.Fuel(float i_GasAmountToAdd, eGasType i_GasType)
        {

        }


    }
}
