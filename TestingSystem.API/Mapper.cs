using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingSystem.API.Models.Input;
using TestingSystem.API.Models.Output;
using TestingSystem.Data.DTO;
using TestingSystem.Business;
using TestingSystem.Business.Models;

namespace TestingSystem.API
{
    public class Mapper
    {
        //тест
        public TestOutputModel ConvertTestDTOToTestOutputModel(TestDTO testDTO)
        {
            return new TestOutputModel()
            {
                ID = testDTO.ID,
                Name = testDTO.Name,
                SuccessScore = testDTO.SuccessScore,
                DurationTime = testDTO.DurationTime,
                QuestionNumber = testDTO.QuestionNumber,
            };
        }
        public TestOutputModel ConvertTestQuestionTagDTOToTestOutputModel(TestQuestionTagDTO testDTO)
        {
            List<QuestionOutputModel> questions= ConvertQuestionDTOToQuestionModelList(testDTO.Questions);
            List<TagOutputModel> tags = ConvertTagsWithTestIdToTagOutputModel(testDTO.Tags);
            return new TestOutputModel()
            {
                ID = testDTO.ID,
                Name = testDTO.Name,
                SuccessScore = testDTO.SuccessScore,
                DurationTime = testDTO.DurationTime,
                QuestionNumber = testDTO.QuestionNumber,
                Questions = questions,
                Tags = tags
            };
        }
        public List<TestOutputModel> ConvertTestQuestionTagDTOToTestOutputListModel(List<TestQuestionTagDTO> testDTO)
        {
            List<TestOutputModel> tests = new List<TestOutputModel>();
            foreach(var t in testDTO)
            {
                tests.Add(ConvertTestQuestionTagDTOToTestOutputModel(t));
            }
            return tests;
        }
        public List<TagOutputModel> ConvertTagsWithTestIdToTagOutputModel(List<TagWithTestIDDTO> tag)
        {
            List<TagOutputModel> tagOutputs = new List<TagOutputModel>();
            TagOutputModel model;
            foreach(var t in tag)
            {
                model = new TagOutputModel();
                model.ID = t.IDtest;
                model.Name = t.Name;
                tagOutputs.Add(model);
            }
            return tagOutputs;
        }
        
        //список тестов
        public List<TestOutputModel> ConvertTestDTOToTestModelList(List<TestDTO> dtoList) //формирует список тестов
        {
            List<TestOutputModel> modelList = new List<TestOutputModel>();
            foreach (TestDTO testDTO in dtoList)
            {
                modelList.Add(ConvertTestDTOToTestOutputModel(testDTO));
            }
            return modelList;
        }

        ////тест, найденный по тэгам
        //public TestOutputModel SearchTestByTagDTOToTestOutputModel(SearchTestByTagDTO searchTestByTagDTO)
        //{
        //    return new TestOutputModel()
        //    {
        //        ID = searchTestByTagDTO.Id,
        //        Name = searchTestByTagDTO.Name,
        //    };
        //}

        ////список тестов, найденных по тегам
        //public List<TestOutputModel> SearchTestByTagDTOToTestModelList(List<SearchTestByTagDTO> dtoList)
        //{
        //    List<TestOutputModel> modelList = new List<TestOutputModel>();
        //    foreach (SearchTestByTagDTO searchtestDTO in dtoList)
        //    {
        //        modelList.Add(SearchTestByTagDTOToTestOutputModel(searchtestDTO));
        //    }
        //    return modelList;
        //}

        //фидбэк
        public FeedbackOutputModel ConvertFeedbackDTOToFeedbackOutputModel(FeedbackDTO feedbackDTO)
        {
            return new FeedbackOutputModel()
            {
                ID = feedbackDTO.ID,
                Message = feedbackDTO.Message,
                DateTime = feedbackDTO.DateTime,
                Processed = feedbackDTO.Processed,
            };
        }

        //список фидбэков
        public List<FeedbackOutputModel> ConvertFeedbackDTOToFeedbackModelList(List<FeedbackDTO> dtoList)
        {
            List<FeedbackOutputModel> modelList = new List<FeedbackOutputModel>();
            foreach (FeedbackDTO feedbackDTO in dtoList)
            {
                modelList.Add(ConvertFeedbackDTOToFeedbackOutputModel(feedbackDTO));
            }
            return modelList;
        }

        //тэг
        public TagOutputModel ConvertTagDTOToTagOutputModel(TagDTO tagDTO)
        {
            return new TagOutputModel()
            {
                ID = tagDTO.ID,
                Name = tagDTO.Name,
            };
        }
        
        //список тэгов
        public List<TagOutputModel> ConvertTagDTOToTagModelList(List<TagDTO> dtoList)
        {
            List<TagOutputModel> modelList = new List<TagOutputModel>();
            foreach (TagDTO tagDTO in dtoList)
            {
                modelList.Add(ConvertTagDTOToTagOutputModel(tagDTO));
            }
            return modelList;
        }

        //создать тэг, изменить тэг
        public TagDTO ConvertTagInputModelToTagDTO(TagInputModel tagmodel)
        {
            return new TagDTO()
            {
                ID = tagmodel.ID,
                Name = tagmodel.Name,
            };
        }

        //попытка
        public List<AttemptResultOutputModel> ConvertAttemptDTOToAttemptModel(List<AttemptResultDTO> attempt)
        {
            List<AttemptResultOutputModel> model = new List<AttemptResultOutputModel>();
            foreach (AttemptResultDTO a in attempt)
            {
                AttemptResultOutputModel attempModel = new AttemptResultOutputModel()
                {
                    Datetime = a.Datetime,
                    Duration = a.Duration,
                    Number = a.Number,
                    Result = a.Result,
                    Status = a.Status
                };
                model.Add(attempModel);
            }
            return model;
        }

        //попытка студента по конкретному тесту
        public StudentOutputModel ConvertUserDTOTestAttemptDTOToStudentModel(UserDTO user, List<TestAttemptOutputModel> tests)
        {
            StudentOutputModel student = new StudentOutputModel(user.ID, user.FirstName, user.LastName, tests);
            return student;
        }

        //список вопросов с ответами
        public List<QuestionAnswerOutputModel> ConvertQuestionAnswerDTOToQuestionAnswerModel(List<QuestionAnswerDTO> questionsAnswers)
        {
            List<QuestionAnswerOutputModel> model = new List<QuestionAnswerOutputModel>();
            foreach (QuestionAnswerDTO a in questionsAnswers)
            {
                QuestionAnswerOutputModel questionAnswer = new QuestionAnswerOutputModel()
                {
                    ID = a.ID,
                    QValue = a.QValue,
                    AValue = a.AValue,
                    Correct = a.Correct
                };
                model.Add(questionAnswer);
            }
            return model;
        }

        //список попыток теста
        public List<TestAttemptOutputModel> ConvertTestAttemptDTOToTestAttemptModel(List<TestAttemptDTO> tests)
        {
            List<TestAttemptOutputModel> model = new List<TestAttemptOutputModel>();
            foreach (TestAttemptDTO a in tests)
            {
                TestAttemptOutputModel test = new TestAttemptOutputModel()
                {
                    AttemptCount = a.AttemptCount,
                    ID = a.ID,
                    BestResult = a.BestResult,
                    DurationTime = a.DurationTime,
                    Name = a.Name,
                    SuccessScore = a.SuccessScore
                };
                model.Add(test);
            }
            return model;
        }

        //создать тест, изменить тест
        public TestDTO ConvertTestInputModelToTestDTO(TestInputModel testmodel)
        {
            return new TestDTO()
            {
                ID = testmodel.ID,
                Name = testmodel.Name,
                DurationTime = TimeSpan.Parse(testmodel.DurationTime),
                SuccessScore =  testmodel.SuccessScore,
                QuestionNumber = testmodel.QuestionNumber,
            };
        }

        //вопрос
        public QuestionOutputModel ConvertQuestionDTOToQuestionOutputModel(QuestionDTO questionDTO)
        {
            return new QuestionOutputModel()
            {
                ID = questionDTO.ID,
                TestID = questionDTO.TestID,
                Value = questionDTO.Value,
                Weight = questionDTO.Weight,      
                AnswerCount = questionDTO.AnswersCount
            };
        }

        //список вопросов
        public List<QuestionOutputModel> ConvertQuestionDTOToQuestionModelList(List<QuestionDTO> dtoList) 
        {
            List<QuestionOutputModel> modelList = new List<QuestionOutputModel>();
            foreach (QuestionDTO questionDTO in dtoList)
            {
                modelList.Add(ConvertQuestionDTOToQuestionOutputModel(questionDTO));
            }
            return modelList;
        }

        //ответ
        public AnswerOutputModel ConvertAnswerDTOToAnswerOutputModel(AnswerDTO answerDTO)
        {
            return new AnswerOutputModel()
            {
                ID = answerDTO.ID,
                QuestionID = answerDTO.QuestionID,
                Value = answerDTO.Value,
                Correct = answerDTO.Correct,
            };
        }

        //список ответов 
        public List<AnswerOutputModel> ConvertAnswerDTOToAnswerModelList(List<AnswerDTO> dtoList)
        {
            List<AnswerOutputModel> modelList = new List<AnswerOutputModel>();
            foreach (AnswerDTO answerDTO in dtoList)
            {
                modelList.Add(ConvertAnswerDTOToAnswerOutputModel(answerDTO));
            }
            return modelList;
        }

        //добавляем тэг в тест
        public TestTagDTO ConvertTestTagInputModelToTestTagDTO(TestTagInputModel testtagmodel)
        {
            return new TestTagDTO()
            {                
                TestID = testtagmodel.TestID,
                TagID = testtagmodel.TagID,                
            };
        }
        //mapper для вывод группы 
        public GroupOutputModel ConvertGroupDTOToGroupOutputModel(GroupDTO group)
        {
            return new GroupOutputModel()
            {
                Id = group.Id,
                Name = group.Name,
                StartDate = group.StartDate,
                EndDate = group.EndDate,
             };
        }

        //список group
        public List<GroupOutputModel> ConvertGroupDTOToListGroupOutputModel(List<GroupDTO> list)
        {
            List<GroupOutputModel> listOutputmodels = new List<GroupOutputModel>();
            foreach (GroupDTO group in list)
            {
                listOutputmodels.Add(ConvertGroupDTOToGroupOutputModel(group));
            }
            return listOutputmodels;
        }

        public GroupDTO ConvertGroupInputModelToGroupDTO(GroupInputModel group)
        {
            return new GroupDTO()
            {
                Id = group.Id,
                Name = group.Name,
                StartDate = group.StartDate,
                EndDate = group.EndDate,
            };
        }

        //создать вопрос
        public QuestionDTO ConvertQuestionInputModelToQuestionDTO(QuestionInputModel questionmodel)
        {
            return new QuestionDTO()
            {
                TestID = questionmodel.TestID,
                Value = questionmodel.Value,
                TypeID = questionmodel.TypeID,
                AnswersCount = questionmodel.AnswersCount,
                Weight = questionmodel.Weight,
            };
        }

        //создать ответ
        public AnswerDTO ConvertAnswerInputModelToAnswerDTO(AnswerInputModel answermodel)
        {
            return new AnswerDTO()
            {
                ID=answermodel.ID,
                QuestionID = answermodel.QuestionID,
                Value = answermodel.Value,
                Correct = answermodel.Correct,                
            };
        }

        //полный фидбэк с вопросом, тестом и именем пользователя
        public FeedbackQuestionOutputModel ConvertFeedbackQuestionDTOToFeedbackQuestionOutputModel(FeedbackQuestionDTO feedbackquestionDTO)
        {
            return new FeedbackQuestionOutputModel()
            {
                ID = feedbackquestionDTO.ID,
                Message = feedbackquestionDTO.Message,
                DateTime = feedbackquestionDTO.DateTime,
                FirstName = feedbackquestionDTO.FirstName,
                LastName = feedbackquestionDTO.LastName,
                TestName = feedbackquestionDTO.TestName,
                Question = feedbackquestionDTO.Question,
                Processed = feedbackquestionDTO.Processed,
            };
        }

        public AnswerWithoutCorrectnessOutputModel AnswerWithoutCorrectnessDTOToAnswerWithoutCorrectnessOutputModel(AnswerWithoutCorrectnessDTO answers)
        {
            AnswerWithoutCorrectnessOutputModel newanswers = new AnswerWithoutCorrectnessOutputModel()
            {
                ID = answers.ID,
                QuestionId = answers.QuestionId,
                Value = answers.Value,

            };

            return newanswers;
        }

        public QuestionWithListAnswersOutputModel QuestionWithListAnswersDTOToQuestionWithListAnswersOutputModel(QuestionWithListAnswersDTO question)
        {
            QuestionWithListAnswersOutputModel newquestion = new QuestionWithListAnswersOutputModel();
            {
                newquestion.Id = question.Id;
                newquestion.Value = question.Value;
                newquestion.TypeID = question.TypeID;
                newquestion.Weight = question.Weight;

                foreach (var answer in question.Answers)

                {
                    newquestion.Answers.Add(new Mapper().AnswerWithoutCorrectnessDTOToAnswerWithoutCorrectnessOutputModel(answer));
            
                }
                         
                return newquestion;
            }
        }

        public List<QuestionWithListAnswersOutputModel> QuestionWithListAnswersDTOsToQuestionWithListAnswersOutputModels(List <QuestionWithListAnswersDTO> questions)
        {
            List<QuestionWithListAnswersOutputModel> newquestions = new List<QuestionWithListAnswersOutputModel>();

            foreach (var question in questions)

            {
                newquestions.Add(new Mapper().QuestionWithListAnswersDTOToQuestionWithListAnswersOutputModel(question));

            }
            return newquestions;

        }

        public ConcreateAttemptOutputModel AttemptBusinessModelToConcreateAttemptOutputModel (AttemptBusinessModel questions, int userId, int testId)
        {
            ConcreateAttemptOutputModel concreatemodel = new ConcreateAttemptOutputModel();

            concreatemodel.UserId = userId;
            concreatemodel.TestId = testId;
            concreatemodel.AttemptId = questions.AttemptId;
            concreatemodel.DurationTime = questions.DurationTime;
            concreatemodel.TestName = questions.TestName;
            concreatemodel.Questions = new Mapper().QuestionWithListAnswersDTOsToQuestionWithListAnswersOutputModels(questions.Questions);
            return concreatemodel;
        }
     }
}

