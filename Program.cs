using System;
using System.Security.Cryptography.X509Certificates;
using FactoryCorrectionInheritance;

class Program
{

    static void Main(string[] args)
    { 
     
        AirplaneFactory _fact = new AirplaneFactory();
        FactoryMenu menyFactory = new FactoryMenu(_fact);
    
    
    }

}