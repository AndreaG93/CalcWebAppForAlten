namespace CalcDatabaseLib.Database.DB_MathExpression.SQLServer;

using CalcDatabaseLib.Model;
using System.Data.SqlClient;
public class ConcreteDAO : DAO
{
    private const String TableName = "MathExpressionHistory";
    private const String Column1 = "id";
    private const String Column2 = "expression";
    private const String Column3 = "resultExpression";

    private const uint maxMathExpressionRepresentationLenght = 100;

    public void Delete(MathExpression input)
    {
        throw new NotImplementedException();
    }

    public MathExpression? Get(int id)
    {
        MathExpression? output = null;

        if (id <= 0)
        {
            throw new ArgumentException("The ID CANNOT be <= 0");
        }
        else
        {
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
                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    double dd = dataReader.GetDouble(2);

                    output = new MathExpression((int)dataReader.GetValue(0), dataReader.GetString(1), dataReader.GetDouble(2));
                }
            }
        }

        return output;
    }

    public List<MathExpression> GetAllItems()
    {
        throw new NotImplementedException();
    }

    public void Insert(MathExpression input)
    {
        if (input.Represation.Length > 100)
        {
            throw new ArgumentException("Math representation too long");
        }
        else
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sqlQuery = String.Format("INSERT INTO {0} ({1},{2}) VALUES ('{3}',{4})",
                TableName,
                Column2,
                Column3,
                input.Represation,
                input.Result);

            using (SqlConnection connection = GetOpenConnection())
            {

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);

                adapter.InsertCommand = sqlCommand;
                adapter.InsertCommand.ExecuteNonQuery();
            }
        }
    }

    List<MathExpression> DAO.GetAllItems()
    {
        throw new NotImplementedException();
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
