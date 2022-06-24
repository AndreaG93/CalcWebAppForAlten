using CalcWebAppForAlten.DB.SQLServerCommon;
using System.Data.SqlClient;

namespace CalcWebAppForAlten
{
    public class Program
    {


        public static void Main(string[] args)
        {
            SqlConnection sqlConnection;

            try
            {
                DB.MathExpressionsHistory.DAO? DAO = DB.MathExpressionsHistory.DAOFactory.Build(DB.MathExpressionsHistory.DAOFactory.SQLServer);

                if (DAO == null)
                {
                    throw new NullReferenceException("'DAO' CANNOT be null!");
                }
                else
                {
                    DB.MathExpressionsHistory.Item item = new DB.MathExpressionsHistory.Item("(4+5+5)", 14);

                    DAO.Insert(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }







            Console.WriteLine("OK");

        }
    }
}




/*var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
*/
