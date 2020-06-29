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
    {     
        [Authorize(Roles = "Author")]
        [HttpGet("processed-feedbacks")]    
        public ActionResult <List<FeedbackOutputModel>> GetProcessedFeedbacks()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Ok(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetProcessedFeedbacks()));
        }

        [Authorize(Roles = "Author")]
        [HttpGet("not-processed-feedbacks")]    
        public ActionResult<List<FeedbackOutputModel>> GetNotProcessedFeedbacks()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Ok(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetNotProcessedFeedbacks()));
        }

        [Authorize(Roles = "Author")]
        [HttpGet]    
        public ActionResult<List<FeedbackOutputModel>> GetAllFeedbacks()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Ok(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetAllFeedbacks()));
        }

        [Authorize(Roles = "Author")]
        [HttpGet("{testId}")]    
        public ActionResult<List<FeedbackOutputModel>> GetFeedbacksByTestId(int testId)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            var test = feedbacks.GetTestById(testId);
            if (test == null) return BadRequest("Теста не существует");
            return Ok(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetFeedbacksByTestId(testId)));
        }

        [Authorize(Roles = "Author")]
        [HttpGet("feedbacks-by-date")]    
        public ActionResult<List<FeedbackOutputModel>> GetFeedbacksByPeriod(DateTimeInputModel period)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return Ok(mapper.ConvertFeedbackDTOToFeedbackModelList(feedbacks.GetFeedbacksByPeriod(period.StringConverToDateTime(period.PeriodStart), period.StringConverToDateTime(period.PeriodEnd))));
        }       

        [Authorize(Roles = "Author")]
        [HttpGet("feedback-with-question/{feedbackId}")]    
        public ActionResult <FeedbackQuestionOutputModel> GetFeedbackByIdWithAllInfo(int feedbackId)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            var feedback = feedbacks.GetFeedbackWithQuestion(feedbackId);
            if (feedback == null) return BadRequest("Фитбека не существует");
            FeedbackQuestionOutputModel model = mapper.ConvertFeedbackQuestionDTOToFeedbackQuestionOutputModel(feedback);            
            model.Answers = mapper.ConvertAnswerDTOToAnswerModelList(feedbacks.GetAllAnswersByFeedbackId(feedbackId));
            return Ok(model);
        }        

        [Authorize(Roles = "Author")]
        [HttpPut("update-processe/{feedbackId}")]
        public ActionResult PutProcessedInFeedback(int feedbackId)     
        {
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            var feedback = feedbacks.GetFeedbackById(feedbackId);
            if (feedback == null) return BadRequest("Фитбека не существует");
            return Ok(feedbacks.UpdateProcessedInFeedback(feedbackId));
        }
    }
}
