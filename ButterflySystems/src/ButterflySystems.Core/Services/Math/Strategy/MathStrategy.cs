using ButterflySystems.Core.Constants;
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

        public async Task<CalculationResponse> Calculate(CalculationRequest request, Operator op, CancellationToken ct = default(CancellationToken))
        {
            if (request == null)
                throw new ButterflySystemsException(ConstantValues.InvalidCalculationRequest, string.Format(ConstantValues.LogOperation, "calculating"), ErrorCode.InvalidRequest);

            var @operator = _operators.FirstOrDefault(x => x.Operator == op);

            if (@operator == null)
                throw new ButterflySystemsException("Invalid operator", ErrorCode.InvalidOperator);

            return FormatResponse(await @operator.Calculate(request.Number1, request.Number2, ct), request, @operator.Operator);
        }

        public CalculationResponse FormatResponse(decimal result, CalculationRequest request, Operator @operator)
        {
            return new CalculationResponse
            {
                Number1 = request.Number1,
                Number2 = request.Number2,
                Operator = @operator.GetDescription(),
                Result = result
            };
        }
    }
}
