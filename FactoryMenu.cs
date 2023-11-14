using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCorrectionInheritance
{
    public class FactoryMenu
    {
        List<FactoryMenuSelection> selection = new List<FactoryMenuSelection>();               // We have to initialize our list of FactoryMenuSelection
        Factory currentFactory = null;

        #region Constructor
        public FactoryMenu(Factory _factory) 
        {   
        currentFactory = _factory;
            //TODO abo menu + factory 
        }

        #endregion Constructor
        #region Methods
        void ShowMenu()
        {
            int _selectionCount = selection.Count;
            for (int i = 0; i < _selectionCount; i++) 
            {
                Console.WriteLine($"{i + 1} - {selection[i].Label}");                               // 
            }
            Select();
        }
        void Select() 
        
        {
        string _input = Console.ReadLine();
        bool _validInput = int.TryParse(_input, out int _result);
            if (!_validInput) 
            {
                Console.WriteLine("Invalid entry, retry");                
                Select();
                return;
            }
        _result = _result < 1 ? 1 : _result > selection.Count ? selection.Count : _result;
         selection[_result-1].Execute();

        }

        #endregion Methods
    }
}
