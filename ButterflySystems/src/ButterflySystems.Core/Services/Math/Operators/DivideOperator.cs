using ButterflySystems.Core.Constants;
using ButterflySystems.Core.Services.Contracts;
using ButterflySystems.Models.Enums;
using ButterflySystems.Models.Errors;
using ButterflySystems.Models.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ButterflySystems.Core.Services
{
    public class DivideOperator : IMathOperator
    {
        public Operator Operator => Operator.Divide;

        public async Task<decimal> Calculate(decimal number1, decimal number2, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                return await Task.FromResult(number1 / number2);
            }
            catch (DivideByZeroException ex)
            {

                throw new ButterflySystemsException("Divide by zero error.", string.Format(ConstantValues.LogOperation, $"dividing number1:{number1} & number2:{number2}"), ErrorCode.DivideByZero);
            }

        }
    }
}
