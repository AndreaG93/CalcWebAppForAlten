namespace CalcWebAppForAlten.Model
{
    public class MathExpression
    {
        public int ID { get; }
        public string Represation { get; }
        public double Result { get; }

        public MathExpression(string represation, double result)
        {
            ID = -1;
            Represation = represation;
            Result = result;
        }

        public MathExpression(int ID, string represation, double result)
        {
            this.ID = ID;
            Represation = represation;
            Result = result;
        }

        override
        public string ToString()
        {
            return string.Format("Expression:\n ID:     {0}\n Text:   {1}\n Result: {2}", ID, Represation, Result);
        }
    }
}
