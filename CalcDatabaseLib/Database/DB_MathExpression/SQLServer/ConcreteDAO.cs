namespace CalcDatabaseLib.Database.DB_MathExpression.SQLServer;

using CalcDatabaseLib.Model;
using System.Data.SqlClient;

public class ConcreteDAO : DAO
{
    private const String TableName = "MathExpressionHistory";
    private const String Column1 = "id";
    private const String Column2 = "expression";
    private const string Column3 = "resultExpression";

    private const uint MaxMathExpressionRepresentationLenght = 100;

    public async Task Delete(MathExpression input)
    {
        string sqlQuery = String.Format("DELETE FROM {0} WHERE {1}={2}",
            TableName,
            Column1,
            input.ID
            );

        SqlDataAdapter adapter = new SqlDataAdapter();
        
        using (SqlConnection connection = GetOpenConnection())
        {
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);

            adapter.InsertCommand = sqlCommand;
            await adapter.InsertCommand.ExecuteNonQueryAsync();
        }
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<MathExpression?> GetAsync(int id)
    {
        MathExpression? output = null;

        if (id <= 0)
        {
            throw new ArgumentException("The ID CANNOT be <= 0");
        }

        string sqlQuery = String.Format("SELECT {0},{1},{2} FROM {3} WHERE ({4}={5})",
            Column1,
            Column2,
            Column3,
            TableName,
            Column1,
            id);

        using (SqlConnection connection = GetOpenConnection())
        {
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);
            SqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync();

            while (dataReader.Read())
            {
                output = new MathExpression((int)dataReader.GetValue(0), dataReader.GetString(1),
                    dataReader.GetDouble(2));
            }
        }
        
        return output;
    }

    public async Task<List<MathExpression>> GetAll()
    {
        List<MathExpression> output = new List<MathExpression>();
        
        string sqlQuery = String.Format("SELECT * FROM {0}",
            TableName);

        using (SqlConnection connection = GetOpenConnection())
        {
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);
            SqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync();

            while (dataReader.Read())
            {
                MathExpression item = new MathExpression((int)dataReader.GetValue(0), dataReader.GetString(1),
                    dataReader.GetDouble(2));
                
                output.Add(item);
            }
        }

        return output;
    }

    public Task DeleteAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> InsertAsync(MathExpression input)
    {
        if (input.Represation.Length > MaxMathExpressionRepresentationLenght)
        {
            throw new ArgumentException("Math representation too long");
        }
        
        string sqlQuery = String.Format("INSERT INTO {0} ({1},{2}) VALUES ('{3}',{4}); SELECT SCOPE_IDENTITY();",
            TableName,
            Column2,
            Column3,
            input.Represation,
            input.Result);

        SqlDataAdapter adapter = new SqlDataAdapter();
        
        using (SqlConnection connection = GetOpenConnection())
        {
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);

            adapter.InsertCommand = sqlCommand;
            return Convert.ToInt32(await adapter.InsertCommand.ExecuteScalarAsync());
        }
    }
    
    private SqlConnection GetOpenConnection()
    {
        SqlConnection output = DatabaseConnectionFactory.Build();

        try
        {
            output.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(1);
        }

        return output;
    }
}