using NUnit.Framework;
using System.Collections.Generic;
using TestingSystem.Business.Tests.Mocks;
using TestingSystem.Data.DTO;

namespace TestingSystem.Business.Tests
{
    public class FindBy4AndMoreTagsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void FindTagsIDTest(int num)
        {
            FindTagsIDMock mock = new FindTagsIDMock();
            FindBy4AndMoreTags tags = new FindBy4AndMoreTags();
            List<int> actual = tags.FindTagsID(mock.GetTagDTOs(num), mock.GetTags(num));
            CollectionAssert.AreEqual(mock.GetExpected(num), actual);
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void TestTagDTOToTestTagsModelTest(int num)
        {
            TagDTOToTestTagsModelMock mock = new TagDTOToTestTagsModelMock();
            FindBy4AndMoreTags tags = new FindBy4AndMoreTags();
            List<TestTagsModel> actual= tags.TestTagDTOToTestTagsModel(mock.GetActual(num));
            int i = -1;
            foreach (var a in mock.GetExpected(num))
            {
                i++;
                Assert.AreEqual(a.TestID, actual[i].TestID);
                CollectionAssert.AreEqual(a.TagsID, actual[i].TagsID);
            }
        }
        [TestCase(1)]
        [TestCase(2)]
        public void FindAndTest(int num)
        {
            FindAndMock mock = new FindAndMock();
            FindBy4AndMoreTags tags = new FindBy4AndMoreTags();
            List<TestQuestionTagDTO> actual = tags.FindAnd(mock.GetActual(num));
            int i = -1;
            foreach(var a in mock.GetExpected(num))
            {
                i++;
                Assert.AreEqual(a.DurationTime, actual[i].DurationTime);
                Assert.AreEqual(a.ID, actual[i].ID);
                Assert.AreEqual(a.Name, actual[i].Name);
                Assert.AreEqual(a.QuestionNumber, actual[i].QuestionNumber);
                Assert.AreEqual(a.SuccessScore, actual[i].SuccessScore);
                
            }
            
        }
        [TestCase(1)]
        [TestCase(2)]
        public void FindOrTest(int num)
        {
            FindOrMock mock = new FindOrMock();
            FindBy4AndMoreTags tags = new FindBy4AndMoreTags();
            List<TestQuestionTagDTO> actual = tags.FindOr(mock.GetActual(num));
            int i = -1;
            foreach (var a in mock.GetExpected(num))
            {
                i++;
                Assert.AreEqual(a.DurationTime, actual[i].DurationTime);
                Assert.AreEqual(a.ID, actual[i].ID);
                Assert.AreEqual(a.Name, actual[i].Name);
                Assert.AreEqual(a.QuestionNumber, actual[i].QuestionNumber);
                Assert.AreEqual(a.SuccessScore, actual[i].SuccessScore);
            }
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void DeleteUselessTestsAndTest(int num)
        {
            DeleteUselessTestsAndMock mock = new DeleteUselessTestsAndMock();
            FindBy4AndMoreTags tags = new FindBy4AndMoreTags();
            List<TestTagsModel> actual = tags.DeleteUselessTestsAnd(mock.GetModel(num), mock.GetListOfInt(num));
            int i = -1;
            foreach (var a in mock.GetExspected(num))
            {
                i++;
                Assert.AreEqual(a.TestID, actual[i].TestID);
                CollectionAssert.AreEqual(a.TagsID, actual[i].TagsID);
            }
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void DeleteUselessTestsOrTest(int num)
        {
            DeleteUselessTestsOrMock mock = new DeleteUselessTestsOrMock();
            FindBy4AndMoreTags tags = new FindBy4AndMoreTags();
            List<TestTagsModel> actual = tags.DeleteUselessTestsOr(mock.GetModel(num), mock.GetListOfInt(num));
            int i = -1;
            foreach (var a in mock.GetExspected(num))
            {
                i++;
                Assert.AreEqual(a.TestID, actual[i].TestID);
                CollectionAssert.AreEqual(a.TagsID, actual[i].TagsID);
            }
        }

    }
}