using ButterflySystems.API.Controllers.V2;
using ButterflySystems.Core.Services.Contracts;
using ButterflySystems.Models.DTOs;
using ButterflySystems.Models.Enums;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;


namespace ButterflySystems.API.Tests.Controllers.V2
{
    public class CalculatorControllerTests
    {
        private readonly CalculatorController _calculatorController;
        private readonly Mock<IMathStrategy> _mathStrategy;

        public CalculatorControllerTests()
        {
            _mathStrategy = new Mock<IMathStrategy>();
            _calculatorController = new CalculatorController(_mathStrategy.Object);
        }

        [Fact]
        public async Task WhenAddActionIsCalledMathStrategyCalculateMethodIsCalled()
        {
            // Arrange
            var request = new CalculationRequest
            {
                Number1 = 1,
                Number2 = 2
            };


            // Act
            await _calculatorController.Add(request, CancellationToken.None);

            // Assert
            _mathStrategy.Verify(u => u.Calculate(request, Operator.Add, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task WhenSubtractActionIsCalledMathStrategyCalculateMethodIsCalled()
        {
            // Arrange
            var request = new CalculationRequest
            {
                Number1 = 1,
                Number2 = 2
            };

            // Act
            await _calculatorController.Subtract(request, CancellationToken.None);

            // Assert
            _mathStrategy.Verify(u => u.Calculate(request, Operator.Subtract, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task WhenMultiplyActionIsCalledMathStrategyCalculateMethodIsCalled()
        {
            // Arrange
            var request = new CalculationRequest
            {
                Number1 = 1,
                Number2 = 2
            };

            // Act
            await _calculatorController.Multiply(request, CancellationToken.None);

            // Assert
            _mathStrategy.Verify(u => u.Calculate(request, Operator.Multiply, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task WhenDivideActionIsCalledMathStrategyCalculateMethodIsCalled()
        {
            // Arrange
            var request = new CalculationRequest
            {
                Number1 = 1,
                Number2 = 2
            };

            // Act
            await _calculatorController.Divide(request, CancellationToken.None);

            // Assert
            _mathStrategy.Verify(u => u.Calculate(request, Operator.Divide, CancellationToken.None), Times.Once);
        }

    }
}