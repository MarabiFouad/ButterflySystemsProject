using ButterflySystems.Models.DTOs;
using ButterflySystems.Models.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace ButterflySystems.Core.Services.Contracts
{
    /// <summary>
    /// In case of database calls, http calls or ORMs it is better to pass the cancellation token to inner layer in order to save resources
    /// </summary>
    public interface ICalculatorService
    {
        /// <summary>
        /// Add two nymbers
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CalculationResponse> Add(CalculationRequest request, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Subtract two numbers
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CalculationResponse> Subtract(CalculationRequest request, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Multiply two numbers
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CalculationResponse> Multiply(CalculationRequest request, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Divide two numbers
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CalculationResponse> Divide(CalculationRequest request, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///  Create CalculationResponse response with provided parameters
        /// </summary>
        /// <param name="result"></param>
        /// <param name="request"></param>
        /// <param name="operator"></param>
        /// <returns></returns>
        CalculationResponse FormatResponse(decimal result, CalculationRequest request, Operator @operator);

    }
}
