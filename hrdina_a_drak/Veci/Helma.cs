namespace hrdina_a_drak.Veci
{
    public class Helma : Vec
    {
        private static int BonusovaObrana { get; set; }

        public Helma(string nazev, int bonusovaObrana) : base(nazev)
        {
            BonusovaObrana = bonusovaObrana;
        }
        public static int VratBonusovouObranu()
        {
            return BonusovaObrana;
        }
    }
}