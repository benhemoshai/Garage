using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    abstract class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public Motorcycle()
        {
            Wheels = new Wheel[2];
            for (int i = 0; i < Wheels.Length; i++)
            {
                Wheels[i] = new Wheel(string.Format("Michellin {0}", i), 33f, 33f);
            }
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
        }

        public enum eLicenseType
        {
            A,
            A1,
            AA,
            B1
        }
    }
}
