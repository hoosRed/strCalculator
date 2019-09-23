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
        [InlineData("5000,1", "5001")]
        [InlineData("5,tytyt", "5")]
        [InlineData("1,2,3,4,5,6,7,8,9,10,11,12", "78")]
        [InlineData("1\n2,3", "6")]
        public void CalculatorAddTest(string inputString, string expectedOutput)
        {
            // Arrange 
            var calculatorAddService = new CalculatorAddService();

            // Act
            var actualOutput = calculatorAddService.Execute(inputString);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
