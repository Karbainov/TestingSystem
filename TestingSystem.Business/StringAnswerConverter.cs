using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestingSystem.Business
{
    public class StringAnswerConverter
    {
        public bool CheckCorrectAnswer(string answer, string correctAnswer)
        {
            if (answer.Length == correctAnswer.Length)
            {
                char[] answerArr = answer.ToArray();
                char[] corrAnsArr = correctAnswer.ToArray();

                for (int i = 0; i < corrAnsArr.Length; i++)
                {
                    if (corrAnsArr[i] != answerArr[i])
                        return false;
                }

                return true;
            }

            return false;
        }

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
