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
            var input = "sed viverra ipsum nunc aliquet bibendum enim facilisis gravida neque convallis a cras " +
                           "semper auctor neque vitae tempus quam pellentesque nec nam aliquam sem et tortor consequa" +
                           "t id porta nibh venenatis cras sed felis eget velit aliquet sagittis id consectetur purus" +
                           " ut faucibus pulvinar elementum integer enim neque volutpat ac";

            input = input.ToUpper();
            
            var letters = new Dictionary<string, int>()
            {
                {"A", 0}, {"B", 0}, {"C", 0}, {"D", 0}, {"E", 0},
                {"F", 0}, {"G", 0}, {"H", 0}, {"I", 0}, {"J", 0}, 
                {"K", 0}, {"L", 0}, {"M", 0}, {"N", 0}, {"O", 0},
                {"P", 0}, {"Q", 0}, {"R", 0}, {"S", 0}, {"T", 0},
                {"U", 0}, {"V", 0}, {"W", 0}, {"X", 0}, {"Y", 0},
                {"Z", 0}
            };

            var a = "A";


            var charArray = new char[input.Length];
            charArray = input.ToCharArray();
            foreach (var c in charArray)
            {
                if (letters.ContainsKey(c.ToString()))
                {
                    
                }
            }
        }

        private static string ShannonFanova(string input)
        {
            return input;
        }
    }
}