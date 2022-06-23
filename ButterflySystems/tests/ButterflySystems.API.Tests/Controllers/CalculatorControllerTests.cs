using ButterflySystems.API.Controllers.V1;
using ButterflySystems.Core.Services.Contracts;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;


namespace ButterflySystems.API.Tests
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
            decimal number1 = 1;
            decimal number2 = 2;

            // Act
            await _calculatorController.Add(number1, number2, CancellationToken.None);

            // Assert
            _calculatorService.Verify(u => u.Add(number1, number2, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task WhenSubtractActionIsCalledCalculatorServiceSubtractMethodIsCalled()
        {
            // Arrange
            decimal number1 = 1;
            decimal number2 = 2;

            // Act
            await _calculatorController.Subtract(number1, number2, CancellationToken.None);

            // Assert
            _calculatorService.Verify(u => u.Subtract(number1, number2, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task WhenMultiplyActionIsCalledCalculatorServiceMultiplyMethodIsCalled()
        {
            // Arrange
            decimal number1 = 1;
            decimal number2 = 2;

            // Act
            await _calculatorController.Multiply(number1, number2, CancellationToken.None);

            // Assert
            _calculatorService.Verify(u => u.Multiply(number1, number2, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task WhenDivideActionIsCalledCalculatorServiceDivideMethodIsCalled()
        {
            // Arrange
            decimal number1 = 1;
            decimal number2 = 2;

            // Act
            await _calculatorController.Divide(number1, number2, CancellationToken.None);

            // Assert
            _calculatorService.Verify(u => u.Divide(number1, number2, CancellationToken.None), Times.Once);
        }

    }
}