using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCorrectionInheritance
{

public class Factory
    {
        #region fieldsAndProperties

        public event Action OnStartProduction = null;   // Declaring event
        public event Action OnEndProduction = null;   
        public event Action OnVehicleProduced = null;

        #endregion fieldsAndProperties
        #region Constructor

        #endregion Constructor
        #region Methods
        virtual public void Create()
        {
            Console.WriteLine("Created a :");
        }

        #endregion Methods

    }
}

