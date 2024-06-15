using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasVehicle : Vehicle
    {
        private float m_GasLeft;
        private float m_MaxGasAmount;
        private eGasType m_GasType;

        public eGasType GasType
        {
            get { return m_GasType; }
            set { m_GasType = value; }
        }

        public float GasLeft
        {
            get { return m_GasLeft; }
            set { m_GasLeft = value; }
        }

        public float MaxGasAmount
        {
            get { return m_MaxGasAmount; }
            set { m_MaxGasAmount = value; }
        }

        public void Fuel(float i_GasAmountToAdd, eGasType i_GasType)
        {
            if (i_GasType == GasType)
            {
                if (i_GasAmountToAdd + GasLeft <= MaxGasAmount)
                {
                    GasLeft += i_GasAmountToAdd;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, MaxGasAmount - GasLeft);
                }
            }
            else
            {
                throw new ArgumentException("Wrong gas type");
            }
        }

        public enum eGasType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }
    }

}
