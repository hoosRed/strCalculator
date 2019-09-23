using System;
using strCalculator;
using Xunit;

namespace StrCalculatorTests
{
    public class CalculatorAddServiceTests
    {
        /// <summary>
        ///     Calculator Addition Tests
        /// </summary>
        /// <param name="inputString">Input string</param>
        /// <param name="expectedOutput">Expected output</param>
        [Theory]
        [InlineData("20", "20")]
        [InlineData("5,tytyt", "5")]
        [InlineData("1,2,3,4,5,6,7,8,9,10,11,12", "78")]
        [InlineData("1\n2,3", "6")]
        [InlineData("2,1001,6", "8")]
        [InlineData(";\n2;5", "7")]
        public void CalculatorAddTest(string inputString, string expectedOutput)
        {
            // Arrange 
            var calculatorAddService = new CalculatorAddService();

            // Act
            var actualOutput = calculatorAddService.Execute(inputString);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        /// <summary>
        ///     Test that exception is thrown for negative numbers
        /// </summary>
        [Theory]
        [InlineData(";-1,0,1", "-1")]
        [InlineData(";-1,-2,1", "-1, -2")]
        public void FormatExceptionTest(string invalidInput, string negativeNumbers)
        {
            // Arrange
            var calculatorAddService = new CalculatorAddService();

            // Act
            var mockException = Assert.Throws<FormatException>(() => calculatorAddService.Execute(invalidInput));

            // Assert
            Assert.Equal("Negative numbers are invalid: " + negativeNumbers, mockException.Message);
        }
    }
}
