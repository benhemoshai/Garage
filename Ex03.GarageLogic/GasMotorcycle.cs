using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.Motorcycle;
using static Ex03.GarageLogic.Vehicle;

namespace Ex03.GarageLogic
{
    class GasMotorcycle : Motorcycle, IGasVehicle
    {
        public eGasType GasType
        {
            get { return eGasType.Octan98; }
        }

        public float GetCurrentGasAmount
        {
            get { return EnergyLeftPercents; }
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
