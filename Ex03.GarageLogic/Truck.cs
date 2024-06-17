using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.GarageManager;

namespace Ex03.GarageLogic
{

    public class Truck : Vehicle
    {
        public bool IsCarryingDangerousMaterials { get; set; }
        public float CargoVolume { get; set; }

        public const int m_NumOfWheels = 12;
        public const int k_MaxAirPressure = 28;


        public Truck() : base(m_NumOfWheels, k_MaxAirPressure)
        {
            GasEngine engine = new GasEngine();
            engine.MaxEnergy = 120;
            VehicleType = Enums.eVehicleType.Truck;
            engine.GasType = Enums.eGasType.Soler;
        }


    }


}
