using CalcWebAppForAlten.Model;

namespace CalcWebAppForAlten.Database.DB_MathExpression;

public interface DAO
{
    public MathExpression? Get(int id);
    public void Insert(MathExpression input);
    public void Delete(MathExpression input);
    public List<MathExpression> GetAllItems();
}
