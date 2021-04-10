using System;
using System.Collections.Generic;
using System.Linq;

namespace AP2TP_SP4
{ 
    /*                                                                                                
        TODO: Pro danou zprávu vytvoř seznam symbolů a zjisti počet jejich výskytů (nebo pravděpodobnost).
        TODO: Seznam symbolů seřaď do neklesající posloupnosti podle této hodnoty.
        TODO: Kódy všech symbolů jsou zpočátku prázdné.
        TODO: Rozděl seznam na dvě poloviny tak, aby součet sledovaných hodnot byl v obou částech zhruba stejný.
        TODO: Ke kódům symbolů v levé polovině připoj 0, ke kódům symbolů v pravé polovině připoj 1.
        TODO: Rekurzivně opakuj od kroku 4 na levou i pravou polovinu seznamu.
    */
    
    internal static class Program
    {
        public static void Main(string[] args)
        {
            const string inputString = "This is a string";
            List<Symbol> symbols = new List<Symbol>();
            var symbolCount = 0;


            /* Create list of symbols from input text */
            foreach (var x in inputString)
            {
                symbolCount++;
                if (symbols.All(symbol => symbol.ReturnText() != x.ToString()))
                {
                    symbols.Add(new Symbol(x.ToString(), 1, double.NaN, "000"));
                }
                else
                {
                    var index = symbols.FindIndex(symbol => symbol.ReturnText() == x.ToString());
                    symbols[index].AddCount();
                }
            }
            
            /* Calculate probability for each symbol */
            foreach (var symbol in symbols)
            { 
                symbol.Probability = Math.Round(symbol.ReturnCount() / Convert.ToDouble(symbolCount) * 100, 3);
            }
            
            /* Order symbols by probability -> highest to lowest */
            symbols = symbols.OrderBy(x => x.Probability).Reverse().ToList();

            /* Print info about the symbols */
            foreach (var symbol in symbols)
                ReturnSymbolInfo(symbol);
            
            /*
                Divide symbols into two groups, take sum of both group's COUNT ( should be similar ),
                left group  -> add "0" to CODE
                right group -> add "1" to CODE
             */
            /*
            var bestDifference = int.MaxValue;
            for(var i = 1; i < symbolCount; i++)
            {
                var firstPart = symbols.Take(i);
                var secondPart = symbols.Skip(i);
                firstPart = firstPart.ToList();
                secondPart = secondPart.ToList();
                var firstPartCount = firstPart.Sum(symbol => symbol.ReturnCount());
                var secondPartCount = secondPart.Sum(symbol => symbol.ReturnCount());


                var difference = Math.Abs(firstPartCount - secondPartCount);
                if (difference < bestDifference)
                    bestDifference = difference;
                else break;
            }
            Console.WriteLine($"Best Difference -> {bestDifference}");
            */


            /* Methods here */

            


        }
        private static void ReturnSymbolInfo(Symbol symbol) =>
            Console.WriteLine( $"Symbol {symbol.ReturnText()} -> " +
                               $"Count: {symbol.ReturnCount()}, " +
                               $"Probability: {symbol.ReturnProbability()}%, " +
                               $"Code: {symbol.ReturnCode()}" );

        private static (IEnumerable<Symbol>, IEnumerable<Symbol>) Coding (List<Symbol>symbols, int symbolCount)
        {
            var bestDifference = int.MaxValue;
            for(var i = 1; i < symbolCount; i++)
            {
                var firstPart = symbols.Take(i);
                var secondPart = symbols.Skip(i);
                firstPart = firstPart.ToList();
                secondPart = secondPart.ToList();
                var firstPartCount = firstPart.Sum(symbol => symbol.ReturnCount());
                var secondPartCount = secondPart.Sum(symbol => symbol.ReturnCount());


                var difference = Math.Abs(firstPartCount - secondPartCount);
                if (difference < bestDifference)
                    bestDifference = difference;
                else
                {
                    return (firstPart, secondPart);
                }
            }

            return (symbols, symbols);

        }
    }
}