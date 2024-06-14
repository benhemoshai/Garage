using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle, IGasVehicle
    {
        private bool m_HasDangerousMaterials;
        private float m_CargoVolume;

        public Truck()
        {
            Wheels = new Wheel[12];
            for (int i = 0; i < Wheels.Length; i++)
            {
                Wheels[i] = new Wheel(string.Format("Michellin {0}", i), 28f, 28f);
            }
        }

        public bool HasDangerousMaterials
        {
            get { return m_HasDangerousMaterials; }
            set { m_HasDangerousMaterials = value;}
        }

        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value;}
        }

        public eGasType GasType
        {
            get { return eGasType.Soler; }
        }

        public float GetCurrentGasAmount
        {
            get { return EnergyLeftPercents; }
        }

        public float GetMaxGasAmount
        {
            get { return 120f; }
        }

        void IGasVehicle.Fuel(float i_GasAmountToAdd, eGasType i_GasType)
        {

        }


    }
}
