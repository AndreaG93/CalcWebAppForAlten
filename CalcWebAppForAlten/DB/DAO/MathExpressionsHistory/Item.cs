namespace CalcWebAppForAlten.DB.MathExpressionsHistory
{
    public class Item
    {
        public int ID { get; }
        public String Represation { get; }
        public double Result { get; }

        public Item(string represation, double result)
        {
            this.ID = -1;
            this.Represation = represation;
            this.Result = result;
        }

        public Item(int ID, string represation, double result)
        {
            this.ID = ID;
            this.Represation = represation;
            this.Result = result;
        }
    }
}
