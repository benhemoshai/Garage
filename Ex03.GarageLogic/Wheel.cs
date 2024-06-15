using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }
        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }
        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set { m_MaxAirPressure = value; } // not sure if we need
        }
        public void Inflate(float i_AmountOfAirPressureToAdd)
        {
            if (CurrentAirPressure + i_AmountOfAirPressureToAdd <= MaxAirPressure)
            {
                CurrentAirPressure += i_AmountOfAirPressureToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxAirPressure - CurrentAirPressure);
            }
            
        }
    }
}
