using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCorrectionInheritance
{
    public class AirplaneFactory : Factory
    {
        public struct TempPlaneModel                                        // STRUCT IS A DATA CONTAINER GET/SET/UPDATE but no other logic
        {
            public VehicleColor Color;
            public int Engines;
            public int Passengers;
        }

        TempPlaneModel tempPlane = new TempPlaneModel();
        protected override Vehicle CreateVehicle()
        {
            throw new NotImplementedException();
        }
    }
}
