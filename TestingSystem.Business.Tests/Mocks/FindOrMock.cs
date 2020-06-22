using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Business.Tests.Mocks
{
    class FindOrMock
    {
        public string GetActual(int num)
        {

            switch (num)
            {
                case 1:
                    return "Массивы,Рекурсия";
                case 2:
                    return " ";
            }
            return null;
        }
        public List<TestQuestionTagDTO> GetExpected(int num)
        {
            switch (num)
            {
                case 1:
                    return new List<TestQuestionTagDTO>()
                    {
                        new TestQuestionTagDTO (5,"Тест на написание методов",new TimeSpan(36000000000),75,10)
                        {
                            ID =5,
                        }
                        ,
                        new TestQuestionTagDTO (6,"Математика массивов",new TimeSpan(36000000000),85,10)
                    };
                case 2:
                    return new List<TestQuestionTagDTO>();
            }
            return null;
        }
    }
}
