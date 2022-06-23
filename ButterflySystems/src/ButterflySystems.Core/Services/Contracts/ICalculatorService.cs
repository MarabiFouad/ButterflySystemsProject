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
    /// In case of database calls, http calls or ORMs it is better to pass the cancellation token to inner layer in order to save resources
    /// </summary>
    public interface ICalculatorService
    {
        /// <summary>
        /// Add two decimal numbers
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CalculationResponse> Add(decimal number1, decimal number2, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Subtract two decimal numbers
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CalculationResponse> Subtract(decimal number1, decimal number2, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Multiply two decimal numbers
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CalculationResponse> Multiply(decimal number1, decimal number2, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Divide two decimal numbers
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CalculationResponse> Divide(decimal number1, decimal number2, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Build the response with provided parameters
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="operator"></param>
        /// <returns></returns>
        CalculationResponse FormatResponse(decimal result, decimal number1, decimal number2, CalculatorOperator @operator);

    }
}
