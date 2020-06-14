using System;
using System.Collections.Generic;
using TestingSystem.Data.DTO;
using TestingSystem.Data.StoredProcedure.CRUD;

namespace TestingSystem.Business
{
    public class FindBy4AndMoreTags
    {
        public TestDTO Find(List<String> tags)
        {
            TagCRUD tagCRUD = new TagCRUD();
            List<TagDTO> tagDTOs = tagCRUD.GetAll();
            TestTagCRUD testTagCRUD = new TestTagCRUD();
            List<TestTagDTO> testTagDTOs = testTagCRUD.GetAll();
            List<Ts> tests = new List<Ts>();
            bool isadd = false;
            foreach (TestTagDTO a in testTagDTOs)
            {
                isadd = false;

                foreach (Ts b in tests)
                {
                    if (b.TestID == a.TestID)
                    {
                        b.TagsID.Add(a.TagID);
                        isadd = true;
                    }
                }
                if (!isadd)
                {
                    Ts newTs = new Ts();
                    newTs.TestID = a.TestID;
                    newTs.TagsID.Add(a.TagID);
                    tests.Add(newTs);
                }
            }

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
            List<int> testId = new List<int>();


            foreach (Ts a in tests)
            {
                bool isFind = true;
                for (int i = 0; i < tagId.Count; i++)
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

            TestCRUD testCRUD = new TestCRUD();
            TestDTO dTO = testCRUD.GetById(tests[0].TestID);
            return dTO;

        }

    }
    public class Ts
    {
        public int TestID { get; set; }
        public List<int> TagsID { get; set; }
    }
}
