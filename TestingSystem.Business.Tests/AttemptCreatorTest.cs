using NUnit.Framework;
using System.Collections.Generic;
using TestingSystem.Business.Tests.Mocks;
using TestingSystem.Data.DTO;
using TestingSystem.Business;

namespace TestingSystem.Business.Tests
{
    public class AttemptCreatorTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [TestCase(10, 5, ExpectedResult = 5)]
        [TestCase(7, 3, ExpectedResult = 3)]

        public int GetRandomIndexesTest(int upRange, int quantity)
        {
            AttemptCreator index = new AttemptCreator();
            var indexes = index.GetRandomIndexes(upRange, quantity);
            return indexes.Count;

        }

        [TestCase(1,2,18)]
        [TestCase(2, 73, 158)]

        public void CreateListOfQuestionsTest(int condition, int userId, int testId)
        {
            AttemptCreatorMock newmock = new AttemptCreatorMock();
            List<QuestionWithListAnswersDTO> actual = newmock.GetExpected(condition);
            AttemptCreator creator = new AttemptCreator();
            List<QuestionWithListAnswersDTO> result =  creator.CreateListOfQuestions(userId, testId);
            int i = 0;
           
            foreach (var q in actual)
            {
                int j = 0;
                Assert.AreEqual(q.Id, result[i].Id);
                Assert.AreEqual(q.Question, result[i].Question);
                Assert.AreEqual(q.TypeID, result[i].TypeID);
                Assert.AreEqual(q.Weight, result[i].Weight);
                
                foreach (var a in q.Answers)
                {
                    Assert.AreEqual(a.AnswerId, result[i].Answers[j].AnswerId);
                    Assert.AreEqual(a.QuestionId, result[i].Answers[j].QuestionId);
                    Assert.AreEqual(a.Answer, result[i].Answers[j].Answer);
                    j++;                                     
                }
                i++;
            }

        }

        [TestCase(1,3,1,2,1)]
       
        public void CreateDictionaryTest(int condition, int count1, int count2, int count3, int count4)
        {

            AttemptCreatorMock mock = new AttemptCreatorMock();
            List<QuestionWithListAnswersDTO> questions = mock.GetExpected(condition);
            AttemptCreator creator = new AttemptCreator();
            var result = creator.CreateDictionary(questions);
            Assert.AreEqual(count1, result[1].Count);
            Assert.AreEqual(count2, result[2].Count);
            Assert.AreEqual(count3, result[4].Count);
            Assert.AreEqual(count4, result[5].Count);
        }
    }
}
