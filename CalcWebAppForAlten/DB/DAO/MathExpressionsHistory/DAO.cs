namespace CalcWebAppForAlten.DB.MathExpressionsHistory
{
    public interface DAO
    {
        public Item Get(int id);
        public void Insert(Item input);
        public void Delete(Item input);
        public List<Item> GetAllItems();
    }
}
