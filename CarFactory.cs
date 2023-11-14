using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCorrectionInheritance
{
    public class CarFactory : Factory
    {
        public struct TemplateCarModel
        { 
            public VehicleColor Color;
            public int Passengers;
        }
        TemplateCarModel carTemplate = new TemplateCarModel();

        public override event Action OnStartProduction = null;   // Declaring event    
        public override event Action OnEndProduction = null;
        public override event Action<Vehicle> OnVehicleProduced = null;

        #region Constructor
        public CarFactory()
        {
            OnStartProduction += SelectColor;
            OnColorSelected += (color) =>
            {
                carTemplate.Color = color;
                SelectSettings
                ($"Select the number of passengers : [{Car.MIN_PASSENGERS} - {Car.MAX_PASSENGERS}]",
                Car.MIN_PASSENGERS,Car.MAX_PASSENGERS,"Produced a new car",(passengers) => carTemplate.Passengers = passengers
                );


            };
            carTemplate.Color = new VehicleColor();


        
        }
        #endregion Constructor
        #region Methods

        public override void StartProduction()
        {
            base.StartProduction();
        }

        protected override Vehicle CreateVehicle()
        {
            OnStartProduction?.Invoke();
            Car _car = new Car(carTemplate);
            allVehicles.Add(_car);
            OnVehicleProduced?.Invoke(_car);
            OnEndProduction?.Invoke();
            return _car;
        }
        #endregion Methods

    }
}
