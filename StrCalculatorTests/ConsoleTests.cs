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
        [InlineData(new string[] { "Multiply", "2,4,rrrr,6" }, "2*4*6 = 48")]
        public void CalculatorUIAddTest(string[] uiCommands, string expectedOutput)
        {
            // Arrange 
            var consoleInterface = new FakeConsoleInterface(uiCommands);

            var calculatorUI = new CalculatorController(
                consoleInterface, 
                new CalculatorAddService(), 
                new CalculatorMultiplyService());

            // Act
            calculatorUI.Run();

            // Assert
            Assert.Contains(expectedOutput, consoleInterface.Output);
        }
    }
}
