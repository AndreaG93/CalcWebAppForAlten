using System.Data.SqlClient;

namespace CalcDatabaseLib.Database.DB_MathExpression.SQLServer;

public static class DatabaseConnectionFactory
{
    public static SqlConnection Build()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        builder.DataSource = "(localdb)\\MSSQLLocalDB";
        builder.InitialCatalog = "AndreaDB";

        return new SqlConnection(builder.ConnectionString);
    }
}