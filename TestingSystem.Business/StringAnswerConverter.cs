using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business
{
    public class StringAnswerConverter
    {
        public string ConvertThirdType(string input)
        {
            
            return input;
        }

        public static string RemoveWhitespace(string str)
        {
            return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
