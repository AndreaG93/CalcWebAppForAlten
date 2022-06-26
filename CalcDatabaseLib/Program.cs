using CalcWebAppForAlten.Database.DB_MathExpression;
using CalcWebAppForAlten.Model;
using System.Data.SqlClient;


namespace CalcWebAppForAlten
{
    public class Program
    {


        public static void Main(string[] args)
        {
            
            try
            {
                DAO? DAO = DAOFactory.Build(DAOFactory.SQLServer);

                if (DAO == null)
                {
                    throw new NullReferenceException("'DAO' CANNOT be null!");
                }
                else
                {
                    MathExpression item = new MathExpression("(4+5+5)", 14);

                    DAO.Insert(item);
                    Console.WriteLine(DAO.Get(2).ToString());
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
