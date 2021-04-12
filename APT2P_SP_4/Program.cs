using System;
using System.Collections.Generic;
using System.Linq;

namespace APT2P_SP_4
{
    internal class Program
    {

        class Symbol
        {
            public string Text { get; set; }
            public int Count { get; set; }
            public double Probability { get; set; }
            public string Code { get; set; }

            public Symbol(string text, int count, double probability, string code)
            {
                Text = text;
                Count = count;
                Probability = probability;
                Code = code;
            }

            public string ReturnText()
            {
                return Text;
            }
            public int ReturnCount()
            {
                return Count;
            }
            public double ReturnProbability()
            {
                return Probability;
            }
            public string ReturnCode()
            {
                return Code;
            }
            public void AddCount()
            {
                Count++;
            }
            
            
            
        }
        
        public static void Main(string[] args)
        {
            const string inputString = "This is a test string";
            var outputString = "";
            var symbols = new List<Symbol>();

            // make list of symbols from input string
            foreach (var x in inputString)
            {
                if (symbols.All(symbol => symbol.ReturnText() != x.ToString()))
                {
                    symbols.Add(new Symbol(x.ToString(), 1, double.NaN, ""));
                }
                else
                {
                    var index = symbols.FindIndex(symbol => symbol.ReturnText() == x.ToString());
                    symbols[index].AddCount();

                }
            }
            symbols = symbols.OrderBy(symbol => symbol.Count).Reverse().ToList();
            foreach (var symbol in symbols)
                ReturnSymbolInfo(symbol);



            // Count symbols
            var total = TotalCount(symbols);
            

            
            // Count probability of each symbol
            foreach(var symbol in symbols)
            {
                symbol.Probability = Math.Round(Convert.ToDouble(symbol.Count) / Convert.ToDouble(total) * 100, 3);
            }
  
            Coding(symbols, "", 0);

            Console.WriteLine(new string('-', 60));
            foreach (var x in inputString)
            {
                var index = symbols.FindIndex(symbol => symbol.ReturnText() == x.ToString());
                var symbolCode = symbols[index].ReturnCode();
                outputString += symbolCode;
            }

            foreach (var symbol in symbols)
            {
                ReturnSymbolInfo(symbol);
            }

            Console.WriteLine($"Output: {outputString}");
            Console.WriteLine($"Symbol count: {total}");
        }
        
        
        // METHODS HERE

        private static int TotalCount(IEnumerable<Symbol> symbols) =>
            symbols.Aggregate(0, (a, s) => a + s.Count);

        private static void Coding(IEnumerable<Symbol> symbols_, string str, int depth)
        {
            var enumerable = symbols_ as Symbol[] ?? symbols_.ToArray();
            if (enumerable.Count() == 1)
            {
                enumerable.Single().Code = str;
                return;
            }

            var bestDiff = int.MaxValue;
            int i;
            for (i = 1; i < enumerable.Count(); i++)
            {
                var firstPartCount = TotalCount(enumerable.Take(i));
                var secondPartCount = TotalCount(enumerable.Skip(i));
                var diff = Math.Abs(firstPartCount - secondPartCount);

                if (diff < bestDiff)
                    bestDiff = diff;
                else
                    break;
            }
            i -= 1;

            Console.WriteLine("{0}{1}|{2}", new String('\t', depth), enumerable.Take(i).Aggregate("", (a, s) => a + s.Text + " "), enumerable.Skip(i).Aggregate("", (a, s) => a + s.Text + " "));

            Coding(enumerable.Take(i), str + "0", depth + 1);
            Coding(enumerable.Skip(i), str + "1", depth + 1);
        }
        
        private static void ReturnSymbolInfo(Symbol symbol) =>
            Console.WriteLine( $"Symbol {symbol.ReturnText()} -> " +
                               $"Count: {symbol.ReturnCount()}, " +
                               $"Probability: {symbol.ReturnProbability()}%, " +
                               $"Code: {symbol.ReturnCode()}" );
    }
}