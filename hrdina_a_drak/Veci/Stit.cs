namespace hrdina_a_drak.Veci
{
    public class Stit : Vec
    {
        private static int BonusovaObrana { get; set; }

        public Stit(string nazev, int bonusovaObrana) : base(nazev)
        {
            BonusovaObrana = bonusovaObrana;
        }
        public static int VratBonusovouObranu()
        {
            return BonusovaObrana;
        }
    }
}