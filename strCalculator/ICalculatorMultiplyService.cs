using System;
namespace strCalculator
{
    /// <summary>
    ///     Marker interface for Multiply Service
    /// </summary>
    public interface ICalculatorMultiplyService
    {
        string Execute(string input, bool includeNegatives = false, int maxValue = 1000);
    }
}
