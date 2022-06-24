using System;
using System.Collections.Generic;
using System.Text;

namespace ButterflySystems.Core.Services.Contracts
{
    public interface IMathStrategyFactory
    {
        IMathOperator[] Create();
    }
}
