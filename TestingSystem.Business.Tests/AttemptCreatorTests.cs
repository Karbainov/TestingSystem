using NUnit.Framework;
using System.Collections.Generic;
using TestingSystem.Business.Tests.Mocks;
using TestingSystem.Data.DTO;

namespace TestingSystem.Business.Tests
{
    public class AttemptCreatorTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [TestCase(10,5, ExpectedResult = 5 )]
        [TestCase(7, 3, ExpectedResult = 3)]

        public int GetRandomIndexesTest(int upRange, int quantity) 
        {
            AttemptCreator index = new AttemptCreator();
            var indexes = index.GetRandomIndexes(upRange, quantity);
            return indexes.Count;

        }
   

    }
}