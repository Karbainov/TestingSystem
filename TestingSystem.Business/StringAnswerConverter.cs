using System;
using System.Collections.Generic;
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

        public string RemoveWhitespace(string str)
        {
            return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
