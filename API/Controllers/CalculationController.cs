using Microsoft.AspNetCore.Mvc;
using Calculator_Class_Example.Domain;  // For CalculationRequest
using Calculator_Class_Example.Logic;   // For CalculationService

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculationController : ControllerBase
    {
        private readonly CalculationService _calculationService;

        // FIX 1: Changed CalculatorService → CalculationService
        // FIX 2: Added return type (constructor has no return type)
        // FIX 3: Fixed parameter name
        public CalculationController(CalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        [HttpPost("calculate")]
        public async Task<ActionResult<Calculation>> Calculate([FromBody] CalculationRequest request)
        {
            try
            {
                // FIX 4: Ensure CalculationService has CalculateAsync method
                var calculation = await _calculationService.CalculateAsync(
                    request.Left, 
                    request.Right, 
                    request.Operation
                );
                return Ok(calculation);
            }
            catch (DivideByZeroException)
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
            // Note: You'll need to add this method to CalculationService
            return BadRequest(new { error = "ClearHistory not implemented yet" });
        }
    }
}