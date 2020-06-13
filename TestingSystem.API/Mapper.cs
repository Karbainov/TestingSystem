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
        //список тестов
        public TestOutputModel TestDTOToTestOutputModel(TestDTO testDTO)  
        {
            return new TestOutputModel()
            {
                ID = testDTO.ID,
                Name = testDTO.Name,
                //SuccessScore = testDTO.SuccessScore,
                //DurationTime = testDTO.DurationTime,
                //QuestionNumber = testDTO.QuestionNumber,
            };
        }

        public List<TestOutputModel> TestDTOToTestModelList(List<TestDTO> dtoList) //формирует список тестов
        {
            List<TestOutputModel> modelList = new List<TestOutputModel>();
            foreach(TestDTO testDTO in dtoList)
            {
                modelList.Add(TestDTOToTestOutputModel(testDTO));
            }
            return modelList;
        }

        //список тестов, найденных по тэгам
        public TestOutputModel SearchTestByTagDTOToTestOutputModel (SearchTestByTagDTO searchTestByTagDTO) 
        {
            return new TestOutputModel()
            {
                ID = searchTestByTagDTO.Id,
                Name = searchTestByTagDTO.Name,                
            };
        }

        public List<TestOutputModel> SearchTestByTagDTOToTestModelList(List<SearchTestByTagDTO> dtoList) 
        {
            List<TestOutputModel> modelList = new List<TestOutputModel>();
            foreach (SearchTestByTagDTO searchtestDTO in dtoList)
            {
                modelList.Add(SearchTestByTagDTOToTestOutputModel(searchtestDTO));
            }
            return modelList;
        }
    }
}
