using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCorrectionInheritance
{
    public enum VehicleColor    // Declaring ENUM outside of class to allow the child to access this ENUM 
    {
        Black, Blue, Green, BlueGreen,
        Red, Yellow, YellowGreen,
        Magenta, MagentaGreen
    }

    public abstract class Vehicle                               // Abstract
    {
        public VehicleColor Color { get; protected set; } = VehicleColor.Black;   // Only access itself
                                                                                  // if we add STATIC here, we will only have ONE VehicleColor applying to ALL our vehicles.
        #region Constructor
        public Vehicle()                            // Constructor with 
        
        {
            Color = VehicleColor.Black;
        } 
        public Vehicle(VehicleColor _color) 
        
        {
            Color = _color;
        }
        #endregion Constructor
        #region Methods
        public abstract void StartEngine();                     // Abastract function needs no brackets.
                                                                // ACTS LIKE AN EMPTY FORCED VIRTUAL FUNCTION on childs
        public abstract void StopEngine();
        

        #endregion Methods
    }
}
