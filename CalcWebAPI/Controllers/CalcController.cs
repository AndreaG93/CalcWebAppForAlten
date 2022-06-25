using CalcWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace CalcWebAPI.Controllers
{
    [ApiController]
    [Route("api/Calc")]
    public class CalcController : ControllerBase
    {
        [HttpPost]
        [Route("WA_ExecuteCalc")]
        public IActionResult WA_ExecuteComputation([FromBody] object json)
        {
            return BadRequest(json);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson([FromRoute] int id)
        {

            Console.WriteLine(id);

            return Ok();
        }
    }
}


// curl -Method Post -Body '{"Expression":"42+2"}' -Uri  https://localhost:7116/api/Calc/WA_ExecuteCalc