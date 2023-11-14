using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public abstract event Action<Vehicle> OnVehicleProduced;
        public event Action<VehicleColor> OnColorSelected = null;                           // 
        public event Action OnVehicleStockDisplayed = null;

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
        protected void SelectColor()
        {
            string[] _colors = Enum.GetNames(typeof(VehicleColor));                         // We have to specify TYPEOF before our actual Enum  
            // =! syntax Enum.GetNames<VehicleColor>();                                    //  We declared this Enum in our Vehicle class
            Console.WriteLine("Select the vehicle color!");
            int _length = _colors.Length;
            for (int i = 0; i < _length; i++)
            {
                string _color = _colors[i];                                                 // We retrieve each individual color of our Enum
                Console.WriteLine("{0} - {1}",i+1,_color);                                  // Starting our list from 1 (i+1)


            }                                                                               // TryParse takes 2 arguments, the string, and an out int 
            string _input = Console.ReadLine();                                             // We want to convert the string to number
            bool _validInput = int.TryParse(_input,out int _result);                        // tryparse will return a signed. So it can be negative it will

                                                                                            // int _result;             OTHER SYNTAX
                                                                                            // bool _validInput = int.TryParse(_input,out _result);                          
                                                                                            // tryparse will return a signed. So it can be negative it will
            if (!_validInput)                                                               // convert it to positive
            {
                Console.WriteLine("Not a valid entry, retry");
                Console.Read();
                Console.Clear();
                SelectColor();
                return;                                                                     // return to avoid going further in function
            }
            _result = _result < 1 ? 1 : _result > _length ? _length : _result;               // Clamping our _result to lower and higher 
            VehicleColor _selection = (VehicleColor)(_result-1);                            //Syntax to cast to VehicleColor, -1 because we started from 1 in choices
                                                                                            // _selection is the choice of user, so we cast the choice to
                                                                                            // our Enum. So now we have the color selection in our Enum


            OnColorSelected?.Invoke(_selection);      

            #endregion Methods

        }
        public void DisplayStock()
        {
            int _size = allVehicles.Count;
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine(allVehicles[i]);
            }
            OnVehicleStockDisplayed?.Invoke();
        }
        protected void SelectSettings(string _label, int _selectionMin, int _selectionMax, string _endMessage, Action<int> _callback)   //FUNCTION TO SELECT SETTINGS OF FACTORY PRODUCTION
        { 
            Console.WriteLine(_label);
            string _input = Console.ReadLine();
            bool _validInput = int.TryParse(_input, out int _result);
            if (!_validInput)
            {
                SelectSettings(_label, _selectionMin, _selectionMax, _endMessage, _callback);
                return;
            }
            _result = _result < _selectionMin ? _selectionMin : _result > _selectionMax ? _selectionMax : _result;
            Console.WriteLine($"{_endMessage} [{_result}]");

            _callback?.Invoke(_result);

        }
    }   
}

