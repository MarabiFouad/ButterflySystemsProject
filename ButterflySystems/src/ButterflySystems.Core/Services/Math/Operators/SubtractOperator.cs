using ButterflySystems.Core.Services.Contracts;
using ButterflySystems.Models.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace ButterflySystems.Core.Services
{
    public class SubtractOperator : IMathOperator
    {
        public Operator Operator => Operator.Subtract;

        public Task<decimal> Calculate(decimal number1, decimal number2, CancellationToken ct = default(CancellationToken))
        {
            return Task.FromResult(number1 - number2);
        }
    }
}
