using System;
using System.Collections.Generic;
using hrdina_a_drak.Veci;

namespace hrdina_a_drak.Postavy
{
    public class Hrdina: Postava
    {
        public List<Vec> Inventar { get; }
        // public List<Vec> NasazeneVeci { get; set; }

        private static Helma Helma { get; set; }
        private static Brneni Brneni { get; set; }
        private static Mec Mec { get; set; }
        private static Stit Stit { get; set; }

        private int MaxZivoty { get; set; }


        public Hrdina(string jmeno, int level, int zivoty, int utok, int obrana, bool isHrdina, List<Vec> inventar, Helma helma, Brneni brneni, Mec mec, Stit stit, int maxZivoty) : base(jmeno, level, zivoty, utok, obrana, isHrdina)
        {
            Inventar = inventar;
            Helma = helma;
            Brneni = brneni;
            Mec = mec;
            Stit = stit;
            MaxZivoty = maxZivoty;
        }

        public void ObnovZivoty()
        {
            if (Zivoty < MaxZivoty)
            {
                Zivoty += 30;
            }

            if (Zivoty > MaxZivoty)
            {
                Zivoty = MaxZivoty;
            }
        }
        
        public void ZvyseniLevelu()
        {
            Level++;
            MaxZivoty += 15;
            Utok += 5;
            Obrana += 3;
        }
        
        public static void VypisVybaveniHrdiny()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Helma: {0}", Helma.VratNazevVeci());
            Console.WriteLine("Brneni: {0}", Brneni.VratNazevVeci());
            Console.WriteLine("Mec: {0}", Mec.VratNazevVeci());
            Console.WriteLine("Stit: {0}", Stit.VratNazevVeci());
            Console.WriteLine("******************************");
        }
        
        public int VratMaximalniPocetZivotu()
        {
            return MaxZivoty;
        }
        
        public void PridejBonusovePoskozeni()
        {
            Utok += Convert.ToInt32(Mec.VratBonusovePoskozeni());
        }

        public void PridejBonusovouObranu()
        {
            
            Obrana += Helma.VratBonusovouObranu() + Brneni.VratBonusovouObranu() + Stit.VratBonusovouObranu();
        }

        public void OdeberBonusovePoskozeni()
        {
            Utok -= Convert.ToInt32(Mec.VratBonusovePoskozeni());
        }

        public void OdeberBonusovouObranu()
        {
            Obrana -= Helma.VratBonusovouObranu() + Brneni.VratBonusovouObranu() + Stit.VratBonusovouObranu();
        }

        public void NasadPredmet(Vec predmet)
        {
            switch (predmet)
            {
                case Helma helma:
                    Helma = helma;
                    break;
                case Brneni brneni:
                    Brneni = brneni;
                    break;
                case Mec mec:
                    Mec = mec;
                    break;
                case Stit stit:
                    Stit = stit;
                    break;
            }
        }

        public int VratLevel()
        {
            return Level;
        }
    }
}