using System;
using System.Collections.Generic;

namespace strCalculator
{
    /// <summary>
    ///     Abstract class for all Mathematical Operations
    /// </summary>
    public abstract class MathService
    {
        /// <summary>
        ///     Build list of Valid numbers. 
        ///     This logic is shared between all string calculator operations.
        /// </summary>
        /// <returns>The valid numbers.</returns>
        /// <param name="strArray">String array</param>
        /// <param name="includeNegatives">If set to <c>true</c> include negatives.</param>
        /// <param name="maxValue">Max value</param>
        public List<int> GetValidNumbers(string[] strArray, bool includeNegatives, int maxValue){

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

            // may include negative numbers if includesNegative is set to true
            return positiveNumbers;
        }
    }
}
