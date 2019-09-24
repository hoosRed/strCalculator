using System;
using strCalculator;
using Xunit;

namespace StrCalculatorTests
{
    public class CalculatorMultiplyServiceTests
    {
        /// <summary>
        ///     Calculator Multiply Tests
        /// </summary>
        /// <param name="inputString">Input string.</param>
        /// <param name="expectedOutput">Expected output.</param>
        [Theory]
        [InlineData("2,2", "2*2 = 4")]
        [InlineData("2,4,rrrr,1001,6", "2*4*6 = 48")]
        public void CalculatorMultiplyTest(string inputString, string expectedOutput)
        {
            // Arrange 
            var calculatorMultiplyService = new CalculatorMultiplyService();

            // Act
            var actualOutput = calculatorMultiplyService.Execute(inputString);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        /// <summary>
        ///     Testing inclusion of Max Value and negative number parameters
        /// </summary>
        /// <param name="inputString">Input string.</param>
        /// <param name="expectedOutput">Expected output.</param>
        [Theory]
        [InlineData("2000,-2", "2000*-2 = -4000")]
        [InlineData("6000,-2", "-2 = -2")]
        public void CalculatorMultiplyNegativeTest(string inputString, string expectedOutput)
        {
            // Arrange 
            var calculatorMultiplyService = new CalculatorMultiplyService();

            // Act
            var actualOutput = calculatorMultiplyService.Execute(inputString, true, 5000);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
