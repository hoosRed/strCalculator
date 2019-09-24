using System;
namespace strCalculator
{
    public interface ICalculatorAddService
    {
        string Execute(string input, bool includeNegatives = false, int maxValue = 1000);
    }
}
