using ButterflySystems.Core.Constants;
using ButterflySystems.Core.Extensions;
using ButterflySystems.Core.Services.Contracts;
using ButterflySystems.Models.DTOs;
using ButterflySystems.Models.Enums;
using ButterflySystems.Models.Errors;
using ButterflySystems.Models.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace ButterflySystems.Core.Services
{

    public class CalculatorService : ICalculatorService
    {
        public async Task<CalculationResponse> Add(CalculationRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (request == null)
                throw new ButterflySystemsException(ConstantValues.InvalidCalculationRequest, string.Format(ConstantValues.LogOperation, "adding"), ErrorCode.InvalidRequest);

            return FormatResponse(await Task.FromResult(request.Number1 + request.Number2), request, Operator.Add);
        }

        public async Task<CalculationResponse> Divide(CalculationRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (request == null)
                throw new ButterflySystemsException(ConstantValues.InvalidCalculationRequest, string.Format(ConstantValues.LogOperation, "dividing"), ErrorCode.InvalidRequest);

            if (request.Number2 == 0)
                throw new ButterflySystemsException("Divide by zero error.", string.Format(ConstantValues.LogOperation, $"dividing number1:{request.Number1} & number2:{request.Number2}"), ErrorCode.DivideByZero);

            return FormatResponse(await Task.FromResult(request.Number1 / request.Number2), request, Operator.Divide);
        }

        public async Task<CalculationResponse> Multiply(CalculationRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (request == null)
                throw new ButterflySystemsException(ConstantValues.InvalidCalculationRequest, string.Format(ConstantValues.LogOperation, "multipling"), ErrorCode.InvalidRequest);

            return FormatResponse(await Task.FromResult(request.Number1 * request.Number2), request, Operator.Multiply);
        }

        public async Task<CalculationResponse> Subtract(CalculationRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (request == null)
                throw new ButterflySystemsException(ConstantValues.InvalidCalculationRequest, string.Format(ConstantValues.LogOperation, "subtracting"), ErrorCode.InvalidRequest);

            return FormatResponse(await Task.FromResult(request.Number1 - request.Number2), request, Operator.Subtract);
        }

        public CalculationResponse FormatResponse(decimal result, CalculationRequest request, Operator @operator)
        {
            if (request == null)
                throw new ButterflySystemsException(ConstantValues.InvalidCalculationRequest, string.Format(ConstantValues.LogOperation, "formating response."), ErrorCode.InvalidRequest);

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
