using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Vehicle;

namespace Ex03.GarageLogic
{
    public class GasMotorcycle : GasVehicle
    {
        public GasMotorcycle()
        {
            MaxGasAmount = 5.5f;
            GasType = eGasType.Octan98;
        }

    }
}
