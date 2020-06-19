using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Business.Tests.Mocks
{
    public class FindMock
    {
        public string GetActual(int num)
        {
            
            switch(num)
            {
                case 1:
                    return "Массивы,Рекурсия";
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
                        new TestDTO (5,"Тест на написание методов",new TimeSpan(0,1,0,0,0),75,10)
                    };
            }
            return null;
        }
    }
}
