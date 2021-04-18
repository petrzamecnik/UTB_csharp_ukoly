using System;

/*  1) Co je to lamda expression?
    ( input ) => expression;
    lambda expression má na levé straně od lambda operátoru vstup,
    na právé straně má nějaký výraz, a vrací výsledek výrazu

    2) Co je to statement lambda?
    ( input ) => { statement1, statement2, .. }
    lambda statement má na levé straně od lambda operátoru vstup,
    na pravé straně má většínou v závorkách, jeden, dva, někdy i více "statementů" ... rip čeština :)
    
 */

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 vyuziti lambda expression
            Func<int, int> vypocetObsahuCtverce = a => a * a;
            Console.WriteLine($"Obsah ctverce: {vypocetObsahuCtverce(4)}");
            
            // 2 vyuziti lambda statement
            Func<int, int, bool> vypisVetsiCislo = (a, b) =>
            {
                if (a > b)
                {
                    Console.WriteLine("prvni cislo je vetsi");
                    return true;
                }
                Console.WriteLine("druhe cislo je vetsi");
                return false;
            };
            vypisVetsiCislo(20, 15);
        }
    }
}