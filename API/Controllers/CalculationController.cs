using Microsoft.AspNetCore.Mvc;
using Calculator_Class_Example.Domain;
using Calculator_Class_Example.Logic;
using Calculator_Class_Example.Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculationController : ControllerBase
    {
        private readonly CalculationService _calculationService;

        public CalculationController(CalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        [HttpPost("calculate")]
        public async Task<ActionResult<Calculation>> Calculate([FromBody] CalculationRequest request)
        {
            try
            {
                var calculation = await _calculationService.CalculateAsync(request);
                return Ok(calculation);
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(new { error = "Cannot divide by zero" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("history")]
        public async Task<ActionResult<IEnumerable<Calculation>>> GetHistory()
        {
            var history = await _calculationService.GetHistoryAsync();
            return Ok(history);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Calculation>> GetCalculation(Guid id)
        {
            var history = await _calculationService.GetHistoryAsync();
            var calculation = history.FirstOrDefault(c => c.Id == id);
            
            if (calculation == null)
                return NotFound();
            
            return Ok(calculation);
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearHistory()
        {
            await _calculationService.ClearHistoryAsync();
            return NoContent();
        }
    }
}
