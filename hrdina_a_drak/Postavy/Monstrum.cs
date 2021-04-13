using System.Collections.Generic;
using hrdina_a_drak.Veci;

namespace hrdina_a_drak.Postavy
{
    public class Monstrum : Postava
    {
        public List<Vec> SeznamVeci { get; }

        public Monstrum(string jmeno, int level, int zivoty, int utok, int obrana, bool isHrdina, List<Vec> seznamVeci) 
            : base(jmeno, level, zivoty, utok, obrana, isHrdina)
        {
            SeznamVeci = seznamVeci;
        }
    }
}