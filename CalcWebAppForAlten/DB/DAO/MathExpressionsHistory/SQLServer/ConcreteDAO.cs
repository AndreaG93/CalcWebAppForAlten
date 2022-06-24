using System.Data.SqlClient;

namespace CalcWebAppForAlten.DB.MathExpressionsHistory.SQLServer
{
    public class ConcreteDAO : DAO
    {
        private const String TableName = "MathExpressionHistory";
        private const String Column1 = "id";
        private const String Column2 = "expression";
        private const String Column3 = "resultExpression";

        private const uint maxMathExpressionRepresentationLenght = 100;
        private SqlConnection connection;

        public ConcreteDAO()
        {
            this.connection = SQLServerCommon.DatabaseConnectionFactory.Build();
        }

        public void Delete(Item input)
        {
            throw new NotImplementedException();
        }

        public Item Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public void Insert(Item input)
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

                using (this.connection)
                {
                    OpenConnection();

                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, this.connection);

                    adapter.InsertCommand = sqlCommand;
                    adapter.InsertCommand.ExecuteNonQuery();
                }
            }
        }

        private void OpenConnection()
        {
            try
            {
                this.connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
