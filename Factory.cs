using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCorrectionInheritance
{

public abstract class Factory
    {
        #region fieldsAndProperties

        public abstract event Action OnStartProduction;   // Declaring event    
        //public delegate OnStartProduct();                 // This is how we would declare a delegate
        //OnStartProduction onStartProd;
        public abstract event Action OnEndProduction;   
        public abstract event Action OnVehicleProduced;

        protected List<Vehicle> allVehicles = new List<Vehicle>();                          // DECLARING DYNAMIC ,ITS LIKE A TARRAY
        public Vehicle this[int _index] => allVehicles[_index];                             // ACCESSOR TO GET VEHICLE IN INDEX 
        public string Name { get; private set; } = "Factorioso";                             // Instead of having to do vehicle.allVehicles.[index] we will be able to call 
                                                                                            // vehicle.[index] 
                                                                                            //this refers to Factory class
        #endregion fieldsAndProperties
        #region Constructor
        public Factory()
        { 
        
        }
        public Factory(string _name)
        { 
            Name = _name;
        }

        

        #endregion Constructor
        #region Methods
        protected  void Stop()
        {
            Console.WriteLine("Switching to the next factory");
        }
        public virtual void StartProduction()                                               // VIRTUAL AND ALREADY CALLING AN ABSTRACT FUNCTION
        {
            CreateVehicle();
        }

        public virtual void EndProduction() 
        { 
        
        }
        protected abstract Vehicle CreateVehicle();                                         // CAN BE PROTECTED SINCE WE ONLY NEED TO CALL STARTPRODUCTION()
                                                                                            // THIS FUNCTION RETURNS THE VEHICLE
        protected void SetColor()
        {
            string[] _colors = Enum.GetNames(typeof(VehicleColor));                         // We have to specify TYPEOF before our actual Enum  
            // =! syntax Enum.GetNames<VehicleColor>();                                    //  We declared this Enum in our Vehicle class
            #endregion Methods

        }
    }   
}

