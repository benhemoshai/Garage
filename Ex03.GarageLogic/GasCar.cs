using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class GasCar : Car, IGasVehicle
    {
        
        public eGasType GasType
        {
            get { return eGasType.Octan95; }
        }

        public float GetCurrentGasAmount
        {
            get { return EnergyLeftPercents; }
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
