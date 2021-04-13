using System.Collections.Generic;
using hrdina_a_drak.Postavy;

namespace hrdina_a_drak.Veci
{
    public class Vec
    {
        private string Nazev { get; set; }

        public Vec(string nazev)
        {
            Nazev = nazev;
        }

        public string VratNazevVeci()
        {
            return Nazev;
        }
    }
}