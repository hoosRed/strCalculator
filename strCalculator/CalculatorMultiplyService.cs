using System;
using System.Collections.Generic;
using System.Linq;

namespace strCalculator
{
    /// <summary>
    ///     Calculator multiply service.
    /// </summary>
    public class CalculatorMultiplyService : MathService, ICalculatorMultiplyService
    {
        public string Execute(string input, bool includeNegatives = false, int maxValue = 1000)
        {
            var delimiters = input.GetDelimiters();

            var strArray = input
                .Split(delimiters, StringSplitOptions.None)
                .Where(c => !String.IsNullOrWhiteSpace(c));

            var validNumbers = GetValidNumbers(strArray.ToArray(), includeNegatives, maxValue);

            return BuildEquation(validNumbers);
        }


        /// <summary>
        ///     Prints equation 
        /// </summary>
        /// <returns>The equation</returns>
        /// <param name="numbers">Positive numbers parsed from string</param>
        private string BuildEquation(List<int> numbers)
        {
            // build equation string
            var nonZeroNumbers = numbers.Where(n => n != 0);
            var equation = string.Join("*", nonZeroNumbers);

            // conduct muliplication
            var product = 1;

            foreach (var num in nonZeroNumbers)
            {
                product *= num;
            }
            return equation + " = " + product;
        }
    }
}