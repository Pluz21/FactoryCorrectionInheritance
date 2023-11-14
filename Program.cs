using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FactoryCorrectionInheritance;

class Program
{

    static void Main(string[] args)
    { 
     
        AirplaneFactory _airplaneFact = new AirplaneFactory();                  // Calling the factories
        CarFactory _carFact = new CarFactory();         
        List<Factory> allFactories = new List<Factory>();                      // Calling our factory list

        allFactories.Add(_airplaneFact);                                        // adding our two factories to the factory list
        allFactories.Add(_carFact);
        FactoryMenu myFactoryMenu = new FactoryMenu(allFactories);             // Calling the Factory Menu 
        Console.Read();
        
    
    }

}