using System;
using System.Collections.Generic;
using System.Text;

namespace ButterflySystems.Core.Services.Contracts
{
    /// <summary>
    /// IMathStrategyFactory is used to initialize all the implementation of IMathOperator
    /// </summary>
    public interface IMathStrategyFactory
    {
        /// <summary>
        /// Asp Core IoC container will use this method to inject IMathOperator[] type.
        /// </summary>
        /// <returns></returns>
        IMathOperator[] Create();
    }
}
