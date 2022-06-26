using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using CalcREST.Models;

namespace CalcWebAPI.Controllers
{
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

        [HttpGet("Compute")]
        public async Task<IActionResult> GetMathExpressionComputation([FromBody] object json)
        {

            // var request = Request.
            double result = 0;
            Exception myException = null;

            try
            {
                String rawMathExpression = json.ToString();

                MathExpressionInput rawUserInput = JsonConvert.DeserializeObject<MathExpressionInput>(rawMathExpression);

                result = CalcLib.Calc.Compute(rawMathExpression);
            }
            catch (Exception ex)
            {
                myException = ex;
                return BadRequest(ex);
            }

            return Ok(result);
        }
    }
}


// curl -Method Post -Body '{"Expression":"42+2"}' -Uri  https://localhost:7116/api/Calc/WA_ExecuteCalc