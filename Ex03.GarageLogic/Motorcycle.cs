using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    abstract class Motorcycle : Vehicle
    {
        private eLicenseType m_licenseType;
        private int m_EngineVolume;

        public enum eLicenseType
        {
            A,
            A1,
            AA,
            B1
        }
    }
}
