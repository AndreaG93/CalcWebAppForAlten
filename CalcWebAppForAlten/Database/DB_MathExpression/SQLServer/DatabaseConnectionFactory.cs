using System.Data.SqlClient;

namespace CalcWebAppForAlten.Database.DB_MathExpression.SQLServer;

public class DatabaseConnectionFactory
{
    public static SqlConnection Build()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        builder.DataSource = "(localdb)\\MSSQLLocalDB";
        builder.InitialCatalog = "AndreaDB";

        return new SqlConnection(builder.ConnectionString);
    }
}
