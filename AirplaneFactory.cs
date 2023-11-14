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
        public override event Action OnVehicleProduced = null;

        public override void StartProduction()
        {
            base.StartProduction();                                                 // EXAMPLE OF OVERRIDING A NON-ABSTRACT FUNCTION this one calls CreateVehicle()
        }
        protected override Vehicle CreateVehicle()
        {
            OnStartProduction?.Invoke();                                         // This is the broadcast, the ? is an ISVALID checker. If this class gets destroyed for example
            Airplane _plane = new Airplane(templatePlane);                      // Sending the template inside the constructor
            allVehicles.Add(_plane);                                           // Adding to our list of vehicles --> Check Factory for the abstract function            
            OnEndProduction.Invoke();
            return _plane;
            }
            
        }
    }

