using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using hrdina_a_drak.Postavy;
using hrdina_a_drak.Veci;



namespace hrdina_a_drak
{
    internal static class 
        Program
    {

        public static void Main(string[] args)
        {
            

            // TODO upravit citelnost kodu a zjednodusit kod do metod
            // TODO přidat fíčuru kdy monstra můžou utéct
            // TODO automaticka generace monster - vylepsit

            // ReSharper disable once JoinDeclarationAndInitializer
            int vyberAkce;
            // ReSharper disable once TooWideLocalVariableScope
            int vyberMonstra;
            var rand = new Random();

            // Vytvoreni veci
            // placeholdery
            var prazdnaHelma = new Helma("Bez helmy", 0);
            var prazdneBrneni = new Brneni("Bez brneni", 0);
            var prazdnyMec = new Mec("Bez mece", 0);
            var prazdnyStit = new Stit("Bez stitu", 0);
            
            // helmy
            var kozenaHelma = new Helma("Kozena helma", 5);
            var bronzovaHelma = new Helma("Bronzova helma", 10);
            var zeleznaHelma = new Helma("Zelezna helma", 15);
            
            // brneni
            var kozeneBrneni = new Brneni("Kozene brneni", 10);
            var bronzoveBrneni = new Brneni("Bronzove brneni", 20);
            var zelezneBrneni = new Brneni("Zelezne brneni", 30);
            
            // mece
            var drevenyMec = new Mec("Dreveny mec", 10);
            var bronzovyMec = new Mec("Bronzovy mec", 20);
            var zeleznyMec = new Mec("Dreveny mec", 30);
            var Apokalypsa = new Mec("Apokalypsa", 100);
            
            // stity
            var drevenyStit = new Stit("Dreveny stit", 10);
            var bronzovyStit = new Stit("Bronzovy stit", 30);
            var zeleznyStit = new Stit("Zelezny stit", 50);
            
            // vytvoření hrdiny
            // var hrdina = new Hrdina("Maarijo", 1, 100, 20, 10, true, new List<Vec>());


            var hrdina = new Hrdina("Maarijo", 1, 200, 30, 15, true,
                new List<Vec>(), prazdnaHelma, prazdneBrneni, prazdnyMec, prazdnyStit, 200);


            vytvoreniSkupinyMonster:
            var monstra = VytvorSkupinuMonster(hrdina, rand);


            var veciLevel1_5 = new List<Vec>
            {
                kozenaHelma, kozeneBrneni, drevenyMec, drevenyStit
            };
            
            var veciLevel6_15 = new List<Vec>
            {
                bronzovaHelma, zeleznaHelma,
                bronzoveBrneni, zelezneBrneni,
                bronzovyMec, zeleznyMec,
                bronzovyStit, zeleznyStit
            };

            // přidání věcí k monstrum
            
            monstra[0].SeznamVeci.Add(drevenyStit);
            monstra[1].SeznamVeci.Add(kozenaHelma);
            monstra[2].SeznamVeci.Add(kozeneBrneni);
            monstra[3].SeznamVeci.Add(drevenyMec);
            
            
            // Volba akce
            volbaAkce: 
            
            if (hrdina.JeNaZivu() && PocetMonster(monstra) == 0)
            {
                Console.WriteLine("Hrdina porazil všechna monstra a postupuje do obtížnější arény");
                goto vytvoreniSkupinyMonster;
            }
            
            vyberAkce = TextNav.VyberAkce();
            switch (vyberAkce)
            {
                case 1:
                    goto vyberBoje;
                
                case 2:
                    TextNav.VypisDostupnaMonstra(monstra);
                    goto volbaAkce;
                
                case 3: 
                    TextNav.VypisInformaceOHrdinovi(hrdina);
                    goto volbaAkce;
                
                case 4: 
                    TextNav.VypisObsahInventare(hrdina);
                    goto volbaAkce;
                    
                case 5:
                    TextNav.VolbaPredmetu(hrdina);
                    goto volbaAkce;
                    
                case 6:
                    Hrdina.VypisVybaveniHrdiny();
                    goto volbaAkce;
                    
                case 7:
                    TextNav.PorovnaniMonstraAHrdiny(hrdina, monstra);
                    goto volbaAkce;
            }
            
            // když žije aspoň jeden hrdina, a jedno monstrum, hráč si vybere monstrum se kterým chce bojovat
            vyberBoje:
            if (hrdina.JeNaZivu() && PocetMonster(monstra) > 0)
            {
                Console.WriteLine("V aréně jsou dostupná tato monstra: ");
                Console.WriteLine("--> 0: Vrátit se zpět");
                for (var i = 0; i < monstra.Count; i++)
                    Console.WriteLine("--> Monstrum číslo " + (i + 1)  + ": "+ monstra[i].VratJmeno());

                // ošetření vstupu??
                Console.WriteLine("Vyber si se kterým z monster chceš bojovat ( 1, 2, 3 ... ): ");
                
                vyberMonstra = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                
                if (vyberMonstra == 0)
                {
                    Console.WriteLine("Neplatna volba");
                    goto volbaAkce;
                }

                
                if (vyberMonstra > monstra.Count || vyberMonstra < 0)
                {
                    Console.WriteLine("Neplatna volba!!");
                    goto vyberBoje;
                }
                
                vyberMonstra -= 1;

                // začátek boje zde
                Boj(hrdina, monstra, vyberMonstra);

                if (hrdina.JeNaZivu())
                {
                    
                    ZiskaniPredmetu(monstra[vyberMonstra], hrdina);
                    monstra.RemoveAt(vyberMonstra);  // odstraní monstrum na dané pozici v poli monstra[]
                    goto volbaAkce;
                }

                if (hrdina.JeNaZivu() == false)
                {
                    Console.WriteLine("Hridna umřel.");
                    
                }
                
            }
            else if (hrdina.JeNaZivu() && PocetMonster(monstra) == 0)
            {
                Console.WriteLine("Hrdina porazil všechna monstra a postupuje do obtížnější arény");
                goto vytvoreniSkupinyMonster;
            }
        }

        // zde probíhá boj
        private static void Boj(Hrdina hrdina, IReadOnlyList<Monstrum> monstra, int vyberMonstra)
        {
            for (var i = 0; hrdina.JeNaZivu() && monstra[vyberMonstra].JeNaZivu(); i++)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Kolo: " + i);
                Console.WriteLine("Životy hrdiny: " + hrdina.VratPocetZivotu());
                Console.WriteLine("Životy monstra: " + monstra[vyberMonstra].VratPocetZivotu());

                if (hrdina.JeNaZivu())
                {
                    // TODO Opravit tuhle zvráceninu !!
                    hrdina.PridejBonusovePoskozeni();
                    hrdina.PridejBonusovouObranu();
                    hrdina.Utocit(monstra[vyberMonstra]);
                    hrdina.OdeberBonusovePoskozeni();
                    hrdina.OdeberBonusovouObranu();
                }

                else
                    Console.WriteLine("Hrdina zemřel!");

                if (monstra[vyberMonstra].JeNaZivu())
                {
                    // TODO Opravit tuhle zvráceninu !!
                    hrdina.PridejBonusovePoskozeni();
                    hrdina.PridejBonusovouObranu();
                    monstra[vyberMonstra].Utocit(hrdina);
                    hrdina.OdeberBonusovePoskozeni();
                    hrdina.OdeberBonusovouObranu();
                }
                    
                else
                {
                    hrdina.ZvyseniLevelu();
                    hrdina.ObnovZivoty();
                        
                    Console.WriteLine("Monstrum zemřelo!");
                    Console.WriteLine("Hrdina si obnovil část životů!");
                        
                }
                    
                Console.WriteLine("------------------------------");
            }
        }

        // vrací pocet monster
        private static readonly Func<List<Monstrum>, int> PocetMonster =
            monstra => monstra.Count(monstrum => monstrum.JeHrdina() == false);
        
        private static void ZiskaniPredmetu(Monstrum monstrum, Hrdina hrdina)
        {
            var random = new Random();
            var indexVeci = random.Next(0, monstrum.SeznamVeci.Count);

            if (monstrum.SeznamVeci.Count == 0) return;
            // Console.WriteLine("Vyrbana vec: " + monstrum.SeznamVeci[indexVeci]);
            hrdina.Inventar.Add(monstrum.SeznamVeci[indexVeci]);
            Console.WriteLine("Hrdina obdržel: " + monstrum.SeznamVeci[indexVeci].VratNazevVeci() + "!");
        }
        

        // vrati jmeno monstra z file.txt
        private static List<string> VratJmenoNovehoMonstra()
        {
            var seznamMonster = "";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                seznamMonster = File.ReadAllText("/Users/petrzamecnik/RiderProjects/Ukoly/hrdina_a_drak/jmena_monster.txt");
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            { 
                seznamMonster = File.ReadAllText("C:\\Users\\petrz\\RiderProjects\\UTB\\hrdina_a_drak\\jmena_monster.txt");
            }
            var jmena = seznamMonster.Split(',').ToList();
            
            return jmena;
        }

        // tvorba monstra
        private static Monstrum VytvorNoveMonstrum(Hrdina hrdina, Random rand)
        {

            var jmena = VratJmenoNovehoMonstra();

            // zvolí jméno monstra
            var jmeno = jmena[rand.Next(1, jmena.Count)].Trim(); 
            // vrátí aktuální level hrdiny
            var levelHrdiny = hrdina.VratLevel();

            var level = 1 + levelHrdiny;
            var zivoty = 100 + (20 * levelHrdiny) * Convert.ToInt32(rand.Next(1,300 +1) / 100);
            var utok = 10 + (5 * levelHrdiny) * Convert.ToInt32(rand.Next(1, 300 + 1) / 100);
            var obrana = 5 + (5 * levelHrdiny) * Convert.ToInt32(rand.Next(1,300 +1) / 100);

            var monstrum = new Monstrum(jmeno, level, zivoty, utok, obrana, false, new List<Vec>());
            return monstrum;
        }

        // tvorba skupiny monster
        private static List<Monstrum> VytvorSkupinuMonster(Hrdina hrdina, Random rand)
        {
            var monstrum0 = VytvorNoveMonstrum(hrdina, rand);
            var monstrum1 = VytvorNoveMonstrum(hrdina, rand);
            var monstrum2 = VytvorNoveMonstrum(hrdina, rand);
            var monstrum3 = VytvorNoveMonstrum(hrdina, rand);
            var monstrum4 = VytvorNoveMonstrum(hrdina, rand);
            var monstrum5 = VytvorNoveMonstrum(hrdina, rand);
            
            var monstra = new List<Monstrum>
            {
                monstrum0,
                monstrum1,
                monstrum2,
                monstrum3,
                monstrum4,
                monstrum5
            };
            
            return monstra;
        }
    }
}