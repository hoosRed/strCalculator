using System;
using System.Collections.Generic;
using System.Linq;

namespace strCalculator
{
    /// <summary>
    ///     Calculator Add Service
    /// </summary>
    public class CalculatorAddService : ICalculatorAddService
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

            var positiveNumbers = new List<int>();
            var negativeNumbers = new List<int>();

            foreach (var str in strArray)
            {
                int number;
                bool isValidNumber = Int32.TryParse(str, out number);

                if (isValidNumber && (number >= 0 || includeNegatives) && number < maxValue)
                {
                    positiveNumbers.Add(number);
                }
                else if (isValidNumber && number < 0)
                {
                    // populate list of negative numbers
                    negativeNumbers.Add(number);
                }
                else
                {
                    // parse failed - add placeholder
                    positiveNumbers.Add(0);
                }
            }

            // throw exception if negative numbers exist
            if (negativeNumbers.Count > 0)
            {
                var numString = string.Join(", ", negativeNumbers);

                FormatException e = new FormatException("Negative numbers are invalid: " + numString);
                throw e;
            }

            return BuildEquation(positiveNumbers);
        }

        /// <summary>
        ///     Prints equation 
        /// </summary>
        /// <returns>The equation</returns>
        /// <param name="numbers">Positive numbers parsed from string</param>
        private string BuildEquation(List<int> numbers)
        {
            var equation = string.Join("+", numbers);

            return equation + " = " + numbers.Sum();
        }
    }
}
