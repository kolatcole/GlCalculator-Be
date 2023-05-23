using CalculatorLibrary;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlCalculator.Controllers
{ 

    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ISimpleCalculator _service;
        private readonly ILogger _logger;
        public CalculatorController(ISimpleCalculator service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{first}/{second}/{operation}")]
        public IActionResult Get(int first, int second, string operation)
        {
            _logger.LogInformation("Starting operation");
            int result;
            if (operation.ToLower() == "add")
            {
                result = _service.Add(first, second);
                _logger.LogInformation($"Added {first} and {second} to get {result}");
                return Ok(result);
            }

            else if (operation.ToLower() == "subtract")
            {
                result = _service.Subtract(first, second);
                _logger.LogInformation($"Subtracted {second} from {first} to get {result}");
                return Ok(result);
            }
            else
            {
                _logger.LogInformation("Operator is not valid");
                return NotFound("Operator is not valid");
            }
                
        }

      
    }
}
