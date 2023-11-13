using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCorrectionInheritance
{
    public class Airplane : Vehicle
    {
        public const int MIN_ENGINES = 1, MAX_ENGINES = 4;                              // CAPS FOR CONST VARIABLES
        public const int MIN_PASSENGERS = 1, MAX_PASSENGERS = 350;

        public int Engines { get; private set; } = 1;
        public int Passengers { get; private set; } = 1;

        public Airplane() 
        
        { }

        public Airplane(VehicleColor _color, int _engines, int _passengers)
        {
            Engines = _engines;
            Passengers = _passengers;
            Color = _color;
        }

        public Airplane(AirplaneFactory.TempPlaneModel _model)                          // ABLE TO ACCESS WITH NAME SPACE
        {
            Color = _model.Color;
            Engines = _model.Engines;
            Passengers = _model.Passengers;
        }

        public override void StartEngine() => Console.WriteLine("Start Airplane engine");
    
        public override void StopEngine() => Console.WriteLine("Stop Airplane engine");

        public virtual void TakeOff()
        {

            Console.WriteLine("Taking off");
        }
        public virtual void Land() => Console.WriteLine("Landing");

        //public override string ToString() => $"New {Color} Plane with {Engines} engine(s) and it can take {Passengers} passengers has been produced";
        // BASE FUNCTION CSHARP TO CONVERT TO STRING SHORTER VERSION
        public override string ToString()                           // RETURN TYPE STRING TO -  NEEDS A RETURN
        {
            return $"New {Color} Plane with {Engines} engine(s) and it can take {Passengers} passengers has been produced";
        }


    }
}


