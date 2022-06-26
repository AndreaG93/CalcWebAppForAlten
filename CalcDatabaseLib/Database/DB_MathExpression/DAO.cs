using CalcDatabaseLib.Model;

namespace CalcDatabaseLib.Database.DB_MathExpression;

public interface DAO
{
    public Task<MathExpression?> GetAsync(int id);
    public Task<int> InsertAsync(MathExpression input);
    public Task Delete(MathExpression input);
    public Task Delete(int id);
    public Task<List<MathExpression>> GetAll();
    public Task DeleteAllAsync();
}
