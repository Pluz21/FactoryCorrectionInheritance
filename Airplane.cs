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

        public override void StartEngine() => Console.WriteLine("Start Airplane engine");
    
        public override void StopEngine() => Console.WriteLine("Stop Airplane engine");

        public virtual void TakeOff()
        {

            Console.WriteLine("Taking off");
        }
        public virtual void Land()
        {
            Console.WriteLine("Land");

        }

    }
}


