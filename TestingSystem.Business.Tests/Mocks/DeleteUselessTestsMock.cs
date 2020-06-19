using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Tests.Mocks
{
    class DeleteUselessTestsMock
    {
        public List<TestTagsModel> GetModel(int num)
        {
            switch(num)
            {
                case 1:
                    return new List<TestTagsModel>()
                    {
                        new TestTagsModel()
                        {
                            TestID = 1,
                            TagsID = new List<int>(){1,2}
                        },
                        new TestTagsModel()
                        {
                            TestID = 2,
                            TagsID = new List<int>(){3,1}
                        },
                        new TestTagsModel()
                        {
                            TestID = 3,
                            TagsID = new List<int>(){2,1}
                        },
                        new TestTagsModel()
                        {
                            TestID = 4,
                            TagsID = new List<int>(){6,1}
                        }
                    };
            }
            return null;
        }
        public List<int> GetListOfInt(int num)
        {
            switch(num)
            {
                case 1:
                    return new List<int>() { 1, 2 };
            }
            return null;
        }
        public List<TestTagsModel> GetExspected(int num)
        {
            switch(num)
            {
                case 1:
                    return new List<TestTagsModel>()
                    {
                        new TestTagsModel()
                        {
                            TestID = 1,
                            TagsID = new List<int>(){1,2}
                        },
                        new TestTagsModel()
                        {
                            TestID = 3,
                            TagsID = new List<int>(){2,1}
                        }
                    };
            }
            return null;
        }
    }
}
