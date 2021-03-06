using ButterflySystems.Core.Services.Contracts;
using ButterflySystems.Models.DTOs;
using ButterflySystems.Models.Enums;
using ButterflySystems.Models.Errors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

/// <summary>
/// Exceptions are handeled in the middleware 
/// </summary>
/// 
namespace ButterflySystems.API.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly IMathStrategy _mathStrategy;
        public CalculatorController(IMathStrategy mathStrategy)
        {
            _mathStrategy = mathStrategy;
        }

        [HttpGet("add")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CalculationResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error))]
        public async Task<IActionResult> Add([FromQuery] CalculationRequest request, CancellationToken ct)
        {
            return Ok(await _mathStrategy.Calculate(request, Operator.Add, ct));
        }

        [HttpGet("subtract")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CalculationResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error))]
        public async Task<IActionResult> Subtract([FromQuery] CalculationRequest request, CancellationToken ct)
        {
            return Ok(await _mathStrategy.Calculate(request,Operator.Subtract, ct));
        }

        [HttpGet("multiply")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CalculationResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error))]
        public async Task<IActionResult> Multiply([FromQuery] CalculationRequest request, CancellationToken ct)
        {
            return Ok(await _mathStrategy.Calculate(request, Operator.Multiply, ct));
        }

        [HttpGet("divide")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CalculationResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error))]
        public async Task<IActionResult> Divide([FromQuery] CalculationRequest request, CancellationToken ct)
        {
            return Ok(await _mathStrategy.Calculate(request, Operator.Divide, ct));
        }
    }
}
