using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCorrectionInheritance
{
    public class AirplaneFactory : Factory
    {
        public struct TemplatePlaneModel                                        // STRUCT IS A DATA CONTAINER GET/SET/UPDATE but no other logic
        {
            public VehicleColor Color;
            public int Engines;
            public int Passengers;
        }

        TemplatePlaneModel templatePlane = new TemplatePlaneModel();

        public override event Action OnStartProduction = null;              // Overriding abstract event, we do this as a more secure delegate 
        public override event Action OnEndProduction = null;
        public override event Action<Vehicle> OnVehicleProduced = null;

        #region Constructor
        public AirplaneFactory()
        
        {
            OnStartProduction += SelectColor;
            OnColorSelected += (color) => 
            {
                templatePlane.Color = color;
                SelectSettings
                 (
                    $"Select the number of engines : [{Airplane.MIN_ENGINES} - {Airplane.MAX_ENGINES}]",
                    Airplane.MIN_ENGINES, Airplane.MAX_ENGINES,
                    "Number of engines", (engines) => templatePlane.Engines = engines

                 );
                SelectSettings
                (
                    $"Select the number of passengers : [{Airplane.MIN_PASSENGERS} - {Airplane.MAX_PASSENGERS}]",
                    Airplane.MIN_PASSENGERS, Airplane.MAX_PASSENGERS,
                    "Number of engines", (passengers) => templatePlane.Passengers = passengers

                 ); // TESTING OUT IF MAC WORKS
                 // merging branch test from VScode mac 
                
            };

            templatePlane.Color = new VehicleColor();
        }
        #endregion Constructor
        #region Methods

        public override void StartProduction()
        {
            base.StartProduction();                                                 // EXAMPLE OF OVERRIDING A NON-ABSTRACT FUNCTION this one calls CreateVehicle()
        }
        protected override Vehicle CreateVehicle()
        {
            OnStartProduction?.Invoke();                                         // This is the broadcast, the ? is an ISVALID checker. If this class gets destroyed for example
            Airplane _plane = new Airplane(templatePlane);                      // Sending the template inside the constructor
            allVehicles.Add(_plane);
            OnVehicleProduced?.Invoke(_plane);// Adding to our list of vehicles --> Check Factory for the abstract function            
            OnEndProduction.Invoke();
            return _plane;
            }
            
        }
        #endregion Methods
    }

