namespace hrdina_a_drak.Veci
{
    public class Mec : Vec
    {
        private static int BonusovePoskozeni { get; set; }
        
        public Mec(string nazev, int bonusovePoskozeni) : base(nazev)
        {
            BonusovePoskozeni = bonusovePoskozeni;
        }
        
        public static int VratBonusovePoskozeni()
        {
            return BonusovePoskozeni;
        }
    }
}