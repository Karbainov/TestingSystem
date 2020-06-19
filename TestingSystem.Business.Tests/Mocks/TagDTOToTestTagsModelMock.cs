using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Business.Tests
{
    public class TagDTOToTestTagsModelMock
    {
        public List<TestTagsModel> GetExpected(int num)
        {
            List<TestTagsModel> models;
            switch (num)
            {
                case 1:
                    models = new List<TestTagsModel>()
                    {
                        new TestTagsModel()
                        {
                            TestID = 1,
                            TagsID = new List<int>(){3,6}
                        },
                        new TestTagsModel()
                        {
                            TestID = 2,
                            TagsID = new List<int>(){2,5}
                        },
                        new TestTagsModel()
                        {
                            TestID = 3,
                            TagsID = new List<int>(){1,4}
                        }
                    };
                    return models;
                case 2:
                    models = new List<TestTagsModel>();
                    return models;
                case 3:
                    models = new List<TestTagsModel>() { new TestTagsModel() { TestID = 1, TagsID = new List<int>() { 1, 2 } } };
                    return models;
            }
            return null;
        }
        public List<TestTagDTO> GetActual(int num)
        {
            List<TestTagDTO> tests;
            switch (num)
            {
                case 1:
                    tests = new List<TestTagDTO>()
                    {
                        new TestTagDTO(1,1,3),
                        new TestTagDTO(2,1,6),
                        new TestTagDTO(3,2,2),
                        new TestTagDTO(4,2,5),
                        new TestTagDTO(5,3,1),
                        new TestTagDTO(6,3,4)
                    };
                    return tests;
                case 2:
                    tests = new List<TestTagDTO>();
                    return tests;
                case 3:
                    tests = new List<TestTagDTO>()
                    {
                        new TestTagDTO(1,1,1),
                        new TestTagDTO(1,1,2)
                    };
                    return tests;
            }
            return null;
        }
    }
}
