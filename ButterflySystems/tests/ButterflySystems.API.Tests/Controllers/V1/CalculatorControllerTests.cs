using ButterflySystems.API.Controllers.V1;
using ButterflySystems.Core.Services.Contracts;
using ButterflySystems.Models.DTOs;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;


namespace ButterflySystems.API.Tests.Controllers.V1
{
    public class CalculatorControllerTests
    {
        private readonly CalculatorController _calculatorController;
        private readonly Mock<ICalculatorService> _calculatorService;

        public CalculatorControllerTests()
        {
            _calculatorService = new Mock<ICalculatorService>();
            _calculatorController = new CalculatorController(_calculatorService.Object);
        }

        [Fact]
        public async Task WhenAddActionIsCalledCalculatorServiceAddMethodIsCalled()
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
            _calculatorService.Verify(u => u.Add(request, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task WhenSubtractActionIsCalledCalculatorServiceSubtractMethodIsCalled()
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
            _calculatorService.Verify(u => u.Subtract(request, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task WhenMultiplyActionIsCalledCalculatorServiceMultiplyMethodIsCalled()
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
            _calculatorService.Verify(u => u.Multiply(request, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task WhenDivideActionIsCalledCalculatorServiceDivideMethodIsCalled()
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
            _calculatorService.Verify(u => u.Divide(request, CancellationToken.None), Times.Once);
        }

    }
}