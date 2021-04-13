using System;
using hrdina_a_drak.Veci;

namespace hrdina_a_drak.Postavy
{
    public class Postava
    {
        protected String Jmeno { get; set; }
        
        // staty
        // level, zivoty, utok, obrana,  

        protected int Level { get; set; }

        protected int Zivoty { get; set; }
        
        protected int Utok { get; set; }
        protected int Obrana { get; set; }
        
        private bool IsHrdina { get; set; }


        Random generator = new Random();


        protected Postava(string jmeno, int level, int zivoty, int utok, int obrana, bool isHrdina)
        {
            Jmeno = jmeno;
            Level = level;
            Zivoty = zivoty;
            Utok = utok;
            Obrana = obrana;
            IsHrdina = isHrdina;
        }

        public void Utocit(Postava oponent)
        {
            int poskozeni = Convert.ToInt32(Utok * generator.NextDouble());
            poskozeni -= oponent.Branit();  

            if (poskozeni >= 1)
            {
                oponent.Zivoty -= poskozeni;
                Console.WriteLine(Jmeno + " zaútočil za: " + poskozeni + " poškození.");
            }
            else
            {
                Console.WriteLine(Jmeno + " se útok nepovedl.");
            }
        }

        private int Branit()
        {
            int obrana = Convert.ToInt32(Obrana * generator.NextDouble());
            return obrana;

        }
        
        public bool JeNaZivu()
        {
            return Zivoty > 0;
        }

        public int VratPocetZivotu()
        {
            return Zivoty;
        }

        
        

        // pozor zde !!!
        public bool JeHrdina()
        {
            return IsHrdina == true;
        }

        public int VratUtok()
        {
            return Utok;
        }

        public int VratObranu()
        {
            return Obrana;
        }

        public string VratJmeno()
        {
            return Jmeno;
        }
        

        public int VratUroven()
        {
            return Level;
        }
    }
}