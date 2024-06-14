using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public interface IGasVehicle
    {
        eGasType GasType
        {
            get;
        }

        float GetCurrentGasAmount
        {
            get;
        }

        float GetMaxGasAmount
        {
            get;
        }

        void Fuel(float i_GasAmountToAdd, eGasType i_GasType);
        
    }
    public enum eGasType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98
    }

}
