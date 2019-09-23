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

            // single character delimiter
            var singleCharDelimiter = str[0];
            if(!Char.IsNumber(singleCharDelimiter))
            {
                standardDelimiters.Add(singleCharDelimiter.ToString());    
            }

            // custom delimiter inside []
            var customDelimiter = Regex.Matches(str, @"(?<=\[).+?(?=\])")
                .Cast<Match>()
                .Select(m => m.Groups[0].Value)
                .ToList();

            // add custom delimiters to list
            var allDelimiters = standardDelimiters.Concat(customDelimiter).ToArray();

            return allDelimiters;
        }
    }
}
