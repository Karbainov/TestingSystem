using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestingSystem.Data;
using TestingSystem.Data.DTO;
using TestingSystem.API.Models.Output;
using TestingSystem.API.Models.Input;
using TestingSystem.Business.Models;
using TestingSystem.Business;
using TestingSystem.Business.Attempt;
using Microsoft.AspNetCore.Authorization;
using TestingSystem.Data.StoredProcedure.CRUD;
using TestingSystem.Business.Statistics;
using TestingSystem.Business.Statistics.Models;

namespace TestingSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [Authorize(Roles = "Author,Teacher")]
        [HttpGet]
        public ActionResult<List<TestOutputModel>> GetAllTests()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tests = new AuthorDataAccess();

            List<TestOutputModel> listOfModels = mapper.ConvertTestDTOToTestModelList(tests.GetAllTests());

            foreach (var i in listOfModels)
            {
                TestStatistics statistics = new TestStatistics(i.ID);
                PassedFailedModel pfs = statistics.GetPassedFailedStats(i.ID);
                i.AverageResult = statistics.GetAverageResults(i.ID);
                i.Passed = pfs.Passed;
                i.Failed = pfs.Failed;
                i.SuccessRate = pfs.SuccessRate;

            }
            return Ok(listOfModels);
        }


        [Authorize(Roles = "Author,Teacher")]
        [HttpGet("had/{testId}")]
        public PassedFailedModel qq (int testId)
        {
           TestStatistics st = new TestStatistics(testId);
           return st.GetPassedFailedStats(testId);
        }


        [Authorize(Roles = "Author,Teacher")]
        [HttpGet("search-test-by-tags")]    
        public ActionResult <List<TestOutputModel>> GetTestsFoundByTag([FromBody] SearchTestByTagInputModel model)
        {            
            bool caseSwitch =model.SwitchValue;
            Mapper mapper = new Mapper();
            AuthorDataAccess search = new AuthorDataAccess();
            FindBy4AndMoreTags searchBy4AndMoreTags = new FindBy4AndMoreTags();
            StringConverter converter = new StringConverter();

            if (caseSwitch)
            {
                if (converter.CreateArrayFromString(model.Tag).Length < 3)
                {
                    return Json(mapper.ConvertTestDTOToTestModelList(search.GetTestsFoundByTagAnd(converter.CreateArrayFromString(model.Tag))));
                }
                else
                {
                    return Json(mapper.ConvertTestQuestionTagDTOToTestOutputListModel(searchBy4AndMoreTags.FindAnd(model.Tag)));
                }
            }
            else
            {
                if (converter.CreateArrayFromString(model.Tag).Length < 3)
                {
                    return Json(mapper.ConvertTestDTOToTestModelList(search.GetTestsFoundByTagOr(converter.CreateArrayFromString(model.Tag))));
                }
                else
                {
                    return Json(mapper.ConvertTestQuestionTagDTOToTestOutputListModel(searchBy4AndMoreTags.FindOr(model.Tag)));
                }
            }
        }        

        [Authorize(Roles = "Author,Teacher")]
        [HttpGet("tags")]      
        public ActionResult <List<TagOutputModel>> GetAllTags()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tags = new AuthorDataAccess();
            return Ok(mapper.ConvertTagDTOToTagModelList(tags.GetAllTags()));
        }

        [Authorize(Roles = "Author")]
        [HttpPost("tag")]     
        public ActionResult <int> PostTag([FromBody]TagInputModel tagModel)           //спросить у Макса
        {
            if(string.IsNullOrWhiteSpace(tagModel.Name)) return BadRequest("Введите название тега");
            Mapper mapper = new Mapper();
            TagDTO tagDto = mapper.ConvertTagInputModelToTagDTO(tagModel);
            AuthorDataAccess tag = new AuthorDataAccess();            
            return Ok(tag.AddTag(tagDto));
        }

        [Authorize(Roles = "Author")]
        [HttpPut("tag")]      
        public ActionResult<int> PutTagById([FromBody]TagInputModel tagModel)
        {
            Mapper mapper = new Mapper();
            TagDTO tagDto = mapper.ConvertTagInputModelToTagDTO(tagModel);
            AuthorDataAccess tags = new AuthorDataAccess();
            var tag = tags.GetTagById(tagModel.ID);
            if (tag == null) return BadRequest("Тега не существует");
            if (string.IsNullOrWhiteSpace(tagModel.Name)) return BadRequest("Введите название тега");
            tags.UpdateTagById(tagDto);            
            return Ok(tagModel.ID);
        }

        [Authorize(Roles = "Author")]
        [HttpDelete("tag/{tagId}")]    
        public ActionResult<int> DeleteTagById(int tagId)
        {
            AuthorDataAccess tags = new AuthorDataAccess();
            var tag = tags.GetTagById(tagId);
            if (tag == null) return BadRequest("Тега не существует");
            tags.DeleteTagById(tagId);
            return Ok(tagId);
        }        

        [Authorize(Roles = "Author")]
        [HttpPost]                             //??? выдает 
        public ActionResult<int> PostTest(TestInputModel testModel)
        {
            if (string.IsNullOrWhiteSpace(testModel.Name)) return BadRequest("Введите название теста");
            if (string.IsNullOrWhiteSpace(testModel.DurationTime)) return BadRequest("Введите время прохождения теста");
            if (testModel.QuestionNumber ==null) return BadRequest("Введите количество вопросов в тесте");
            if (testModel.SuccessScore == null) return BadRequest("Введите минимальный балл для прохождения теста");
            Mapper mapper = new Mapper();
            TestDTO testDto = mapper.ConvertTestInputModelToTestDTO(testModel);
            AuthorDataAccess test = new AuthorDataAccess();
            return Ok(test.AddTest(testDto));                    
        }

        [Authorize(Roles = "Author")]
        [HttpPut]        
        public ActionResult<int> PutTestById([FromBody]TestInputModel testModel)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tests = new AuthorDataAccess();
            if (string.IsNullOrWhiteSpace(testModel.Name)) return BadRequest("Введите название теста");
            if (string.IsNullOrWhiteSpace(testModel.DurationTime)) return BadRequest("Введите время прохождения теста");
            if (testModel.QuestionNumber == null) return BadRequest("Введите количество вопросов в тесте");
            if (testModel.SuccessScore == null) return BadRequest("Введите минимальный балл для прохождения теста");
            TestDTO testDto = mapper.ConvertTestInputModelToTestDTO(testModel);
            return Ok(tests.UpdateTestById(testDto));
        }

        [Authorize(Roles = "Author")]
        [HttpDelete("{testId}")]       
        public ActionResult<int> DeleteTestById(int testId)
        {
            AuthorDataAccess tests = new AuthorDataAccess();
            var test = tests.GetTestById(testId);
            if (test == null) return BadRequest("Теста не существует");
            return Ok(tests.DeleteTestById(testId));
        }

        [Authorize(Roles = "Author,Teacher")]
        [HttpGet("{testId}")]     
        public ActionResult<TestOutputModel> GetTestAllInfoById(int testId) 
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tests = new AuthorDataAccess();
            var test = tests.GetTestById(testId);
            TestStatistics testStatistics = new TestStatistics(testId);
            if (test == null) return BadRequest("Теста не существует");
            TestOutputModel model = mapper.ConvertTestDTOToTestOutputModel(tests.GetTestById(testId));
            PassedFailedModel pfs = testStatistics.GetPassedFailedStats(testId);
            model.Questions = mapper.ConvertQuestionDTOToQuestionModelList(tests.GetQuestionsByTestID(testId));
            model.Tags = mapper.ConvertTagDTOToTagModelList(tests.GetTagsInTest(testId));
            model.AverageResult = testStatistics.GetAverageResults(testId);
            model.Passed = pfs.Passed;
            model.Failed = pfs.Failed;
            model.SuccessRate = pfs.SuccessRate;
            foreach (QuestionOutputModel qModel in model.Questions)
            {
                qModel.Answers = mapper.ConvertAnswerDTOToAnswerModelList(tests.GetAnswerByQuestionId(qModel.ID));
                //QuestionStatistics statistics = new QuestionStatistics(qModel.ID);
                //qModel.PercentageOfCorrectlyAnswered = statistics.GetPercentageOfCorrectlyAnswered(qModel.ID);
                //foreach (var answer in qModel.Answers)
                //{
                //    answer.PercentageOfPeopleChoosingAnswer = statistics.GetPercentageOfPeopleChoosingAnswer(qModel.ID)[answer.ID];
                //}
            }
            return Ok(model);
        }

        //[HttpGet("{testId}/test-info/Author")]          
        //public ActionResult<TestOutputModel> GetTestById(int testId)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess test = new AuthorDataAccess();
        //    return Ok(mapper.ConvertTestDTOToTestOutputModel(test.GetTestById(testId)));
        //}

        //[HttpGet("{testId}/questions/Author")]         
        //public ActionResult<List<QuestionOutputModel>> GetQuestionsByTestID(int testId)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess questions = new AuthorDataAccess();
        //    List<QuestionOutputModel> listOfModels = mapper.ConvertQuestionDTOToQuestionModelList(questions.GetQuestionsByTestID(testId));
        //    foreach(var model in listOfModels)
        //    {
        //        QuestionStatistics statistics = new QuestionStatistics(model.ID);
        //        model.PercentageOfCorrectlyAnswered = statistics.FindPercentCorrectAnswersByQuestion(model.ID);
        //    }
        //    return Ok(listOfModels);
        //}

        //[HttpGet("{testId}/answers/Author")]          
        //public ActionResult<List<AnswerOutputModel>> GetAnswersByTestID(int testId)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess answers = new AuthorDataAccess();
        //    return Ok(mapper.ConvertAnswerDTOToAnswerModelList(answers.GetAllAnswersInTest(testId)));
        //}

        //[HttpGet("{testId}/tags/Author")]         
        //public ActionResult<List<TagOutputModel>> GetTagsInTest(int testId)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess tags = new AuthorDataAccess();
        //    return Ok(mapper.ConvertTagDTOToTagModelList(tags.GetTagsInTest(testId)));
        //}

        [Authorize(Roles = "Author")]
        [HttpGet("{testid}/missing-tags")]          
        public ActionResult<List<TagOutputModel>> GetTagsWhichAreNotInTest(int testId)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tags = new AuthorDataAccess();
            var test = tags.GetTestById(testId);
            if (test == null) return BadRequest("Теста не существует");
            return Ok(mapper.ConvertTagDTOToTagModelList(tags.GetTagsWhichAreNotInTest(testId)));
        }

        [Authorize(Roles = "Author")]
        [HttpDelete("delete-tag-from-test")]     
        public ActionResult<int> DeleteTagFromTest(TestTagInputModel testTagModel)
        {
            AuthorDataAccess tags = new AuthorDataAccess();
            var test = tags.GetTestById(testTagModel.TestID);
            if (test == null) return BadRequest("Теста не существует");
            var tag = tags.GetTagById(testTagModel.TagID);
            if (tag == null) return BadRequest("Тега не существует");
            var testTag = tags.GetTestByTag(testTagModel.TestID, testTagModel.TagID);
            if (testTag == null) return BadRequest("У данного теста нет такого тега");
            tags.DeleteByTestIdTagId(testTagModel.TestID, testTagModel.TagID);
            return Ok("Успешно удалено!");
        }

        [Authorize(Roles = "Author")]
        [HttpPost("post-tag-in-test")]      
        public ActionResult<int> PostTagInTest(TestTagInputModel testTagModel)
        {
            Mapper mapper = new Mapper();
            TestTagDTO testTagDto = mapper.ConvertTestTagInputModelToTestTagDTO(testTagModel);
            AuthorDataAccess tags = new AuthorDataAccess();
            var test = tags.GetTestById(testTagModel.TestID);
            if (test == null) return BadRequest("Теста не существует");
            var tag = tags.GetTagById(testTagModel.TagID);
            if (tag == null) return BadRequest("Тега не существует");
            return Ok(tags.TestTagCreate(testTagDto));
        }
        
        [Authorize(Roles = "Author")]
        [HttpPost("add-question-by-test")]                        //??????? не работает!!!
        public ActionResult<int> PostQuestion(QuestionInputModel questionModel)
        {
            Mapper mapper = new Mapper();
            QuestionDTO questionDto = mapper.ConvertQuestionInputModelToQuestionDTO(questionModel);
            AuthorDataAccess questions = new AuthorDataAccess();
            var test = questions.GetTestById(questionModel.TestID);
            if (test == null) return BadRequest("Теста не существует");
            if (string.IsNullOrWhiteSpace(questionModel.Value)) return BadRequest("Введите вопрос");
            if (questionModel.TypeID == null) return BadRequest("Введите тип вопроса");
            if (questionModel.AnswersCount == null) return BadRequest("Введите количество ответов на вопрос");
            if (questionModel.Weight == null) return BadRequest("Введите вес вопроса");
            return Ok(questions.AddQuestion(questionDto));            
        }

        [Authorize(Roles = "Author")]
        [HttpGet("question/{quid}/Author")]       
        public ActionResult<QuestionOutputModel> GetQuestionById([FromBody] int questionId)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess question = new AuthorDataAccess();
            QuestionOutputModel model = mapper.ConvertQuestionDTOToQuestionOutputModel(question.GetQuestionById(questionId));
            QuestionStatistics statistics = new QuestionStatistics(questionId);
            model.PercentageOfCorrectlyAnswered = statistics.GetPercentageOfCorrectlyAnswered(questionId);
            return Ok(model);
        }

        [Authorize(Roles = "Author")]
        [HttpPut("question-update")]     
        public ActionResult<int> PutQuestionById(QuestionInputModel questionModel)
        {
            Mapper mapper = new Mapper();
            QuestionDTO questionDto = mapper.ConvertQuestionInputModelToQuestionDTO(questionModel);
            AuthorDataAccess questions = new AuthorDataAccess();
            var question = questions.GetQuestionById(questionModel.ID);
            if (question == null) return BadRequest("Вопроса не существует");
            var test = questions.GetTestById(questionModel.TestID);
            if (test == null) return BadRequest("Теста не существует");
            if (string.IsNullOrWhiteSpace(questionModel.Value)) return BadRequest("Введите вопрос");
            if (questionModel.TypeID ==null) return BadRequest("Введите тип вопроса");
            if (questionModel.AnswersCount == null) return BadRequest("Введите количество ответов на вопрос");
            if (questionModel.Weight == null) return BadRequest("Введите вес вопроса");          
            questions.UpdateQuestionById(questionDto);
            return Ok("Изменения сделаны успешно");            
        }

        [Authorize(Roles = "Author")]
        [HttpDelete("question-delete/{quid}")]     
        public ActionResult<int> DeleteQuestionById(int questionId)
        {
            AuthorDataAccess questions = new AuthorDataAccess();
            var question = questions.GetQuestionById(questionId);
            if (question == null) return BadRequest("Вопроса не существует");
            questions.DeleteQuestionById(questionId);
            return Ok(questionId);
        }

        [Authorize(Roles = "Author")]
        [HttpPost("answer")]       
        public ActionResult<int> PostAnswer(AnswerInputModel answerModel)
        {
            Mapper mapper = new Mapper();
            AnswerDTO answerDto = mapper.ConvertAnswerInputModelToAnswerDTO(answerModel);
            AuthorDataAccess answer = new AuthorDataAccess();
            var question = answer.GetQuestionById(answerModel.QuestionID);
            if (question == null) return BadRequest("Вопроса не существует");
            if (string.IsNullOrWhiteSpace(answerModel.Value)) return BadRequest("Введите ответ");
            if (answerModel.Correct==null) return BadRequest("Введите корректный ответ или нет");          
            return Ok(answer.AddAnswer(answerDto));            
        }

        [Authorize(Roles = "Author")]
        [HttpGet("{testid}/question/{quid}/answers/Author")]      
        public ActionResult<List<AnswerOutputModel>> GetAnswersByQuestionId(int questionId)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess answers = new AuthorDataAccess();
            List<AnswerOutputModel> listOfModels = mapper.ConvertAnswerDTOToAnswerModelList(answers.GetAnswerByQuestionId(questionId));
            QuestionStatistics statistics = new QuestionStatistics(questionId);
            foreach(var model in listOfModels)
            {
                model.PercentageOfPeopleChoosingAnswer = statistics.GetPercentageOfPeopleChoosingAnswer(questionId)[model.ID];
            }
            return Ok(listOfModels);
        }

        [Authorize(Roles = "Author")]
        [HttpPut("answer-update")]     
        public ActionResult PutAnswerById(AnswerInputModel answerModel)
        {
            Mapper mapper = new Mapper();
            AnswerDTO answerdto = mapper.ConvertAnswerInputModelToAnswerDTO(answerModel);
            AuthorDataAccess answers = new AuthorDataAccess();
            var answer = answers.GetAnswerById(answerModel.ID);
            if (answer == null) return BadRequest("Ответа не существует");
            var question = answers.GetQuestionById(answerModel.QuestionID);
            if (question == null) return BadRequest("Вопроса не существует");
            if (string.IsNullOrWhiteSpace(answerModel.Value)) return BadRequest("Введите ответ");
            if (answerModel.Correct==null) return BadRequest("Введите корректный ответ или нет");
            answers.UpdateAnswerById(answerdto);
            return Ok("Успешно изменено!");            
        }

        [Authorize(Roles = "Author")]
        [HttpDelete("answer/{anid}")]   
        public ActionResult<int> DeleteAnswerById(int answerId)
        {
            AuthorDataAccess answers = new AuthorDataAccess();
            var answer = answers.GetAnswerById(answerId);
            if (answer == null) return BadRequest("Ответа не существует");
            answers.DeleteAnswerById(answerId);
            return Ok(answerId);
        }




        // [Authorize(Roles = "Teacher,Student")]
        [HttpGet("{testid}/{userId}/Answers")]
        
        public IActionResult GetTestAttempt(int testId, int userId)
        {
            AttemptCreator studentattempt = new AttemptCreator();
            var attempt = studentattempt.CreateAttempt(userId, testId);
            return Json(new Mapper().AttemptBusinessModelToConcreteAttemptOutputModel(attempt, testId, userId));
        }

        [HttpPut("attempt/answers")]
        public IActionResult PutTestAttemptAnswers([FromBody] ConcreteAttemptInputModel concreteAttempt)
        {
            Mapper mapper = new Mapper();
            AttemptSaver saver = new AttemptSaver();
            saver.CreateAttemptResult(mapper.ConvertConcreteAttemptInputModelToConcreteAttemptBusinessModel(concreteAttempt));
            return new OkResult();
        }
        [Authorize(Roles ="Teacher")]
        [HttpGet("{testid}/{userid}/result")]
        public ActionResult GetUserResultByTestIdUserId(int testid,int userid)
        {
            if(new TestCRUD().GetById(testid)==null)
            {
                return BadRequest("Теста с таким id не существует");
            }
            if (new UserCRUD().GetByID(userid)==null)
            {
                return BadRequest("Пользователя с таким id не существует");
            }
            TeacherDataAccess access = new TeacherDataAccess();
            return Ok(new Mapper().ConverUserTestWithQuestionsAndAnswersDTOToBestAttemptModel(access.GetAttemptsByUserIdTestId(userid, testid)));
        }

        [Authorize(Roles = "Student,Teacher")]
        [HttpPost("feedback")]
        public IActionResult PostFeedbackForTest([FromBody] FeedbackInputModel feedback)
        {
            AuthorDataAccess au = new AuthorDataAccess();
            AdminDataAccess ad = new AdminDataAccess();
   
            var q = au.GetQuestionById(feedback.QuestionId);
            var u = ad.GetUserByID(feedback.UserId);

            if (string.IsNullOrWhiteSpace(feedback.Message)) 
                return BadRequest("Введите сообщение");
            
            if (q == null)
                return BadRequest("Вопроса не существует");

            if (u == null)
                return BadRequest("Юзера не существует");

            Mapper mapper = new Mapper();
            StudentDataAccess student = new StudentDataAccess();
            int id = student.CreateFeedback(mapper.ConvertFeedbackInputModelToFeedbackDTO(feedback));
            return Ok(id);
        }
        [Authorize(Roles ="Teacher")]
        [HttpGet("{testid}/lateStudents")]
        public ActionResult GetLateStudentsByTestID(int testid)
        {
            if (new TestCRUD().GetById(testid) == null)
            {
                return BadRequest("Теста с таким id не существует");
            }
            TeacherDataAccess access = new TeacherDataAccess();
            Mapper mapper = new Mapper();
            return Ok(mapper.ConvertTestWithStudentsDTOToTestWithStudentsOutputModel( access.GetLateStudentsByTestID(testid)));
        }        
    }
}