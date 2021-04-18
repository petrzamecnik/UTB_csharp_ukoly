using System;

/*  1) Co je to delegát?
    Delegát je typ reprezentující referenci na metodu s určitým vstupním a výstupním parametrem,
    někdy avšak nemusí mít výstupní parametr, například delegát Action<>

    2) Co jsou to delegáti Func a Action a k čemu se používají?
    Func<> - delegát který se používá pro funkci se vstupním i výstupním parametrem
    Action<> - se používá pro fuknci bez výstupního parametru, tedy void
     
    3) Co je to event?
    u eventu nelze volat událost mimo třídu
    např. public event Action<>
    
    

 */

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Action<double> magicAction = i => Console.WriteLine($"Vysledek je: {i}");
            Func<double, double, double> sum = (a, b) => a + b;

            Console.WriteLine($"Soucet: {sum(10, 15)}");
            magicAction(sum(20, 20));


        }
    }
}