using System;
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

            var sum = 0;
            foreach (var str in strArray)
            {
                int number;
                bool isValidNumber = Int32.TryParse(str, out number);

                if (isValidNumber)
                {
                    sum += number;
                }
                else
                {
                    // invalid input    
                }
            }

            return sum.ToString();
        }
    }
}
