using Microsoft.VisualBasic.CompilerServices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Tests
{
    public class StringAnswerTests
    {
        StringAnswerConverter stringAnswerConverter = new StringAnswerConverter();

        [TestCase ("Hello", ExpectedResult = "Hello")]
        [TestCase ("Ghbdtn ghbdtn привет", ExpectedResult = "Ghbdtn ghbdtn привет")]
        [TestCase ("", ExpectedResult = "")]
        [TestCase (" ", ExpectedResult = " ")]
        [TestCase ("Hel(l)o'", ExpectedResult = "Hello")]
        [TestCase ("П;р'и%&*в#е@т", ExpectedResult = "Привет")]
        public string RemoveNonLetterCharsTest(string s)
        {
            return stringAnswerConverter.RemoveNonLetterChars(s);
        }

        [TestCase (" Hello", ExpectedResult = "Hello")]
        [TestCase (" H el lo", ExpectedResult = "Hello")]
        [TestCase (" ", ExpectedResult = "")]
        [TestCase ("", ExpectedResult = "")]
        [TestCase ("Oh, hi Mark!", ExpectedResult = "Oh,hiMark!")]
        [TestCase ("           MyM m", ExpectedResult = "MyMm")]
        public string RemoveWhitespaceTest(string s)
        {
            return stringAnswerConverter.RemoveWhitespace(s);
        }

        [TestCase ("", ExpectedResult = "")]
        [TestCase (" ", ExpectedResult = "")]
        [TestCase ("Hello;''", ExpectedResult = "hello")]
        [TestCase ("Привет, мир!", ExpectedResult = "приветмир")]
        [TestCase ("%%%  ex{PecTeD :::", ExpectedResult = "expected")]
        public string ConvertFourthTypeTest(string s)
        {
            return stringAnswerConverter.ConvertFourthType(s);
        }

        [TestCase(" Hello", ExpectedResult = "Hello")]
        [TestCase(" H el lo", ExpectedResult = "Hello")]
        [TestCase(" ", ExpectedResult = "")]
        [TestCase("", ExpectedResult = "")]
        [TestCase("Oh, hi Mark!", ExpectedResult = "Oh,hiMark!")]
        [TestCase("           MyM m", ExpectedResult = "MyMm")]
        public string ConvertThirdTypeTest(string s)
        {
            return stringAnswerConverter.ConvertThirdType(s);
        }

        [TestCase ("Hello", "hello", 4, ExpectedResult = true)]
        [TestCase ("int i = 7;", "int i = 7;", 3, ExpectedResult = true)]
        [TestCase ("[testCase]", "[TestCase]", 3, ExpectedResult = false)]
        [TestCase ("ПолиМорФизм!", "полиморфизм", 4, ExpectedResult = true)]
        [TestCase ("", "hello", 4, ExpectedResult = false)]
        [TestCase (" ", " ", 3, ExpectedResult = true)]
        [TestCase ("", "", 4, ExpectedResult = true)]
        [TestCase ("/  ", "/", 4, ExpectedResult = true)]
        [TestCase ("Абстрактный кактус", "Абстрактный класс", 3, ExpectedResult = false)]
        public bool CheckCorrectAnswerTests(string ans, string correctAns, int QuestionType)
        {
            return stringAnswerConverter.CheckCorrectAnswer(ans, correctAns, QuestionType);
        }
    }
}
