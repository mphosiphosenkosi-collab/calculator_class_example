using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculationService(CalculationService calculationService) : ControllerBase
    {
        private readonly CalculationService _calculationService = calculationService;

        


        [HttpDelete("clear")]
        public async Task<IActionResult> ClearHistory()
        {
            // Note: You'll need to add this method to CalculationService
            return BadRequest(new { error = "ClearHistory not implemented yet" });
        }
    }

    public class Calculation
    {
    }
}