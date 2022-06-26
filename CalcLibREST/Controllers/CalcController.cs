using CalcREST.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using CalcDatabaseLib.Database.DB_MathExpression;
using CalcDatabaseLib.Model;

namespace CalcREST.Controllers;

[ApiController]
[Route("REST/Calc")]
public class CalcController : ControllerBase
{
    [HttpPost]
    [Route("Compute/{account}")]
    public IActionResult WA_ExecuteComputation([FromBody] object json)
    {
        return BadRequest(json);
    }

    [HttpPost("Compute")]
    public async Task<IActionResult> GetMathExpressionComputation([FromBody] JsonElement json)
    {
        MathExpressionInput input;
        MathExpressionOutput output;

        string outputJSON;

        try
        {
            input = json.Deserialize<MathExpressionInput>();

            double result = CalcLib.Calc.Compute(input.Content);

            output = new MathExpressionOutput(result);

            SaveToDatabase(input.Content, result);
            
            outputJSON = JsonSerializer.Serialize(output);

            return StatusCode(StatusCodes.Status200OK, outputJSON);
        }
        catch (Exception ex)
        {
            outputJSON = JsonSerializer.Serialize(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, outputJSON);
        }
    }

    private static void SaveToDatabase(string expression, double result)
    {
        DAO? DAO = DAOFactory.Build(DAOFactory.SQLServer);

        if (DAO == null)
        {
            throw new NullReferenceException("'DAO' CANNOT be null!");
        }
        
        MathExpression item = new MathExpression(expression, result);

        DAO.InsertAsync(item);
    }
}


// curl -Method Post -Body '{"Expression":"42+2"}' -Uri  https://localhost:7116/api/Calc/WA_ExecuteCalc