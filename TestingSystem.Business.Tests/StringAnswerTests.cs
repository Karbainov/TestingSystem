using Microsoft.VisualBasic.CompilerServices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Tests
{
    public class StringAnswerTests
    {
        [TestCase ("Hello", ExpectedResult = "Hello")]
        [TestCase ("Ghbdtn ghbdtn привет", ExpectedResult = "Ghbdtn ghbdtn привет")]
        [TestCase ("", ExpectedResult = "")]
        [TestCase (" ", ExpectedResult = " ")]
        [TestCase ("Hel(l)o'", ExpectedResult = "Hello")]
        [TestCase ("П;р'и%&*в#е@т", ExpectedResult = "Привет")]
        public string RemoveNonLetterCharsTest(string s)
        {
            StringAnswerConverter stringAnswerConverter = new StringAnswerConverter();

            return stringAnswerConverter.RemoveNonLetterChars(s);
        }
    }
}
