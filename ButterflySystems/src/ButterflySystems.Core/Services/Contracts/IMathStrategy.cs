using ButterflySystems.Models.DTOs;
using ButterflySystems.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ButterflySystems.Core.Services.Contracts
{
    public interface IMathStrategy
    {
        Task<CalculationResponse> Calculate(decimal number1, decimal number2, Operator op, CancellationToken ct = default(CancellationToken));
    }
}
