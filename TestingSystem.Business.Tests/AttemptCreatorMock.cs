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
                        new QuestionWithListAnswersDTO () 
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

                case 3:
                
                    return new List<QuestionWithListAnswersDTO>()
                    {
                        new QuestionWithListAnswersDTO ()
                        {
                            Id = 30,
                            Question = "Какой из вариантов поведенческий паттерн?",
                            TypeID = 1,
                            Weight = 5,

                            Answers = new List<AnswerWithoutCorrectnessDTO>()
                            {
                                new AnswerWithoutCorrectnessDTO()
                                {
                                    AnswerId = 57,
                                    QuestionId=30,
                                    Answer = "Стратегия",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 58,
                                    QuestionId= 30,
                                    Answer = "Адаптер",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 59,
                                     QuestionId= 30,
                                     Answer = "Абстракция",
                                }

                            }
                        },
                         new QuestionWithListAnswersDTO ()
                        {
                            Id = 31,
                            Question = "Массивы - это",
                            TypeID = 1,
                            Weight = 2,
                            Answers = new List<AnswerWithoutCorrectnessDTO>()
                            {
                                new AnswerWithoutCorrectnessDTO()
                                {
                                    AnswerId =  60,
                                    QuestionId= 31,
                                    Answer = "Упорядоченно записанные данные"
                                     },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 61,
                                    QuestionId= 31,
                                    Answer = "Событие",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 62,
                                     QuestionId= 31,
                                     Answer = "Атланты",
                                }
                            }
                        },


                        new QuestionWithListAnswersDTO ()
                        {
                            Id = 32,
                            Question = "Адаптер - это",
                            TypeID = 1,
                            Weight = 5,
                            Answers = new List<AnswerWithoutCorrectnessDTO>()
                            {
                                new AnswerWithoutCorrectnessDTO()
                                {
                                    AnswerId =  63,
                                     QuestionId= 32,
                                    Answer = "Структурный паттерн"
                                     },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 64,
                                    QuestionId= 32,
                                    Answer = "Переходник",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 65,
                                     QuestionId= 32,
                                     Answer = "Мешок",
                                }
                            }
                        },
                        new QuestionWithListAnswersDTO ()
                        {
                            Id = 33,
                            Question = "Порождающие паттерны - это",
                            TypeID = 2,
                            Weight = 4,
                            Answers = new List<AnswerWithoutCorrectnessDTO>()
                            {
                                new AnswerWithoutCorrectnessDTO()
                                {
                                    AnswerId =  66,
                                     QuestionId= 33,
                                    Answer = "SingleTon"
                                     },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 67,
                                    QuestionId= 33,
                                    Answer = "Abstract Factory",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 68,
                                     QuestionId=33,
                                     Answer = "Iterator",
                                }
                            }
                        },
                         new QuestionWithListAnswersDTO ()
                        {
                            Id = 37,
                            Question = "Структурные паттерны - это",
                            TypeID = 2,
                            Weight = 4,
                            Answers = new List<AnswerWithoutCorrectnessDTO>()
                            {
                                new AnswerWithoutCorrectnessDTO()
                                {
                                    AnswerId =  76,
                                    QuestionId= 37,
                                    Answer = "Адаптер (Adapter)"
                                     },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 77,
                                    QuestionId= 37,
                                    Answer = "Фасад (Facade)",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 78,
                                     QuestionId= 37,
                                     Answer = "Singleton",
                                }
                            }
                        },


                        new QuestionWithListAnswersDTO ()
                        {
                            Id = 38,
                            Question = "Структурные паттерны - это",
                            TypeID = 1,
                            Weight = 6,
                            Answers = new List<AnswerWithoutCorrectnessDTO>()
                            {
                                new AnswerWithoutCorrectnessDTO()
                                {
                                    AnswerId =  79,
                                    QuestionId= 38,
                                    Answer = "У класса должна быть только одна причина для изменения"
                                     },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 80,
                                    QuestionId= 38,
                                    Answer = "Сущности программы должны быть открыты для расширения, но закрыты для изменения",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 81,
                                     QuestionId= 38,
                                     Answer = "Клиенты не должны вынужденно зависеть от методов, которыми не пользуются",
                                }
                            }
                        },

                        new QuestionWithListAnswersDTO ()
                        {
                            Id = 40,
                            Question = "Какая функция у команды SELECT в SQL?",
                            TypeID = 1,
                            Weight = 3,
                            Answers = new List<AnswerWithoutCorrectnessDTO>()
                            {
                                new AnswerWithoutCorrectnessDTO()
                                {
                                    AnswerId =  85,
                                    QuestionId= 40,
                                    Answer = "Вывести данные"
                                     },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 86,
                                    QuestionId= 40,
                                    Answer = "Добавить данные",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 87,
                                     QuestionId= 40,
                                     Answer = "Удалить данные",
                                } 
                            }
                        },

                         new QuestionWithListAnswersDTO ()
                         {
                            Id = 41,
                            Question = "Что такое string",
                            TypeID = 1,
                            Weight = 2,
                            Answers = new List<AnswerWithoutCorrectnessDTO>()
                            {
                                new AnswerWithoutCorrectnessDTO()
                                {
                                    AnswerId =  88,
                                     QuestionId= 41,
                                    Answer = "SingleTon"
                                     },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 89,
                                    QuestionId= 41,
                                    Answer = "Abstract Factory",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 90,
                                     QuestionId= 41,
                                     Answer = "Iterator",
                                }
                            }
                        },

                       

                        new QuestionWithListAnswersDTO ()
                        {
                            Id = 42,
                            Question = "Какие параметры существуют у Node при двусвязном списке",
                            TypeID = 1,
                            Weight = 4,
                            Answers = new List<AnswerWithoutCorrectnessDTO>()
                            {
                                new AnswerWithoutCorrectnessDTO()
                                {
                                    AnswerId =  91,
                                    QuestionId= 42,
                                    Answer = "Root"
                                     },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 92,
                                    QuestionId= 42,
                                    Answer = "Root, Previous,Next",
                                },
                                new AnswerWithoutCorrectnessDTO()
                                {
                                     AnswerId = 93,
                                     QuestionId= 42,
                                     Answer = "Клиенты не должны вынужденно зависеть от методов, которыми не пользуются",
                                }
                            }
                        }

                    };

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
