﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.GarageManager;


namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public Enums.eCarColors CarColors { get; set; }
        public Enums.eNumOfDoors NumOfDoors { get; set; }

        public const int k_NumOfWheels = 5;
        public const int k_MaxAirPressure = 31;

        public Car(Enums.eEngineType i_EngineType) : base(k_NumOfWheels, k_MaxAirPressure)
        {
            if (i_EngineType == Enums.eEngineType.Gas)
            {
                GasEngine engine = new GasEngine();
                engine.MaxEnergy = 45;
                engine.GasType = Enums.eGasType.Octan95;
                VehicleType = Enums.eVehicleType.GasCar;
                VehicleEngine = engine;
            }
            else
            {
                ElectricEngine engine = new ElectricEngine();
                engine.MaxEnergy = 3.5f;
                VehicleType = Enums.eVehicleType.ElectricCar;
                VehicleEngine = engine;
            }

        }
       /* public Enums.eCarColors CarColors
        {
            get
            {
                return CarColors;
            }
            set
            {
                CarColors = value;
            }
        }*/
    }
}
