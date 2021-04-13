using System;
using System.Collections.Generic;
using hrdina_a_drak.Postavy;
using hrdina_a_drak.Veci;

namespace hrdina_a_drak
{
    public class TextNav
    {
        // ReSharper disable once InconsistentNaming
        private static readonly TextNav instance = new TextNav();

        public static TextNav Instance()
        {
            return instance;
        }

        public static int VyberAkce()
        {

            Console.WriteLine("------------------------------");
            Console.WriteLine("Vyber akci kterou chceš provést: ");
            Console.Write(
                "1 -> BOJ\n" +
                "2 -> Zobrazit monstra\n" +
                "3 -> Vypsat informace o hrdinovi\n" +
                "4 -> Zobrazit inventář\n" +
                "5 -> Vybrat vybavení\n" +
                "6 -> Vypis vybaveni hrdiny\n" +
                "7 -> Porovnat hrdinu - monstrum\n"
            );
            Console.Write("Výběr akce: ");
            var vyberAkce = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            return vyberAkce;
        }

        public static void VypisDostupnaMonstra(List<Monstrum> monstra)
        {
            Console.WriteLine("******************************");
            Console.WriteLine("V aréně jsou dostupná tato monstra: ");
            for (var i = 0; i < monstra.Count; i++)
            {
                Console.WriteLine("--> Monstrum číslo " + (i + 1)  + ": "+ monstra[i].VratJmeno());
            }
            Console.WriteLine("******************************");
        }
        
        public static void VolbaPredmetu(Hrdina hrdina)
        {
            // vypíše předměty v inventáři s přiřazeným číslem
            VypisObsahInventare(hrdina);
            
            // uživatel zadá číslo ( index ) předmětu který chce nasadit
            var indexPredmetu = Convert.ToInt32(Console.ReadLine());
            if (indexPredmetu > hrdina.Inventar.Count)
            {
                Console.WriteLine("Neplatná volba!");
                TextNav.VyberAkce();
            }
            else if (indexPredmetu < 0)
            {
                Console.WriteLine("Neplatná volba!");
                TextNav.VyberAkce();
            }
            else
            {
                Console.WriteLine("Neplatná volba!");
            }
            
            // nasazení předmětu
            hrdina.NasadPredmet(hrdina.Inventar[indexPredmetu - 1]);
        }

        public static void PorovnaniMonstraAHrdiny(Hrdina hrdina, List<Monstrum> monstra)
        {
            Console.WriteLine("V arene jsou dostupná tato monstra: ");
            for (var i = 0; i < monstra.Count; i++)
            {
                Console.WriteLine("--> Monstrum číslo " + (i + 1)  + ": "+ monstra[i].VratJmeno());
            }

            Console.WriteLine("Vyber monstrum které chces porovnat: ");
            var indexMonstra = Convert.ToInt32(Console.ReadLine());

            Monstrum monstrum = monstra[indexMonstra - 1];

            Console.WriteLine($"Zivoty hrdiny: {hrdina.VratPocetZivotu()} <---> Zivoty monstra: {monstrum.VratPocetZivotu()}");
            Console.WriteLine($"Utok hrdiny: {hrdina.VratUtok()} <---> Utok monstra: {monstrum.VratUtok()}");
            Console.WriteLine($"Obrana hrdiny: {hrdina.VratObranu()} <---> Obrana monstra: {monstrum.VratObranu()}");
        }
        
        public static void VypisInformaceOHrdinovi(Hrdina hrdina)
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Životy --> " + hrdina.VratPocetZivotu());
            Console.WriteLine("Maximální životy --> " + hrdina.VratMaximalniPocetZivotu());
            Console.WriteLine("Úroveň --> " + hrdina.VratLevel());
            Console.WriteLine("Utok   --> " + Convert.ToInt32(hrdina.VratUtok() + Mec.VratBonusovePoskozeni()));
            Console.WriteLine("Obrana --> " + Convert.ToInt32(hrdina.VratObranu() 
                                                                        + Helma.VratBonusovouObranu()
                                                                        + Brneni.VratBonusovouObranu()
                                                                        + Stit.VratBonusovouObranu()));
            Console.WriteLine("******************************");
        }

        public static void VypisObsahInventare(Hrdina hrdina)
        {
            Console.WriteLine("******************************");

            if (hrdina.Inventar.Count > 0)
            {
                int i = 1;
                foreach (var vec in hrdina.Inventar)
                {
                    
                    
                    Console.WriteLine(i + ". --> " + vec.VratNazevVeci());
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Hrdina nemá v inventáři žádnou věc.");
            }
            Console.WriteLine("******************************");
        }
    }
}