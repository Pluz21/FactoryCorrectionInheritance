using System;
using System.Security.Cryptography.X509Certificates;
using FactoryCorrectionInheritance;

class Program
{

    static void Main(string[] args)
    { 
        Airplane airplane = new Airplane(VehicleColor.Red, 4, 233); 
        Console.WriteLine( airplane );
        AirplaneFactory factory = new AirplaneFactory();
    
    
    }

}