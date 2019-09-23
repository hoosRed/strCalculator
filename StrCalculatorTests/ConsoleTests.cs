using System;
using strCalculator;
using Xunit;

namespace StrCalculatorTests
{
    public class ConsoleTests
    {
        [Theory]
        [InlineData(new string[] { "Add", "1,2,3" }, "1+2+3 = 6")]
        [InlineData(new string[] { "Add", "2,4,rrrr,1001,6" }, "2+4+0+0+6 = 12")]
        public void CalculatorUIAddTest(string[] uiCommands, string expectedSum)
        {
            // Arrange 
            var consoleInterface = new FakeConsoleInterface(uiCommands);
            var calculatorAddService = new CalculatorAddService();

            var calculatorUI = new CalculatorController(consoleInterface, calculatorAddService);

            // Act
            calculatorUI.Run();

            // Assert
            Assert.Contains(expectedSum, consoleInterface.Output);
        }
    }
}
