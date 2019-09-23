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
            if(!Char.IsNumber(singleCharDelimiter) && singleCharDelimiter != '[')
            {
                standardDelimiters.Add(singleCharDelimiter.ToString());    
            }

            // custom delimiter inside []
            var customDelimiters = Regex.Matches(str, @"(?<=\[).+?(?=\])")
                .Cast<Match>()
                .Select(m => m.Groups[0].Value)
                .ToList();

            // input string should split on "[*]" in addition to "*"
            var additionalDelimiters = new List<string>();
            foreach (var d in customDelimiters)
            {
                additionalDelimiters.Add("[" + d + "]");    
            }

            // Concatenate all 3 delimiter lists
            var allDelimiters = standardDelimiters.Concat(customDelimiters.Concat(additionalDelimiters)).ToArray();

            return allDelimiters;
        }
    }
}
