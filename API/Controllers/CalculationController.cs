using calculator_class_example.Domain;
using calculator_class_example.Logic;
using Microsoft.AspNetCore.Mvc;

namespace API.AddControllers
{
    [ApiController]
    [Route("api/[calculations]")]
    public class CalculationsController : ControllerBase
    {
        private readonly CalculatorService _calculatorService;

        public CalculationController(CalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet] // GET api/calculations
        public async Task<IActionResult> GetAll()
        {
            var calculations = await _calculatorService.GetAllAsync();
        }

        // Additional endpoints for subtract, multiply, divide can be added similarly
    }
}