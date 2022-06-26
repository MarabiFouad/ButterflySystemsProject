using ButterflySystems.Models.DTOs;
using ButterflySystems.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ButterflySystems.Core.Services.Contracts
{
    /// <summary>
    /// Client will not care about implementation and this allows for single responsibility
    /// </summary>
    public interface IMathStrategy
    {
        Task<CalculationResponse> Calculate(CalculationRequest request, Operator op, CancellationToken ct = default(CancellationToken));
    }
}
