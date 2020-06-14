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
            foreach (TestDTO testDTO in dtoList)
            {
                modelList.Add(TestDTOToTestOutputModel(testDTO));
            }
            return modelList;
        }

        //список тестов, найденных по тэгам
        public TestOutputModel SearchTestByTagDTOToTestOutputModel(SearchTestByTagDTO searchTestByTagDTO)
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

        //список фидбэков
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

        public List<FeedbackOutputModel> FeedbackDTOToFeedbackModelList(List<FeedbackDTO> dtoList)
        {
            List<FeedbackOutputModel> modelList = new List<FeedbackOutputModel>();
            foreach (FeedbackDTO feedbackDTO in dtoList)
            {
                modelList.Add(FeedbackDTOToFeedbackOutputModel(feedbackDTO));
            }
            return modelList;
        }

        //список тэгов
        public TagOutputModel TagDTOToTagOutputModel(TagDTO tagDTO)
        {
            return new TagOutputModel()
            {
                ID = tagDTO.ID,
                Name = tagDTO.Name,
            };
        }

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
        public StudentOutputModel UserDTOTestAttemptDTOToStudentModel(UserDTO user, List<TestAttemptOutputModel> tests)
        {
            StudentOutputModel student = new StudentOutputModel(user.ID, user.FirstName, user.LastName, tests);
            return student;
        }


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

    }

}

