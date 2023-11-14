using System;
using System.Security.Cryptography.X509Certificates;
using FactoryCorrectionInheritance;

class Program
{

    static void Main(string[] args)
    { 
     
        AirplaneFactory _airplaneFact = new AirplaneFactory();
        CarFactory _carFact = new CarFactory();
        FactoryMenu airplaneFactoryMenu = new FactoryMenu(_airplaneFact);
        FactoryMenu carFactoryMenu = new FactoryMenu(_carFact);
        
    
    }

}