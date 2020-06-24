using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.API.Models.Input;
using TestingSystem.API.Models.Output;
using TestingSystem.Data;

namespace TestingSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : Controller

        // проверено! все работает;)
    {
        //Запросы на основной странице "Feedbacks" (список фидбэков)

        [Authorize(Roles = "Author")]
        [HttpGet("processed-feedbacks")]    //список обработанных фидбэков
        public ActionResult <List<FeedbackOutputModel>> GetProcessedFeedbacks()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Ok(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetProcessedFeedbacks()));
        }

        [Authorize(Roles = "Author")]
        [HttpGet("not-processed-feedbacks")]    //список необработанных фидбэков
        public ActionResult<List<FeedbackOutputModel>> GetNotProcessedFeedbacks()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Ok(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetNotProcessedFeedbacks()));
        }

        [Authorize(Roles = "Author")]
        [HttpGet]    //список всех фидбэков
        public ActionResult<List<FeedbackOutputModel>> GetAllFeedbacks()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Ok(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetAllFeedbacks()));
        }

        [Authorize(Roles = "Author")]
        [HttpGet("{testId}")]    //список фидбэков конкретных тестов  
        public ActionResult<List<FeedbackOutputModel>> GetFeedbackByTest(int testId)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            var test = feedbacks.GetByIdTest(testId);
            if (test == null) return BadRequest("Тест не существует");
            return Ok(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetFeedbackByTest(testId)));
        }

        [Authorize(Roles = "Author")]
        [HttpGet("feedbacks-by-date")]    //список фидбэков конкретных дат
        public ActionResult<List<FeedbackOutputModel>> GetFeedbackByDate(DateTimeInputModel date)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Ok(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetFeedbackByDate(date.StringConverToDateTime(date.DateTime1), date.StringConverToDateTime(date.DateTime2))));
        }



        //Запросы на странице конкретного фидбэка "FeedbackId" (вся информация по фидбэку)

        [Authorize(Roles = "Author")]
        [HttpGet("feedback-with-question/{feedbackId}")]     //вывод фидбэка (с именем пользователя, названием теста и вопросом)
        public ActionResult <FeedbackQuestionOutputModel> GetFeedbackWithQuestion(int feedbackId)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            var feedback = feedbacks.GetFeedbackById(feedbackId);
            if (feedback == null) return BadRequest("Фитбека не существует");
            return Ok(mapper.ConvertFeedbackQuestionDTOToFeedbackQuestionOutputModel(feedbacks.GetFeedbackWithQuestion(feedbackId)));
        }

        [Authorize(Roles = "Author")]
        [HttpGet("answers-by-feedback/{feedbackId}")]
        public ActionResult<List<AnswerOutputModel>> GetAllAnswersByFeedbackId(int feedbackId)    //список ответов на вопрос, к которому написан фидбэк
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess answers = new AuthorDataAccess();
            var feedback = answers.GetFeedbackById(feedbackId);
            if (feedback == null) return BadRequest("Фитбека не существует");
            return Ok(mapper.ConvertAnswerDTOToAnswerModelList(answers.GetAllAnswersByFeedbackId(feedbackId)));
        }

        [Authorize(Roles = "Author")]
        [HttpPut("update-processe/{feedbackId}")]
        public ActionResult PutProcessedInFeedback(int feedbackId)      //отметить, что фидбэк просмотрен (можно вернуть на непросмотренный)
        {
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            var feedback = feedbacks.GetFeedbackById(feedbackId);
            if (feedback == null) return BadRequest("Фитбека не существует");
            return Ok(feedbacks.UpdateProcessedInFeedback(feedbackId));
        }
    }
}
