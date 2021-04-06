using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace AP2TP_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // input string
            var input = "This is test";
            /*
            var input = "sed viverra ipsum nunc aliquet bibendum enim facilisis gravida neque convallis a cras " +
                             "semper auctor neque vitae tempus quam pellentesque nec nam aliquam sem et tortor consequa";
              */             


            // variables
            var characters = new Dictionary<char, int>();
            var letterCount = input.Length;
            
            // check if character c is in letter, if not add it, if yes, add value +1
            foreach (var c in input)
            {
                if (characters.ContainsKey(c))
                {
                    characters[c]++;
                }
                else
                {
                    characters[c] = 1;
                }
            }

            Console.WriteLine($"Number of characters: {letterCount}");

            // print keys, values of dictionary letters
            foreach (var c in characters)
                Console.WriteLine($"Key, Value = {c}");
            
            
            // probability
            var probabilityDict = new Dictionary<char, double>();
            foreach (var c in characters)
            {
                var probability = Convert.ToDouble(c.Value) / letterCount;
                probabilityDict.Add(c.Key, probability);
            }

            foreach (var c in probabilityDict)
            {
                Console.WriteLine($"Key, Probablity = {c}");
            }
            
            
           




        }

        private static string ShannonFanova(string input)
        {
            return input;
        }
    }
}