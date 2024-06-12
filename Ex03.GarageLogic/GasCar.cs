using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    class GasCar : Car, IGasVehicle
    {
        public GasCar() 
        {
         
        }

        public eGasType GasType
        {
            get { return eGasType.Octan95; }
        }

        public float GetCurrentGasAmount
        {
            get { return EnergyLeft; }
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
