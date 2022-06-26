using CalcREST.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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

            outputJSON = JsonSerializer.Serialize(output);
            return StatusCode(StatusCodes.Status200OK, outputJSON);
        }
        catch (Exception ex)
        {
            outputJSON = JsonSerializer.Serialize(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, outputJSON); 
        }
    }
}


// curl -Method Post -Body '{"Expression":"42+2"}' -Uri  https://localhost:7116/api/Calc/WA_ExecuteCalc