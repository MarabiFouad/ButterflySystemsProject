using ButterflySystems.Core.Services.Contracts;
using ButterflySystems.Models.Enums;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ButterflySystems.Core.Services
{
    public class AddOperator : IMathOperator
    {
        public Operator Operator => Operator.Add;

        public async Task<decimal> Calculate(decimal number1, decimal number2, CancellationToken ct = default(CancellationToken))
        {
            return await Task.FromResult(number1 + number2);
        }
    }
}
