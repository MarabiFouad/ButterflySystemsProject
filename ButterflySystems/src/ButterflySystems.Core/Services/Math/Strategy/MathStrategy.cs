using ButterflySystems.Core.Extensions;
using ButterflySystems.Core.Services.Contracts;
using ButterflySystems.Models.DTOs;
using ButterflySystems.Models.Enums;
using ButterflySystems.Models.Errors;
using ButterflySystems.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ButterflySystems.Core.Services
{
    public class MathStrategy : IMathStrategy
    {
        private readonly IMathOperator[] _operators;

        public MathStrategy(IMathOperator[] operators)
        {
            _operators = operators;
        }

        public async Task<CalculationResponse> Calculate(decimal number1, decimal number2, Operator op, CancellationToken ct = default(CancellationToken))
        {
            var @operator = _operators.FirstOrDefault(x => x.Operator == op);

            if (@operator == null)
                throw new ButterflySystemsException("Invalid operator", ErrorCode.InvalidOperator);

            return FormatResponse(await @operator.Calculate(number1, number2, ct), number1, number2, @operator.Operator);
        }

        public CalculationResponse FormatResponse(decimal result, decimal number1, decimal number2, Operator @operator)
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
