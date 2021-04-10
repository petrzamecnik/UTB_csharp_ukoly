
/*  Vytvořte krátké odpovědi k následujícím úkolům a ke každé odpovědi vytvořte stručnou ukázku kódu:
    1) Co jsou to statické členské prvky?
    2) Co je to návrhový vzor Singleton, jaké jsou jeho výhody a nevýhody a k čemu se používá?
    
    1)  prvky static můžeme použít například pro třídu, metodu, lambda výrazy atp., v podstatě říká,
        že například daná metoda nepotřebuje instanci

    2)  Singleton můžeme použít pro znemožnění vytvóřet více instancí, když je to potřeba,
        což bych považoval za výhodu. Co se týče nevýod tak mě napadá například složitější testování,
        a že se v praxi nevyužívá moc často.

*/

using System;
using System.Runtime.CompilerServices;

namespace static_a_singleton
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            // 1) Nestatickou metodu "UdelejNeco()" můžu bez problému zavolat

            var uzivatel = new Uzivatel(1, "Martin", 22);
            Uzivatel.VypisInformace();
            uzivatel.UdelejNeco();
            Uzivatel.VypisInformace();

            // 1) Tady se snažím volat statickou metodu, ale to nebude fungovat, jelikož nepracujeme ve statickém kontextu
            // uzivatel.ZvysVek(); <-- hodí chybu

            // Statické metody však jdou volat, pokud se odkážeme přímo na třídu jako takovou, a né na instanci třídy,
            // to znamená že není problém zavolat funkci "VypisInformace()"
            
            
            // 2) Singleton
            // zde zkouším vytvořit instanci, ale to nejde jelikož se jendá o singleton
            // var hrdina = new JedinecnyANejlepsiHrdina("Jarda", 100, 20); <-- hodí chybu
            
            // instanci jde vytvořit pouze zavoláním metody, která nám vytvoří instanci,
            // jelikož se jedná o singleton tak může být pouze jedna
            var hrdina = JedinecnyANejlepsiHrdina.Instance();
            hrdina.VypisInformaceOHrdinovi();
            


        }

        class Uzivatel
        {
            private static int Id { get; set; }
            private static string Jmeno { get; set; }
            private static int Vek { get; set; }

            public Uzivatel(int id, string jmeno, int vek)
            {
                Id = id;
                Jmeno = jmeno;
                Vek = vek;
            }


            public static void VypisInformace()
            {
                Console.WriteLine($"Id uzivatele: {Id}");
                Console.WriteLine($"Jmeno uzivatele: {Jmeno}");
                Console.WriteLine($"Vek uzivatele: {Vek}");
            }

            private static void ZvysVek()
            {
                Vek++;
            }

            public void UdelejNeco()
            {
                ZvysVek();
            }
        }

        class JedinecnyANejlepsiHrdina
        {
            private static JedinecnyANejlepsiHrdina instance = new JedinecnyANejlepsiHrdina("Martin", 100, 20);
            private string Jmeno { get; set; }
            private int Zivoty { get; set; }
            private int Utok { get; set; }

            private JedinecnyANejlepsiHrdina(string jmeno, int zivoty, int utok)
            {
                Jmeno = jmeno;
                Zivoty = zivoty;
                Utok = utok;
            }

            public static JedinecnyANejlepsiHrdina Instance()
            {
                return instance;
            }

            public void VypisInformaceOHrdinovi()
            {
                Console.WriteLine($"Jmeno: {Jmeno}\n" +
                                  $"Zivoty: {Zivoty}\n" +
                                  $"Utok: {Utok}");
            }
        }
    }
}