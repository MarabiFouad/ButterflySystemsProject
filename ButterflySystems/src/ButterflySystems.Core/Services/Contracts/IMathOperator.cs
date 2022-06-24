using ButterflySystems.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ButterflySystems.Core.Services.Contracts
{
    public interface IMathOperator
    {
        Operator Operator { get; }

        Task<decimal> Calculate(decimal number1, decimal number2, CancellationToken ct = default(CancellationToken));
    }
}
