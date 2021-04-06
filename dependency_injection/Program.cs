using System;
using System.IO;


/*
 Vytvořte krátké odpovědi k následujícím úkolům.

1) Co je to Dependency injection a k čemu se používá?

2) Vytvořte stručnou ukázku Dependency Injection. */

/* 1 - Dependency injection je vzor návrhu softwaru, který má umožnit upravit propojení mezi metodami, funkcemi,
       třídami a tak podobně. Díky použití DI můžeme docílit lépe čitelného, zjednodušit budoucí úpravu kódu, testování atd..
       V podstatě se zde nevytvoří instance třídy hned, ale pomocí rozhraní ji můžeme předat až za běhu v podobě konstruktoru */


namespace dependency_injection
{
    static class Program
    {
        static void Main(string[] args)
        {
            /* 2 - DI používám u logování, na které odkazuji pomocí Interface ILogger.
                   Mám na výběr ze třech způsobů logování a mezi němi můžu jednoduše vybírat podle toho,
                   který logger předám při vytváření nového zaméstnance, teda například 'Logger1()' nebo 'Logger2()' ...
                   
                   */
            
            var zamestnanec1 = new Zamestnanec(1, "David", new Logger1());
            var zamestnanec2 = new Zamestnanec(2, "Jaromír", new Logger2());
            var zamestnanec3 = new Zamestnanec(3, "Karel", new Logger3());

            Console.WriteLine("Vyčistit log? A / N");
            var op = Console.ReadKey().KeyChar;
            if (char.ToUpper(op) == 'A')
                ClearLog();
        }

        private static void ClearLog()
        {
            File.WriteAllText("C:\\Users\\petrz\\RiderProjects\\Ukoly\\dependency_injection\\log.txt",
                string.Empty);
        }
    }
    
    public class Zamestnanec
    {
        private int Id { get; set; }
        private string Jmeno { get; set; }

        public Zamestnanec(int id, string jmeno, ILogger logger)
        {
            Id = id;
            Jmeno = jmeno;
            logger.ZapisLog("Nový zaměstnanec byl úspěšně vytvořen.");
        }
    }

    public interface ILogger
    {
        void ZapisLog(string text);
    }

    public class Logger1 : ILogger
    {
        public void ZapisLog(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }
    }

    public class Logger2 : ILogger
    {
        public void ZapisLog(string text)
        {
            File.AppendAllText("C:\\Users\\petrz\\RiderProjects\\Ukoly\\dependency_injection\\log.txt",
                $"{DateTime.Now} --> {text} {Environment.NewLine}");
        }
    }
    
    public class Logger3 : ILogger
    {
        public void ZapisLog(string text)
        {
            System.Diagnostics.Debug.WriteLine($"{DateTime.Now} --> {text}");
        }
    }
}
