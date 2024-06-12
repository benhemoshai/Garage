﻿using System;
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
        private Wheel [] m_Wheels;

        private string m_Owner;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;

        public Vehicle(string i_ModelName, string i_LicenseID, string i_Owner, string i_OwnerPhoneNumber, eVehicleStatus i_VehicleStatus)
        {
            m_ModelName = i_ModelName;
            m_LicenseID = i_LicenseID;
            m_Owner = i_Owner;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleStatus = i_VehicleStatus;
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

        public float EnergyLeft
        {
            get { return m_EnergyLeft; }
            set { m_EnergyLeft = value; }
        }

        public Wheel[] Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }
        
        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }


        public enum eVehicleStatus
        {
            InFix,
            Fixed,
            Paid
        }

        public override bool Equals(object obj)
        {
            bool isEqual = false;
            try
            {
                isEqual = m_LicenseID.Equals(((Vehicle)obj).LicenseID);
            }
            catch (Exception ex) 
            {
                isEqual = false;
            }
            return isEqual;
            
        }
    }
}
