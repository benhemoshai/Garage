using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public interface IElectricVehicle
    {
        float GetRemainingBatteryHours
        {
            get;
        }

        float GetMaxBatteryTime 
        { 
            get;
        }

        void ChargeBattery(float i_AmountOfHoursToCharge);
        

    }
}
