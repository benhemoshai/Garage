using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseID;
        private float m_EnergyLeftPercentage;
        private Wheel[] m_Wheels;

        private string m_Owner;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;

        public Vehicle()
        {
            int numberOfWheels = 0;
            float maxAirPressure = 0;

            if (this is GasMotorcycle || this is ElectricMotorcycle)
            {
                numberOfWheels = 2;
                maxAirPressure = 33;
            }
            else if (this is GasCar || this is ElectricCar)
            {
                numberOfWheels = 5;
                maxAirPressure = 31;
            }
            else if (this is Truck)
            {
                numberOfWheels = 12;
                maxAirPressure = 28;
            }

            m_Wheels = new Wheel[numberOfWheels];
            for (int i = 0; i < m_Wheels.Length; i++)
            {
                m_Wheels[i] = new Wheel(maxAirPressure);
            }
        }

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

        public float EnergyLeftPrecentage
        {
            get { return m_EnergyLeftPercentage; }
            set { m_EnergyLeftPercentage = value; }
        }

        public Wheel[] Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }

        public string Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }
        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
            set { m_OwnerPhoneNumber = value; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public enum eLicenseType
        {
            A,
            A1,
            AA,
            B1
        }

        public enum eVehicleStatus
        {
            InFix,
            Fixed,
            Paid
        }

        public enum eCarColors
        {
            Yellow,
            White,
            Red,
            Black
        }
        public enum eNumOfDoors
        {
            Two,
            Three,
            Four,
            Five
        }
    }
}
