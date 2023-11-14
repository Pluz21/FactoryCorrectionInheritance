using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCorrectionInheritance
{
    public class FactoryMenuSelection
    {
        public string Label {get; private set;  } = "Label";
        Action callback = null;

        public FactoryMenuSelection(string _label, Action _callback)
        { 
            Label = _label;
            callback = _callback;   
        }
        public void Execute() => callback?.Invoke();

    }
}
