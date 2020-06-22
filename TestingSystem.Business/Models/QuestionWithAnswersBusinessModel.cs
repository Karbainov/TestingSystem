using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace TestingSystem.Business.Models
{
    public class QuestionWithAnswersBusinessModel
    {
        public int Id { get; set; }
        public List<AttemptAnswerBusinessModel> Answers { get; set; }
        
        public QuestionWithAnswersBusinessModel(int id, List<AttemptAnswerBusinessModel> answers)
        {
            Id = id;
            Answers = answers;
        }
    }
}