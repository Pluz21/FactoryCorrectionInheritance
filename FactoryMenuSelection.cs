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
        public string Label {get; private set;  } = "Label";                // Creating a label we can use in the FactoryMenu 
        Action callback = null;                                             // Action is a CSharp variable type we can use 
        #region Constructor
        public FactoryMenuSelection(string _label, Action _callback) 
        { 
            Label = _label;
            callback = _callback;   
        }
        #endregion Constructor
        public void Execute() => callback?.Invoke();                            // Broadcasting the action 
                                                                                // DIFFERENT SYNTAX : 
                                                                                //public void Execute()
                                                                                //{
                                                                                //callback?.Invoke()
                                                                                //};

    }
}
