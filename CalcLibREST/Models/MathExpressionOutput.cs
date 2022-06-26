using System.Text.Json;

namespace CalcREST.Models
{
    public class MathExpressionOutput
    {
        public double Result { get; }

        public MathExpressionOutput(double result)
        {
            this.Result = result;
        }

        public string SerializeToJSON()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
