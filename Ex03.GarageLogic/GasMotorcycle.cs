using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Vehicle;

namespace Ex03.GarageLogic
{
    public class GasMotorcycle : GasVehicle
    {
        private eLicenseType m_LicenseType;
        private float m_EngineVolume;
        public GasMotorcycle()
        {
            MaxGasAmount = 5.5f;
            GasType = eGasType.Octan98;
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }
        public float EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
        }

    }
}
