using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using TestingSystem.Business.Tests.Mocks;
using TestingSystem.Data.DTO;
using TestingSystem.Business;
using TestingSystem.Business.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace TestingSystem.Business.Tests
{
    public class AttemptCreatorTests
    {
        [SetUp]
        public void Setup()
        {
        }
                     

        [TestCase(2,18)]
        [TestCase(3,22)]
        [TestCase(1,24)]

        public void CreateListOfQuestionsTest(int userId, int testId)
        {
           
            AttemptCreator creator = new AttemptCreator();
            AttemptBusinessModel result1 = creator.CreateAttempt(userId, testId);
            AttemptBusinessModel result2 = creator.CreateAttempt(userId, testId);
            AttemptBusinessModel result3 = creator.CreateAttempt(userId, testId);

            string questions1= JsonSerializer.Serialize(result1.Questions);
            string questions2= JsonSerializer.Serialize(result2.Questions);
            string questions3= JsonSerializer.Serialize(result3.Questions);
            Assert.AreNotEqual(questions1, questions2, questions3);
           

        }

    }
}
