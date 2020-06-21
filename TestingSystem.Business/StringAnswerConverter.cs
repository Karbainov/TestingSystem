using System;
using System.Linq;

namespace TestingSystem.Business
{
    public class StringAnswerConverter
    {
        public bool CheckCorrectAnswer(string answer, string correctAnswer, int QuestionType)
        {
            if(QuestionType == 3)
            {
                answer = ConvertThirdType(answer);
                correctAnswer = ConvertThirdType(correctAnswer);
            }
            else if (QuestionType == 4)
            {
                answer = ConvertFourthType(answer);
                correctAnswer = ConvertFourthType(correctAnswer);
            }

            if (answer.Equals(correctAnswer))
                return true;
            return false;
        }

        public string ConvertThirdType(string input)
        {
            input = RemoveWhitespace(input);
            
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
