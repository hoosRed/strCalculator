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
            var strArray = input.Split(",");

            // only support two values
            if (strArray.Length > 2)
            {
                Console.WriteLine("Input string is too long");
                return "";
            }

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
