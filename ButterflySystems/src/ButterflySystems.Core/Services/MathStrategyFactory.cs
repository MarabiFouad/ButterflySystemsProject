using ButterflySystems.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ButterflySystems.Core.Services
{
    public class MathStrategyFactory : IMathStrategyFactory
    {
        private readonly AddOperator _addOperator;
        private readonly SubtractOperator _subtractOperator;
        private readonly MultiplyOperator _multiplyOperator;
        private readonly DivideOperator _divideOperator;

        public MathStrategyFactory(
            AddOperator addOperator,
            SubtractOperator subtractOperator,
            MultiplyOperator multiplyOperator,
            DivideOperator divideOperator)
        {
            _addOperator = addOperator;
            _subtractOperator = subtractOperator;
            _multiplyOperator = multiplyOperator;
            _divideOperator = divideOperator;
        }

        public IMathOperator[] Create() => new IMathOperator[] { _addOperator, _subtractOperator, _multiplyOperator, _divideOperator };

    }
}
