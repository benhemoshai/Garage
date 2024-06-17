﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public string ModelName { get; set; }
        public string LicensePlateNumber { get; set; }
        public float EnergyLeftPrecentage { get; set; }
        public Wheel[] Wheels { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public Enums.eVehicleStatus VehicleStatus { get; set; }
        public Engine VehicleEngine { get; set; }
        public Enums.eVehicleType VehicleType { get; set; }

        public Vehicle(int i_NumOfWheels, float i_MaxAirPressure)
        {
            Wheels = new Wheel[i_NumOfWheels];
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Wheels[i] = new Wheel(i_MaxAirPressure);
            }
        }

        public void InflateWheelsToMax() // MAYBE MOVE TO WHEELS CLASS
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.InflateWheelToMax();
            }
        }

        public void Charge(float i_Amount, Enums.eGasType i_GasType)
        {
            if (VehicleEngine is GasEngine gasEngine)
            {
                gasEngine.Fuel(i_Amount, i_GasType);
            }
            else
            {
                throw new ArgumentException("Invalid engine type");
            }

        }

        public void Charge(float i_Amount)
        {
            if (VehicleEngine is ElectricEngine electricEngine)
            {
                electricEngine.ChargeBattery(i_Amount);
            }
            else
            {
                throw new ArgumentException("Invalid engine type");
            }
        }


        // Equals
        public override bool Equals(object obj)
        {
            bool isEqual = false;
            if (obj is Vehicle vehicle)
            {
                isEqual = LicensePlateNumber.Equals(vehicle.LicensePlateNumber);
            }

            return isEqual;
        }

        // ToString
        public override string ToString()
        {
            return string.Format(
                "Model Name: {0}\nLicense Plate Number: {1}\nEnergy Left Precentage: {2}\nOwner Name: {3}\nOwner Phone Number: {4}\nVehicle Status: {5}\nVehicle Engine: {6}\nVehicle Type: {7}",
                ModelName, LicensePlateNumber, EnergyLeftPrecentage, OwnerName, OwnerPhoneNumber, VehicleStatus, VehicleEngine, VehicleType);
        }
    }
}
