using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Car : Vehicle
    {
        private eCarColor m_Color;
        private eDoors m_NumOfDoors;

        public enum eCarColor
        {
           Yellow,
           White,
           Red,
           Black
        }

        public enum eDoors
        {
           Two = 2,
           Three = 3,
           Four = 4,
           Five = 5
        }
    }
}
