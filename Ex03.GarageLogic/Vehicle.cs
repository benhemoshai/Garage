using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseID;
        private float m_EnergyLeft;
        private List<Wheel> m_Wheels;

        private string m_Owner;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public string LicenseID
        {
            get { return m_LicenseID; }
            set { m_LicenseID = value; }
        }


        enum eVehicleStatus
        {
            InFix,
            Fixed,
            Paid
        }
    }
}
