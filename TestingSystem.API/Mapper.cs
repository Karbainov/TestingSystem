using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingSystem.API.Models.Output;
using TestingSystem.Data.DTO;

namespace TestingSystem.API
{
    public class Mapper
    {
        public TestModel TestDTOToTestModel(TestDTO testDTO)
        {
            return new TestModel()
            {
                Id = testDTO.ID,
                Name = testDTO.Name,
                SuccessScore = testDTO.SuccessScore,
                DurationTime = testDTO.DurationTime,
            };
        }

        public List<TestModel> TestDTOToTestModelList(List<TestDTO> dtoList)
        {
            List<TestModel> modelList = new List<TestModel>();
            foreach(TestDTO testDTO in dtoList)
            {
                modelList.Add(TestDTOToTestModel(testDTO));
            }
            return modelList;
        }
    }
}
