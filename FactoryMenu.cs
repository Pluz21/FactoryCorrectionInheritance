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
        int currentFactoryIndex = 0;
        List<Factory> allFactories = new List<Factory>();
        #region Constructor
        public FactoryMenu(Factory _factory)
        {
            currentFactory = _factory;
            //currentFactory = _factory;
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

            selection.Add(new FactoryMenuSelection("Create new airplane", currentFactory.StartProduction));
            selection.Add(new FactoryMenuSelection("Create new car", currentFactory.StartProduction));

            selection.Add(new FactoryMenuSelection("List all produced vehicles", currentFactory.DisplayStock));
            ShowMenu();


        }
        public FactoryMenu(List<Factory> _allFactories)
        {
            allFactories = _allFactories;
            currentFactory = allFactories.Count > 0 ? allFactories[currentFactoryIndex] : null;   // looking for first valid factory
            if (currentFactory == null) return;
            
            currentFactory.OnEndProduction += ResetMenu;  
            currentFactory.OnEndProduction -= ResetMenu;

            selection.Add(new FactoryMenuSelection("Create new airplane", currentFactory.StartProduction));
            selection.Add(new FactoryMenuSelection("List all produced vehicles", currentFactory.DisplayStock));
            selection.Add(new FactoryMenuSelection("Change to next factory", SwitchCurrentFactory));

            ShowMenu();


        }

        #endregion Constructor
        #region Methods
        void ShowMenu()
        {
            
            Console.Clear();
            Console.WriteLine($"Current Factory {currentFactory.GetType()}");
            int _selectionCount = selection.Count;
            for (int i = 0; i < _selectionCount; i++)
            {
                Console.WriteLine($"{i + 1} - {selection[i].Label}");                               // 
            }
            Select();
        }
        void Select()

        {
            string _input = Console.ReadLine();                                         // Waiting for user input 
            bool _validInput = int.TryParse(_input, out int _result);                   
            if (!_validInput)
            {
                Console.WriteLine("Invalid entry, retry");
                ShowMenu();
                return;
            }
            _result = _result < 1 ? 1 : _result > selection.Count ? selection.Count : _result;
            selection[_result - 1].Execute();

        }

        void SwitchCurrentFactory()
        {
            UnsubscribeEvents();
            currentFactoryIndex = currentFactoryIndex + 1 >= allFactories.Count ? 0 : currentFactoryIndex + 1;
            currentFactory = allFactories[currentFactoryIndex];
            UpdateSelection();
            SubscribeEvents();
            Console.Clear();
            ShowMenu();

        }

        void SubscribeEvents()
        {
            currentFactory.OnEndProduction += ResetMenu;
            currentFactory.OnVehicleStockDisplayed += ResetMenu;
        }

        void UnsubscribeEvents()
        {
            currentFactory.OnEndProduction -= ResetMenu;
            currentFactory.OnVehicleStockDisplayed -= ResetMenu;

        }
        void ResetMenu()
        {
            Console.ReadLine();
            Console.Clear();
            ShowMenu();
        }
        void ClearSelection()
        { 
            selection.Clear();
        }
        void UpdateSelection()
        {
            ClearSelection();
            selection.Add(new FactoryMenuSelection("Create new airplane", currentFactory.StartProduction));
            selection.Add(new FactoryMenuSelection("List all produced vehicles", currentFactory.DisplayStock));
            selection.Add(new FactoryMenuSelection("Change to next factory", SwitchCurrentFactory));

        }
            #endregion Methods
    }   
}

