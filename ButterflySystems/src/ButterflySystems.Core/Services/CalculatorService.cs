using ButterflySystems.Core.Extensions;
using ButterflySystems.Core.Services.Contracts;
using ButterflySystems.Models.DTOs;
using ButterflySystems.Models.Enums;
using ButterflySystems.Models.Errors;
using ButterflySystems.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ButterflySystems.Core.Services
{

    public class CalculatorService : ICalculatorService
    {
        public async Task<CalculationResponse> Add(decimal number1, decimal number2, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FormatResponse(await Task.FromResult(number1 + number2), number1, number2, CalculatorOperator.Add);
        }

        public async Task<CalculationResponse> Divide(decimal number1, decimal number2, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (number2 == 0)
                throw new ButterflySystemsException("Divide by zero error.", $"A validation error occurred while dividing number1:{number1} & number2:{number2}.", ErrorCode.DivideByZero);

            return FormatResponse(await Task.FromResult(number1 / number2), number1, number2, CalculatorOperator.Divide);
        }

        public async Task<CalculationResponse> Multiply(decimal number1, decimal number2, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FormatResponse(await Task.FromResult(number1 * number2), number1, number2, CalculatorOperator.Multiply);
        }

        public async Task<CalculationResponse> Subtract(decimal number1, decimal number2, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FormatResponse(await Task.FromResult(number1 - number2), number1, number2, CalculatorOperator.Subtract);
        }

        public CalculationResponse FormatResponse(decimal result, decimal number1, decimal number2, CalculatorOperator @operator)
        {
            return new CalculationResponse
            {
                Number1 = number1,
                Number2 = number2,
                Operator = @operator.GetDescription(),
                Result = result
            };
        }
    }
}
