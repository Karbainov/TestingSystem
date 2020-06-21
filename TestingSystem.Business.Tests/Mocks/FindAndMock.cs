using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Business.Tests.Mocks
{
    public class FindAndMock
    {
        public string GetActual(int num)
        {
            
            switch(num)
            {
                case 1:
                    return "Массивы,Рекурсия";
                case 2:
                    return " ";
            }
            return null;
        }
        public List<TestDTO> GetExpected(int num)
        {
            switch(num)
            {
                case 1:
                    return new List<TestDTO>()
                    {
                        new TestDTO (5,"Тест на написание методов",new TimeSpan(36000000000),75,10)
                    };
                case 2:
                    return new List<TestDTO>()
                    {
                        new TestDTO (1,"Математика массивов",new TimeSpan(36000000000),85,10),
                        new TestDTO (5,"Тест на написание методов",new TimeSpan(36000000000),75,10),
                        new TestDTO (6,"Математика массивов",new TimeSpan(36000000000),85,10)
                    };
            }
            return null;
        }
    }
}
