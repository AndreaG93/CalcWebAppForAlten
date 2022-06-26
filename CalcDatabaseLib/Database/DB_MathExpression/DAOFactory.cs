namespace CalcDatabaseLib.Database.DB_MathExpression;

public class DAOFactory
{
    public const string SQLServer = "SQLServer";

    public static DAO? Build(string databaseServerName)
    {
        DAO? output = null;

        if (databaseServerName == null)
        {
            throw new ArgumentNullException("The database server name CANNOT be null");
        }
        else
        {
            switch (databaseServerName)
            {
                case SQLServer:
                    output = new SQLServer.ConcreteDAO();
                    break;
                default:

                    string errorMessage = string.Format("'{}' is NOT a supported or recognized database server",
                        databaseServerName);

                    throw new ArgumentException(errorMessage);
            };
        }

        return output;
    }
}
