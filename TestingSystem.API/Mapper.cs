using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingSystem.API.Models.Input;
using TestingSystem.API.Models.Output;
using TestingSystem.Data.DTO;

namespace TestingSystem.API
{
    public class Mapper
    {
        //тест
        public TestOutputModel TestDTOToTestOutputModel(TestDTO testDTO)
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
        
        //список тестов
        public List<TestOutputModel> TestDTOToTestModelList(List<TestDTO> dtoList) //формирует список тестов
        {
            List<TestOutputModel> modelList = new List<TestOutputModel>();
            foreach (TestDTO testDTO in dtoList)
            {
                modelList.Add(TestDTOToTestOutputModel(testDTO));
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
        public FeedbackOutputModel FeedbackDTOToFeedbackOutputModel(FeedbackDTO feedbackDTO)
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
        public List<FeedbackOutputModel> FeedbackDTOToFeedbackModelList(List<FeedbackDTO> dtoList)
        {
            List<FeedbackOutputModel> modelList = new List<FeedbackOutputModel>();
            foreach (FeedbackDTO feedbackDTO in dtoList)
            {
                modelList.Add(FeedbackDTOToFeedbackOutputModel(feedbackDTO));
            }
            return modelList;
        }

        //тэг
        public TagOutputModel TagDTOToTagOutputModel(TagDTO tagDTO)
        {
            return new TagOutputModel()
            {
                ID = tagDTO.ID,
                Name = tagDTO.Name,
            };
        }
        
        //список тэгов
        public List<TagOutputModel> TagDTOToTagModelList(List<TagDTO> dtoList)
        {
            List<TagOutputModel> modelList = new List<TagOutputModel>();
            foreach (TagDTO tagDTO in dtoList)
            {
                modelList.Add(TagDTOToTagOutputModel(tagDTO));
            }
            return modelList;
        }

        //создать тэг, изменить тэг
        public TagDTO TagInputModelToTagDTO(TagInputModel tagmodel)
        {
            return new TagDTO()
            {
                ID = tagmodel.ID,
                Name = tagmodel.Name,
            };
        }

        //попытка
        public List<AttemptResultOutputModel> attemptDTOToAttemptModel(List<AttemptResultDTO> attempt)
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
        public StudentOutputModel UserDTOTestAttemptDTOToStudentModel(UserDTO user, List<TestAttemptOutputModel> tests)
        {
            StudentOutputModel student = new StudentOutputModel(user.ID, user.FirstName, user.LastName, tests);
            return student;
        }

        //список вопросов с ответами
        public List<QuestionAnswerOutputModel> QuestionAnswerDTOToQuestionAnswerModel(List<QuestionAnswerDTO> questionsAnswers)
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
        public List<TestAttemptOutputModel> TestAttemptDTOToTestAttemptModel(List<TestAttemptDTO> tests)
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
        public TestDTO TestInputModelToTestDTO(TestInputModel testmodel)
        {
            return new TestDTO()
            {
                ID = testmodel.ID,
                Name = testmodel.Name,
                DurationTime = testmodel.DurationTime,
                SuccessScore = testmodel.SuccessScore,
                QuestionNumber = testmodel.QuestionNumber,
            };
        }

        //вопрос
        public QuestionOutputModel QuestionDTOToQuestionOutputModel(QuestionDTO questionDTO)
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
        public List<QuestionOutputModel> QuestionDTOToQuestionModelList(List<QuestionDTO> dtoList) 
        {
            List<QuestionOutputModel> modelList = new List<QuestionOutputModel>();
            foreach (QuestionDTO questionDTO in dtoList)
            {
                modelList.Add(QuestionDTOToQuestionOutputModel(questionDTO));
            }
            return modelList;
        }

        //ответ
        public AnswerOutputModel AnswerDTOToAnswerOutputModel(AnswerDTO answerDTO)
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
        public List<AnswerOutputModel> AnswerDTOToAnswerModelList(List<AnswerDTO> dtoList)
        {
            List<AnswerOutputModel> modelList = new List<AnswerOutputModel>();
            foreach (AnswerDTO answerDTO in dtoList)
            {
                modelList.Add(AnswerDTOToAnswerOutputModel(answerDTO));
            }
            return modelList;
        }

        //добавляем тэг в тест
        public TestTagDTO TestTagInputModelToTestTagDTO(TestTagInputModel testtagmodel)
        {
            return new TestTagDTO()
            {
                ID = testtagmodel.ID,
                TestID = testtagmodel.TestID,
                TagID = testtagmodel.TagID,                
            };
        }
        //mapper для вывод группы 
        public GroupOutputModel GroupDTOToGroupOutputModel(GroupDTO group)
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
        public List<GroupOutputModel> GroupDTOToListGroupOutputModel(List<GroupDTO> list)
        {
            List<GroupOutputModel> listOutputmodels = new List<GroupOutputModel>();
            foreach (GroupDTO group in list)
            {
                listOutputmodels.Add(GroupDTOToGroupOutputModel(group));
            }
            return listOutputmodels;
        }

        public GroupDTO GroupInputModelToGroupDTO(GroupInputModel group)
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
        public QuestionDTO QuestionInputModelToQuestionDTO(QuestionInputModel questionmodel)
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
        public AnswerDTO AnswerInputModelToAnswerDTO(AnswerInputModel answermodel)
        {
            return new AnswerDTO()
            {
                QuestionID = answermodel.QuestionID,
                Value = answermodel.Value,
                Correct = answermodel.Correct,                
            };
        }

        //полный фидбэк с вопросом, тестом и именем пользователя
        public FeedbackQuestionOutputModel FeedbackQuestionDTOToFeedbackQuestionOutputModel(FeedbackQuestionDTO feedbackquestionDTO)
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
    }

}

