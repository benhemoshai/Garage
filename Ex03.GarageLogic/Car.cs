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
        private eNumOfDoors m_NumOfDoors;
        
        public Car(eCarColor i_CarColor, eNumOfDoors i_NumOfDoors) : base()
        {
            m_Color = i_CarColor;
            m_NumOfDoors = i_NumOfDoors;

            Wheels = new Wheel[5];
            for (int i = 0; i < Wheels.Length; i++)
            {
                Wheels[i] = new Wheel(string.Format("Michellin {0}", i), 31f, 31f);
            }
        }

        public eCarColor CarColor
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public eNumOfDoors NumOfDoors
        {
            get { return this.m_NumOfDoors; }
            set { this.m_NumOfDoors = value;}
        }


        public enum eCarColor
        {
           Yellow,
           White,
           Red,
           Black
        }

        public enum eNumOfDoors
        {
           Two = 2,
           Three = 3,
           Four = 4,
           Five = 5
        }
    }
}
