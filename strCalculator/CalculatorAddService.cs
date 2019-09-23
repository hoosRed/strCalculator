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
        public string Execute(string input)
        {
            // add support for newline as delimiter
            var delimiters = new string[] { ",", "\n" };

            var strArray = input.Split(delimiters, StringSplitOptions.None);

            var positiveNumbers = new List<int>();
            var negativeNumbers = new List<int>();

            foreach (var str in strArray)
            {
                int number;
                bool isValidNumber = Int32.TryParse(str, out number);

                if (isValidNumber && (number >= 0))
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

            return positiveNumbers.Sum().ToString();
        }
    }
}
