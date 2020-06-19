using System;
using System.Collections.Generic;
using System.Linq;
using TestingSystem.Data.DTO;
using TestingSystem.Data.StoredProcedure.CRUD;

namespace TestingSystem.Business
{
    public class FindBy4AndMoreTags
    {
        public List<TestDTO> Find(string tag)
        {
            List<string> tags = CreateListFromString(tag);
            TagCRUD tagCRUD = new TagCRUD();
            List<TagDTO> tagDTOs = tagCRUD.GetAll();
            TestTagCRUD testTagCRUD = new TestTagCRUD();
            List<TestTagDTO> testTagDTOs = testTagCRUD.GetAll();
            List<TestTagsModel> tests = TestTagDTOToTestTagsModel(testTagDTOs);
            List<int> tagId = FindTagsID(tagDTOs, tags);
            tests = DeleteUselessTests(tests, tagId);
            return GetAllRightTests(tests);
        }
        public List<string> CreateListFromString(string tags)
        {
            for (int i = 0; i < tags.Length ; i++)
            {
                if(tags[i] ==' ')
                {
                    
                    tags =tags.Remove(i,1);
                    i--;
                }
            }
            for(int i = 0; i<tags.Length-1;i++)
            {
                if(tags[i]==','&&tags[i+1]==',')
                {
                    tags =tags.Remove(i);
                }
            }
            List<string> listOfTags = new List<string>(tags.Split(new char[] {','}).ToList<string>());
            return listOfTags;
        }
        public List<TestDTO> GetAllRightTests(List<TestTagsModel> models)
        {
            List<TestDTO> tests = new List<TestDTO>();
            TestCRUD testCRUD = new TestCRUD();
            foreach(TestTagsModel model in models)
            {
                tests.Add(testCRUD.GetById(model.TestID));
            }
            return tests;
        }
        public List<TestTagsModel> DeleteUselessTests(List<TestTagsModel> tests, List<int> tagId)
        {
            foreach (TestTagsModel a in tests)
            {
                bool isFind = true;
                for (int i = 0; i < tagId.Count-1; i++)
                {
                    if (!a.TagsID.Contains(tagId[i]))
                    {
                        isFind = false;
                    }
                }
                if (!isFind)
                {
                    tests.Remove(a);
                }
            }
            return tests;
        }
        public List<int> FindTagsID(List<TagDTO> tagDTOs, List<String> tags)
        {
            List<int> tagId = new List<int>();
            for (int i = 0; i < tags.Count; i++)
            {
                foreach (TagDTO a in tagDTOs)
                {
                    if (a.Name == tags[i])
                    {
                        tagId.Add(a.ID);
                    }
                }
            }
            return tagId;
        }
        public List<TestTagsModel> TestTagDTOToTestTagsModel(List<TestTagDTO> testTagDTOs)
        {
            List<TestTagsModel> tests = new List<TestTagsModel>();
            bool isadd ;
            foreach (TestTagDTO a in testTagDTOs)
            {
                isadd = false;

                foreach (TestTagsModel b in tests)
                {
                    if (b.TestID == a.TestID)
                    {
                        b.TagsID.Add(a.TagID);
                        isadd = true;
                    }
                }
                if (!isadd)
                {
                    TestTagsModel newTs = new TestTagsModel();
                    newTs.TestID = a.TestID;
                    newTs.TagsID = new List<int>();
                    newTs.TagsID.Add(a.TagID);
                    tests.Add(newTs);
                }
                
            }
            return tests;
        }
    }

}
