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
    {
        //Запросы на основной странице "Feedbacks" (список фидбэков)

        [HttpGet("processed-feedbacks/Author")]    //список обработанных фидбэков
        public IActionResult GetProcessedFeedbacks()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Json(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetProcessedFeedbacks()));
        }

        [HttpGet("not-processed-feedbacks/Author")]    //список необработанных фидбэков
        public IActionResult GetNotProcessedFeedbacks()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Json(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetNotProcessedFeedbacks()));
        }

        [HttpGet("feedbacks/Author")]    //список всех фидбэков
        public IActionResult GetAllFeedbacks()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Json(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetAllFeedbacks()));
        }

        [HttpGet("feedbacks/{testId}/Author")]    //список фидбэков конкретных тестов
        public IActionResult GetFeedbackByTest(int testId)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Json(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetFeedbackByTest(testId)));
        }

        [HttpGet("feedbacks-by-date/Author")]    //список фидбэков конкретных дат
        public IActionResult GetFeedbackByDate(DateTimeInputModel date)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Json(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetFeedbackByDate(date.StringConverToDateTime(date.DateTime1), date.StringConverToDateTime(date.DateTime2))));
        }



        //Запросы на странице конкретного фидбэка "FeedbackId" (вся информация по фидбэку)

        [HttpGet("feedbacks/{id}/Author")]     //вывод фидбэка (с именем пользователя, названием теста и вопросом)
        public IActionResult GetFeedbackWithQuestion(int id)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedback = new AuthorDataAccess();
            return Json(mapper.ConvertFeedbackQuestionDTOToFeedbackQuestionOutputModel(feedback.GetFeedbackWithQuestion(id)));
        }

        [HttpGet("feedbacks/{id}/Author")]
        public IActionResult GetAllAnswersByFeedbackId([FromBody] int id)    //список ответов на вопрос, к которому написан фидбэк
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess answers = new AuthorDataAccess();
            return Json(mapper.ConvertAnswerDTOToAnswerModelList(answers.GetAllAnswersByFeedbackId(id)));
        }

        [HttpPut("feedbacks/{id}/Author")]
        public IActionResult PutProcessedInFeedback([FromBody] int id)      //отметить, что фидбэк просмотрен (можно вернуть на непросмотренный)
        {
            AuthorDataAccess author = new AuthorDataAccess();
            int result = author.UpdateProcessedInFeedback(id);
            if (result == id)
            {
                return new OkObjectResult("Feedback information is updated");
            }
            else
            {
                return new BadRequestObjectResult("DataBase error");
            }
        }
    }
}
