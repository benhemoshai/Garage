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
        public float CurrentEnergy
        {
            get { return CurrentEnergy; }
            set
            {
                if (value <= MaxEnergy)
                {
                    CurrentEnergy = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, MaxEnergy);
                }
            }
        }
    }
}
