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
            var input = "sed viverra ipsum nunc aliquet bibendum enim facilisis gravida neque convallis a cras " +
                             "semper auctor neque vitae tempus quam pellentesque nec nam aliquam sem et tortor consequa";
                           

            input = input.ToUpper();

            // variables
            var letters = new Dictionary<char, int>();
            var letterCount = input.Length;
            var probability = 0;

            
            // check if character c is in letter, if not add it, if yes, add value +1
            foreach (var c in input)
            {
                if (letters.ContainsKey(c))
                {
                    letters[c]++;
                }
                else
                {
                    letters[c] = 1;
                }
            }

            Console.WriteLine($"Pocet znaku: {letterCount}");

            foreach (var c in letters)
            {
               
            }
            

            
        }

        private static string ShannonFanova(string input)
        {
            return input;
        }
    }
}