using System;
using System.Collections.Generic;
using System.Linq;

namespace strCalculator
{
    /// <summary>
    ///     Calculator Add Service
    /// </summary>
    public class CalculatorAddService : BaseMathService, ICalculatorAddService
    {
        /// <summary>
        ///     Execute Addition
        /// </summary>
        /// <returns>String containing sum of input string</returns>
        /// <param name="input">Input string</param>
        public string Execute(string input, bool includeNegatives = false, int maxValue = 1000)
        {
            // build array of all delimiters
            var delimiters = input.GetDelimiters();

            // input string excluding delimiters
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
        /// <param name="numbers">Valid numbers parsed from string</param>
        private string BuildEquation(List<int> numbers)
        {
            var equation = string.Join("+", numbers);

            return equation + " = " + numbers.Sum();
        }
    }
}
