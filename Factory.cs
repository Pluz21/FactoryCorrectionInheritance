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

        public  event Action OnStartProduction;   // Declaring event    
        public  event Action OnEndProduction;   
        public  event Action OnVehicleProduced;

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
       

        #endregion Methods

    }
}

