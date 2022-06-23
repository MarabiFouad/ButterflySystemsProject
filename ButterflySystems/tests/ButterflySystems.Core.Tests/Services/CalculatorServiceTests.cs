using ButterflySystems.Core.Services;
using ButterflySystems.Core.Services.Contracts;
using ButterflySystems.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ButterflySystems.Core.Tests.Services
{
    public class CalculatorServiceTests
    {
        private readonly ICalculatorService _calculatorService;
        public CalculatorServiceTests()
        {
            _calculatorService = new CalculatorService();
        }

        [Fact]
        public async Task Add()
        {
            // arrange
            decimal number1 = 1;
            decimal number2 = 2;
            decimal expected = 3;

            //act
            var actual = await _calculatorService.Add(number1, number2);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Result);
        }
        public static IEnumerable<object[]> AddTestData =>
            new[] {
                new object[] { 1m, 2m, 3m },
                new object[] { 5.6, 6.3, 11.9 },
                new object[] { 10, 12, 22 },
                new object[] { 30, 53.2m, 83.2 },
                new object[] { decimal.MaxValue, 0, decimal.MaxValue }
            };

        [Theory]
        [MemberData(nameof(AddTestData))]
        public async Task AddTwoNumbersShouldReturnExpectedValue(decimal number1, decimal number2, decimal expected)
        {
            // arrange

            //act
            var actual = await _calculatorService.Add(number1, number2);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Result);
        }

        [Fact]
        public async Task Subtract()
        {
            // arrange
            decimal number1 = 1;
            decimal number2 = 2;
            decimal expected = -1;

            //act
            var actual = await _calculatorService.Subtract(number1, number2);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Result);

        }

        public static IEnumerable<object[]> SubtractTestData => new[] {
                                                                 new object[] { 1m, 2m, -1m },
                                                                 new object[] { 5.6, 6.3, -0.7 },
                                                                 new object[] { 10, 12, -2 },
                                                                 new object[] { 30, 53.2m, -23.2 },
                                                                 new object[] { decimal.MaxValue, 0, decimal.MaxValue },
                                                                 new object[] { decimal.MaxValue, decimal.MaxValue, 0 },
                                                                 new object[] { 0, decimal.MaxValue, -decimal.MaxValue }
                                                                 };

        [Theory]
        [MemberData(nameof(SubtractTestData))]
        public async Task SubtractTwoNumbersShouldReturnExpectedValue(decimal number1, decimal number2, decimal expected)
        {
            // arrange

            //act
            var actual = await _calculatorService.Subtract(number1, number2);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Result);
        }

        [Fact]
        public async Task Multiply()
        {
            // arrange
            decimal number1 = 1;
            decimal number2 = 2;
            decimal expected = 2;

            //act
            var actual = await _calculatorService.Multiply(number1, number2);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Result);

        }

        public static IEnumerable<object[]> MultiplyTestData => new[] {
                                                                 new object[] { 1m, 2m, 2m },
                                                                 new object[] { 5.6, 6.3, 35.28 },
                                                                 new object[] { 10, -12, -120 },
                                                                 new object[] { 30, 53.2m, 1596 },
                                                                 new object[] { decimal.MaxValue, 0, 0 },
                                                                 new object[] { decimal.MaxValue, 1, decimal.MaxValue }
                                                                 };

        [Theory]
        [MemberData(nameof(MultiplyTestData))]
        public async Task MultiplyTwoNumbersShouldReturnExpectedValue(decimal number1, decimal number2, decimal expected)
        {
            // arrange

            //act
            var actual = await _calculatorService.Multiply(number1, number2);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Result);
        }


        [Fact]
        public async Task MultiplyTwoLargeNumbersWithLargeResultShouldThrowsOverflowException()
        {
            // arrange
            decimal number1 = decimal.MaxValue;
            decimal number2 = decimal.MaxValue;

            //act
            Func<Task> act = async () => await _calculatorService.Multiply(number1, number2);

            //Assert
            await Assert.ThrowsAsync<OverflowException>(act);
        }

        [Fact]
        public async Task Divide()
        {
            // arrange
            decimal number1 = 1;
            decimal number2 = 2;
            decimal expected = 0.5m;

            //act
            var actual = await _calculatorService.Divide(number1, number2);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Result);

        }

        public static IEnumerable<object[]> DivideTestData => new[] {
                                                                 new object[] { 1m, 2m, 0.5m },
                                                                 new object[] { 12, 3, 4 },
                                                                 new object[] { 10, -5, -2 },
                                                                 new object[] { 12.5, 2,6.25 },
                                                                 new object[] { decimal.MaxValue, decimal.MaxValue, 1 }
                                                                 };

        [Theory]
        [MemberData(nameof(DivideTestData))]
        public async Task DivideTwoNumbersShouldReturnExpectedValue(decimal number1, decimal number2, decimal expected)
        {
            // arrange

            //act
            var actual = await _calculatorService.Divide(number1, number2);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Result);
        }

        [Fact]
        public async Task DivideByZeroShouldReturnDivideByZeroError()
        {
            // arrange
            decimal number1 = 1;
            decimal number2 = 0;

            //act
            Func<Task> act = async () => await _calculatorService.Divide(number1, number2);

            //Assert
            var ex = await Assert.ThrowsAsync<ButterflySystemsException>(act);

            Assert.Equal("Divide by zero error.", ex.Message);

        }

    }
}