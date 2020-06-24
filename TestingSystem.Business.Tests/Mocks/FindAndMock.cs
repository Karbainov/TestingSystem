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
        public List<TestQuestionTagDTO> GetExpected(int num)
        {
            switch(num)
            {
                case 1:
                    return new List<TestQuestionTagDTO>()
                    {
                        new TestQuestionTagDTO ()
                        {
                            ID = 5,
                            Name = "Тест на написание методов",
                            DurationTime = new TimeSpan(36000000000),
                            QuestionNumber = 10,
                            SuccessScore = 75,
                            Tags = new List<TagWithTestIDDTO>()
                            {
                                new TagWithTestIDDTO()
                                {
                                    IDtest = 5,
                                    TagID =4,
                                    Name ="Массивы"
                                },
                                new TagWithTestIDDTO()
                                {
                                    IDtest = 5,
                                    TagID=5,
                                    Name ="Рекурсия"
                                },
                                new TagWithTestIDDTO()
                                {
                                    IDtest = 5,
                                    TagID=20,
                                    Name ="ООП"
                                }

                            },
                            Questions = new List<QuestionForOneToManyDTO>()
                            {
                                new QuestionForOneToManyDTO()
                                {
                                    QuestionID =0,
                                    TestID= 5,
                                    Value="Сколько будет 1000г ?",
                                    AnswersCount = 0,
                                    
                                    Weight = 10
                                }
                            }
                        }

                    };
                case 2:
                    return new List<TestQuestionTagDTO>()
                    {
                    };
            }
            return null;
        }
    }
}
