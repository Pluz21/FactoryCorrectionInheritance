using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCorrectionInheritance
{ 
public class Car : Vehicle
    {

        #region fieldsAndProperties
        public const int MIN_PASSENGERS = 1, MAX_PASSENGERS = 8;
        public const int MIN_DOORS = 2, MAX_DOORS = 4;


        public int Passengers { get; private set; } = 1;
        public int Doors { get; private set; } = 2;

        #region Constructor
        public Car() 
        {    
        }

        public Car(VehicleColor _color, int _passengers, int _doors)
        {
            Color = _color;
            Passengers = _passengers;
            Doors = _doors;
        }

        public Car(CarFactory.TemplateCarModel _model)
        { 
            Color = _model.Color;
            Passengers = _model.Passengers;
            Doors = _model.Doors;
        }

        #endregion Constructor
        #endregion fieldsAndProperties

        #region Methods
        public override void StartEngine() => Console.WriteLine("Start Car engine");
        public override void StopEngine() => Console.WriteLine("Start Car engine");
        public override string ToString()                           // RETURN TYPE STRING TO -  NEEDS A RETURN
        {
            return $"You have just produced a {Color} car. It has {Doors} doors and a capacity of {Passengers} passengers.";
        }

        #endregion Methods
    }
}
