using ButterflySystems.API.Controllers.V1;
using ButterflySystems.API.Middlewares;
using ButterflySystems.Core.Services.Contracts;
using ButterflySystems.Models.Enums;
using ButterflySystems.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using ButterflySystems.Core.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Builder;
using ButterflySystems.Core.IoC;
using System.Net;

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