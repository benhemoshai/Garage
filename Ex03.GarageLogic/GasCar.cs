using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasCar : GasVehicle
    {
        private eCarColors m_CarColor;
        private eNumOfDoors m_NumOfDoors;
        public GasCar()
        {
            MaxGasAmount = 45f;
            GasType = eGasType.Octan95;
        }
        
        public eCarColors CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public eNumOfDoors NumOfDoors
        {
            get { return m_NumOfDoors; }
            set { m_NumOfDoors = value; }
        }
 
    }
}
