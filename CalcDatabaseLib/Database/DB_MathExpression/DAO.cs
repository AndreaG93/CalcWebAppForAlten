using CalcDatabaseLib.Model;

namespace CalcDatabaseLib.Database.DB_MathExpression;

public interface DAO
{
    public Task<MathExpression?> GetAsync(int id);
    public Task InsertAsync(MathExpression input);
    public Task Delete(MathExpression input);
    public Task<List<MathExpression>> GetAllItems();
}
