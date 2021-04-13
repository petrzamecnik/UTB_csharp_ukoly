namespace hrdina_a_drak.Veci
{
    public class Brneni : Vec
    {
        private static int BonusovaObrana { get; set; }

        public Brneni(string nazev, int bonusovaObrana) : base(nazev)
        {
            BonusovaObrana = bonusovaObrana;
        }
        public static int VratBonusovouObranu()
        {
            return BonusovaObrana;
        }
    }
}