using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace strCalculator
{
    public static class CalculatorExtensions
    {
        public static string[] GetDelimiters(this String str)
        {
            List<string> standardDelimiters = new List<string> { ",", "\n" };

            // first character is always a new delimiter
            var userDelimiter = str[0];
            if(Char.IsNumber(userDelimiter))
            {
                return standardDelimiters.ToArray();    
            }
            else
            {
                standardDelimiters.Add(userDelimiter.ToString());
            }


            return standardDelimiters.ToArray();
        }
    }
}
