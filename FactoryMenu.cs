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
            currentFactory.OnEndProduction += Console.Clear;
            currentFactory.OnEndProduction -= ShowMenu;

            currentFactory.OnEndProduction += () =>                         // LAMBA PHANTOM FUNCTION taking parameters within () 
                                                                            // lamba function is created on the fly 
            {
                Console.Clear();
                ShowMenu();
            };

            currentFactory.OnVehicleStockDisplayed += () =>
            {
                Console.ReadLine();
                Console.Clear();
                ShowMenu();
            };

            selection.Add(new FactoryMenuSelection("Create new vehicle", currentFactory.StartProduction));
            selection.Add(new FactoryMenuSelection("List all produced vehicles", currentFactory.DisplayStock));
            ShowMenu();


        }

        #endregion Constructor
        #region Methods
        void ShowMenu()
        {
            Console.Clear();
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
