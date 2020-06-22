using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace TestingSystem.API.Models.Input
{
    public class QuestionWithAnswersInputModel
    {
        public int Id { get; set; }

        public List<AttemptAnswerInputModel> Answers { get; set; }
    }
}