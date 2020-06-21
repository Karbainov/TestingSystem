using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Business.Tests.Mocks;

namespace TestingSystem.Business.Tests
{
    class StringConverterTest
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void CreateListFromStringTest(int num)
        {
            CreateListFromStringMock mock = new CreateListFromStringMock();
            StringConverter converter = new StringConverter();
            List<string> actual = converter.CreateListFromString(mock.GetActual(num));
            CollectionAssert.AreEqual(mock.GetExpected(num), actual);
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void CreateArrayFromStringTest(int num)
        {
            CreateArrayFromStringMock mock = new CreateArrayFromStringMock();
            StringConverter converter = new StringConverter();
            string[] actual = converter.CreateArrayFromString(mock.GetActual(num));
            CollectionAssert.AreEqual(mock.GetExpected(num), actual);
        }
    }
}
