using System;


/* ZADÁNÍ
 
Vytvořte krátké odpovědi k následujícím otázkám, ke každé vytvořte stručnou ukázku, jinou než v prezentaci nebo přípravě k testu.

1) Co jsou to virtuální metody a kdy se používají?

2) Co jsou to abstraktní metody a třídy a kdy se používají?

3) Co nemůžeme dělat s abstraktní třídou?

4) Co je to rozhraní a jaký je rozdíl mezi rozhraním a abstraktní třídou? 
*/

namespace Ukoly
{
    class Program
    {
        static void Main(string[] args)
        {
            
            /* 1 - Virtuální metodu můžu využít když chci mít možnost ji "přepsat" jinou metodou pomocí override
                */
            var potvora = new Potvora();
            potvora.Stari();

            var drak = new Drak();
            drak.Stari();
            
            
            
            /* 2 - Abstraktní metody a třídy jsou v podstatě "prázdné", složí pro to, aby se z nich dědilo.
               Nemají tělo, ani implementaci. 
               
               Dá se použít například tam, kde nedokážeme nějakou metodu správně implementovat, jelikož je využitelná 
               až pro nějaký child, ale zároveň chceme mít možnost ji dědit 
               
               3 - Nemůžeme vytvářet instance abstraktní třídy
               */
            var dobrman = new Dobrman();
            dobrman.Plemeno();
            
            

            /* 3
            Tady se pokouším vytvořit instanci abstraktní třídy, což ale podle očekávání nebude fungovat.
        
            var pes = new Pes();
                */
            
            
            
            /* 4 - Interface nám slouží především proto, aby nám v kódu "hlídala" správné volání metod, například že
               nemůžu volat metodu "Let()" na třídu "Potvora", jelikož taková metoda tam není definována 
               
               Rozdíly mezi Interface ... Abstraktní třídou
               1 - Interface nemá konstruktor ... Abstraktní třída konstruktor má
               2 - Interface je vždy public   ... Abstaktní třída může být jak public, tak private, nebo protected atd.
               3 - Interface může obsahovat jenom metody ... Abstraktní třída může obsahovat metody, field, proměnné atd. 
               4 - Interface je pomalejší, jelikož musí nejprve vyhledat správné metody v odpovídajících třídách, 
                   a abstraktní třída nic vyhledávat nemusí -> proto je rychlejší
               */
            var letadlo = new Letadlo();
            var ptak = new Ptak();
            var ryba = new Potvora();

            static void Let(IUmiLitat neco)
            {
                neco.Let();
            }
            
            Let(letadlo);
            Let(ptak);

            /* Zde zkouším zavolat "Let" na rybu, což je instance Potovry, tohle ale nepujde,
               jelikož Potvora neumí lítat -> chybí zde metoda pro lítání
            
            Let(ryba);
                */
        }
    }

    // 1
    class Potvora
    {
        public virtual void Stari()
        {
            Console.WriteLine("Potvora nemá určené stáří");
        }
    }

    class Drak : Potvora
    {
        public override void Stari()
        {
            Console.WriteLine("Drak je starý 200 let");
        }
    }


    // 2, 3
    abstract class Pes
    {
        public abstract void Plemeno();
    }

    class Dobrman : Pes
    {
        public override void Plemeno()
        {
            Console.WriteLine("Jsem dobrman.");
        }
    }
    
    // 4
    interface IUmiLitat
    {
        void Let();
    }

    class Ptak : IUmiLitat
    {
        public void Let()
        {
            Console.WriteLine("Ptak umí lítat");
        }
    }

    class Letadlo : IUmiLitat
    {
        public void Let()
        {
            Console.WriteLine("Letadlo umí lítat");
        }
    }
}