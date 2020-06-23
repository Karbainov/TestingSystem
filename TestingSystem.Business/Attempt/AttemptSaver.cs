using System;
using System.Collections.Generic;
using System.Linq;
using TestingSystem.Data.StoredProcedure.CRUD;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.DTO;
using TestingSystem.Data;
using TestingSystem.Business.Models;

namespace TestingSystem.Business.Attempt
{
    public class AttemptSaver
    {
        public bool CreateAttemptResult(ConcreteAttemptBusinessModel concreteAttempt)
        {
            StudentDataAccess student = new StudentDataAccess();
            int answersCount = 0;
            student.DeleteAttemptQuestionAnswerByAttemptId(concreteAttempt.AttemptId);
            foreach (var q in concreteAttempt.Questions)
            {
                foreach (var a in q.Answers)
                {
                    answersCount++;
                    if (a.Id.HasValue)
                    {
                        student.AddAttemptQuestionAnswer(concreteAttempt.AttemptId, q.Id, a.Id.Value);
                    }
                    else
                    {
                        QuestionTypeAnswersDTO questionType = student.GetQuestionTypeIdCorrectAnswerByQuestionId(q.Id);
                        StringAnswerConverter convert = new StringAnswerConverter();
                        if (convert.CheckCorrectAnswer(a.Value, questionType.Value, questionType.TypeId))
                        {
                            student.AddAttemptQuestionAnswer(concreteAttempt.AttemptId, q.Id, questionType.Id);
                        }
                        else
                        {
                            AnswerDTO answer = new AnswerDTO(0, q.Id, a.Value, false);
                            int answerId = student.AddAnswer(answer);
                            student.AddAttemptQuestionAnswer(concreteAttempt.AttemptId, q.Id, answerId);
                        }
                    }
                }
            }
            int answersQty = student.GetQtyOfAnswersInAttempt(concreteAttempt.AttemptId);
            return (answersQty == answersCount);
        }
    }
}