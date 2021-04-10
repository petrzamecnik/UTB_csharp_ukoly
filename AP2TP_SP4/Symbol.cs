namespace AP2TP_SP4
{
    public class Symbol
    {
        private string Text { get; set; }
        private int Count { get; set; }
        public double Probability { get; set; }
        private string Code { get; set; }

        public Symbol(string text, int count, double probability, string code)
        {
            Text = text;
            Count = count;
            Probability = probability;
            Code = code;
        }

        public void AddCount()
        {
            Count++;
        }

        public string ReturnText()
        {
            return Text;
        }
        public int ReturnCount()
        {
            return Count;
        }
        public double ReturnProbability()
        {
            return Probability;
        }
        public string ReturnCode()
        {
            return Code;
        }
    }
}