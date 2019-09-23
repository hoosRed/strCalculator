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
        ///     Tests that string can only contain two entries
        /// </summary>
        [Fact]
        public void TestInvalidStringAdd()
        {
            // Arrange
            var fakeString = "1,5000,3";
            var calculatorAddService = new CalculatorAddService();
            var expectedSum = "";

            // Act
            var actualSum = calculatorAddService.Execute(fakeString);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }
    }
}
