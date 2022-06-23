using ButterflySystems.Core.Services.Contracts;
using ButterflySystems.Models.Enums;
using ButterflySystems.Models.Errors;
using ButterflySystems.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Exceptions are handeled in the middleware 
/// </summary>
/// 
namespace ButterflySystems.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(decimal number1, decimal number2, CancellationToken cancellationToken)
        {
            return Ok(await _calculatorService.Add(number1, number2));
        }

        [HttpGet("subtract")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Subtract(decimal number1, decimal number2, CancellationToken cancellationToken)
        {
            return Ok(await _calculatorService.Subtract(number1, number2));
        }

        [HttpGet("multiply")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Multiply(decimal number1, decimal number2, CancellationToken cancellationToken)
        {
            return Ok(await _calculatorService.Multiply(number1, number2));
        }

        [HttpGet("divide")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Divide(decimal number1, decimal number2, CancellationToken cancellationToken)
        {
            return Ok(await _calculatorService.Divide(number1, number2));
        }
    }
}
