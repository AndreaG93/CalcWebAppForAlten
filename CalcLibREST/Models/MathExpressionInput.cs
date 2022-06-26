using System.Text.Json;

namespace CalcREST.Models
{
    public class MathExpressionInput { 
        public string Content { get; set; } = string.Empty;     // From C# 6.0

        public string SerializeToJSON()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
