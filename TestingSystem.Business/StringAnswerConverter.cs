using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingSystem.Business
{
    public class StringAnswerConverter
    {
        public string ConvertThirdType(string input)
        {
            input = RemoveWhitespace(input);
            input = input.ToLower();

            return input;
        }

        public string ConvertFourthType(string input)
        {
            input = RemoveNonLetterChars(input);
            input = RemoveWhitespace(input);
            input = input.ToLower();
            
            return input;
        }

        public string RemoveWhitespace(string str)
        {
            return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }

        public string RemoveNonLetterChars(string str)
        {
            return new string((from c in str
                               where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                               select c
                               ).ToArray());
        }
    }
}
