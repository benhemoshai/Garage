using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Engine
    {
        public float MaxEnergy { get; set; }

        private float m_CurrentEnergy;
        public float CurrentEnergy
        {
            get { return m_CurrentEnergy; }
            set
            {
                if (value <= MaxEnergy)
                {
                    m_CurrentEnergy = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, MaxEnergy);
                }
            }
        }
    }
}
