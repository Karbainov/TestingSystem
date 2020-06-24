using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Business;
using TestingSystem.Data.DTO;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.StoredProcedure.CRUD;

namespace TestingSystem.Business.Tests
{
    public class AttemptCreatorMock
    {


        public List<QuestionWithListAnswersDTO> GetExpected(int condition)
        {
            switch (condition)
            {
                case 1:
                    return new List<QuestionWithListAnswersDTO>()  
                    {
                        new QuestionWithListAnswersDTO () // таких создать  10, веса 1...поле только weight
                        {
                            Id = 15,
                            Question = "Какой из вариантов поведенческий паттерн?",
                            TypeID = 1,
                            Weight = 1,

                            Answers = new List<AnswerWithoutCorrectnessDTO>()
                            {
                                new AnswerWithoutCorrectnessDTO()
                                {
                                    AnswerId = 21,
                                    QuestionId=15,
                                    Answer = "Стратегия",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 22,
                                    QuestionId= 15,
                                    Answer = "Адаптер",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 23,
                                     QuestionId= 15,
                                     Answer = "Абстракция",
                                }

                            }
                        },
                         new QuestionWithListAnswersDTO ()
                        {
                            Id = 16,
                            Question = "Массивы - это",
                            TypeID = 1,
                            Weight = 2,
                            Answers = new List<AnswerWithoutCorrectnessDTO>()
                            {
                                new AnswerWithoutCorrectnessDTO()
                                {
                                    AnswerId =  24,
                                    QuestionId= 16,
                                    Answer = "Упорядоченно записанные данные"
                                     },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 25,
                                    QuestionId= 16,
                                    Answer = "Камни",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 26,
                                     QuestionId= 16,
                                     Answer = "Мужчины",
                                }
                            }
                        },

                         new QuestionWithListAnswersDTO ()
                        {
                            Id = 17,
                            Question = "Перечислите принципы ООП",
                            TypeID = 3,
                            Weight = 4,
                            Answers = new List<AnswerWithoutCorrectnessDTO>()
                            {
                                new AnswerWithoutCorrectnessDTO()
                                {
                                    AnswerId =  27,
                                    QuestionId= 17,
                                    Answer = null
                                 },

                            }
                        },
                        new QuestionWithListAnswersDTO ()
                        {
                            Id = 18,
                            Question = "Адаптер - это",
                            TypeID = 1,
                            Weight = 1,
                            Answers = new List<AnswerWithoutCorrectnessDTO>()
                            {
                                new AnswerWithoutCorrectnessDTO()
                                {
                                    AnswerId =  28,
                                     QuestionId= 18,
                                    Answer = "Структурный паттерн"
                                     },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 29,
                                    QuestionId= 18,
                                    Answer = "Переходник",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 30,
                                     QuestionId= 18,
                                     Answer = "Мешок",
                                }
                            }
                        },
                        new QuestionWithListAnswersDTO ()
                        {
                            Id = 19,
                            Question = "Порождающие паттерны - это",
                            TypeID = 2,
                            Weight = 4,
                            Answers = new List<AnswerWithoutCorrectnessDTO>()
                            {
                                new AnswerWithoutCorrectnessDTO()
                                {
                                    AnswerId =  51,
                                     QuestionId= 19,
                                    Answer = "SingleTon"
                                     },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 52,
                                    QuestionId= 19,
                                    Answer = "Abstract Factory",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 53,
                                     QuestionId= 19,
                                     Answer = "Iterator",
                                }
                            }
                        },
                        new QuestionWithListAnswersDTO ()
                        {
                            Id = 20,
                            Question = "Максим, кто он?",
                            TypeID = 1,
                            Weight = 5,
                            Answers = new List<AnswerWithoutCorrectnessDTO>()
                            {
                                new AnswerWithoutCorrectnessDTO()
                                {
                                    AnswerId =  31,
                                     QuestionId= 20,
                                    Answer = "Автор тестов"
                                     },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 32,
                                    QuestionId= 20,
                                    Answer = "Любимый препод",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 33,
                                     QuestionId= 20,
                                     Answer = "Помощник Марины",
                                }
                            }
                        },
                        new QuestionWithListAnswersDTO ()
                        {
                            Id = 21,
                            Question = "Какая функция у команды SELECT в SQL?",
                            TypeID = 1,
                            Weight = 1,
                            Answers = new List<AnswerWithoutCorrectnessDTO>()
                            {
                                new AnswerWithoutCorrectnessDTO()
                                {
                                    AnswerId =  34,
                                    QuestionId= 21,
                                    Answer = "Вывести данные"
                                     },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 35,
                                    QuestionId= 21,
                                    Answer = "Добавить данные",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 36,
                                     QuestionId= 21,
                                     Answer = "Удалить данные",
                                }
                            }
                        }
                    }
                        ;




                case 2:
                    List<QuestionWithListAnswersDTO> questions = new List<QuestionWithListAnswersDTO>() { };
                    return questions;


            }
            return null;
        }

        public Dictionary<int, List<QuestionWithListAnswersDTO>> CreateDictionaryMock(List<QuestionWithListAnswersDTO> questions)
        {
            Dictionary<int, List<QuestionWithListAnswersDTO>> dictionary = new Dictionary<int, List<QuestionWithListAnswersDTO>>();
            List<QuestionWithListAnswersDTO> q = new List<QuestionWithListAnswersDTO>();
            q.Add(new QuestionWithListAnswersDTO());
            dictionary[2] = q;
            dictionary[5] = q;
            q.Add(new QuestionWithListAnswersDTO());
            dictionary[4] = q;
            q.Add(new QuestionWithListAnswersDTO());
            dictionary[1] = new List<QuestionWithListAnswersDTO>(q);
            return dictionary;
        }

    }
}   
