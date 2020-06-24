using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet("processed-feedbacks/Author")]    //список обработанных фидбэков
        public ActionResult <List<FeedbackOutputModel>> GetProcessedFeedbacks()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Ok(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetProcessedFeedbacks()));
        }

        [HttpGet("not-processed-feedbacks/Author")]    //список необработанных фидбэков
        public ActionResult<List<FeedbackOutputModel>> GetNotProcessedFeedbacks()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Ok(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetNotProcessedFeedbacks()));
        }

        [HttpGet("Author")]    //список всех фидбэков
        public ActionResult<List<FeedbackOutputModel>> GetAllFeedbacks()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Ok(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetAllFeedbacks()));
        }

        [HttpGet("{testId}/Author")]    //список фидбэков конкретных тестов  
        public ActionResult<List<FeedbackOutputModel>> GetFeedbackByTest(int testId)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            var test = feedbacks.GetByIdTest(testId);
            if (test == null) return BadRequest("Тест не существует");
            return Ok(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetFeedbackByTest(testId)));
        }

        [HttpGet("feedbacks-by-date/Author")]    //список фидбэков конкретных дат
        public ActionResult<List<FeedbackOutputModel>> GetFeedbackByDate(DateTimeInputModel date)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Ok(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetFeedbackByDate(date.StringConverToDateTime(date.DateTime1), date.StringConverToDateTime(date.DateTime2))));
        }



        //Запросы на странице конкретного фидбэка "FeedbackId" (вся информация по фидбэку)

        [HttpGet("feedback-with-question/{feedbackId}/Author")]     //вывод фидбэка (с именем пользователя, названием теста и вопросом)
        public ActionResult <FeedbackQuestionOutputModel> GetFeedbackWithQuestion(int feedbackId)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            var feedback = feedbacks.GetFeedbackById(feedbackId);
            if (feedback == null) return BadRequest("Фитбека не существует");
            return Ok(mapper.ConvertFeedbackQuestionDTOToFeedbackQuestionOutputModel(feedbacks.GetFeedbackWithQuestion(feedbackId)));
        }

        [HttpGet("answers-by-feedback/{feedbackId}/Author")]
        public ActionResult<List<AnswerOutputModel>> GetAllAnswersByFeedbackId(int feedbackId)    //список ответов на вопрос, к которому написан фидбэк
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess answers = new AuthorDataAccess();
            var feedback = answers.GetFeedbackById(feedbackId);
            if (feedback == null) return BadRequest("Фитбека не существует");
            return Ok(mapper.ConvertAnswerDTOToAnswerModelList(answers.GetAllAnswersByFeedbackId(feedbackId)));
        }

        [HttpPut("update-processe/{feedbackId}/Author")]
        public ActionResult PutProcessedInFeedback(int feedbackId)      //отметить, что фидбэк просмотрен (можно вернуть на непросмотренный)
        {
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            var feedback = feedbacks.GetFeedbackById(feedbackId);
            if (feedback == null) return BadRequest("Фитбека не существует");
            return Ok(feedbacks.UpdateProcessedInFeedback(feedbackId));
        }
    }
}
