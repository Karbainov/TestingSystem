using System;
using System.Collections.Generic;
using System.Linq;
using TestingSystem.Data.StoredProcedure.CRUD;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.DTO;
using TestingSystem.Data;


namespace TestingSystem.Business
{
    public class AttemptCreator
    {

        public List<QuestionWithListAnswersDTO> CreateListOfQuestions(int userId, int testId)
        {
            List<QuestionWithListAnswersDTO> questions = new List<QuestionWithListAnswersDTO>();  // как будто вернули список вопросов с типом, а там внутри ответы
            StudentDataAccess student = new StudentDataAccess();
            return questions = student.GetQuestionsAndAnswers(testId);

        }


        public Dictionary<int, List<QuestionWithListAnswersDTO>> CreateDictionary(List<QuestionWithListAnswersDTO> questions)
        {

            Dictionary<int, List<QuestionWithListAnswersDTO>> weightTypes = new Dictionary<int, List<QuestionWithListAnswersDTO>>();
            foreach (QuestionWithListAnswersDTO q in questions)
            {
                if (!weightTypes.ContainsKey(q.Weight))
                {
                    weightTypes.Add(q.Weight, new List<QuestionWithListAnswersDTO>() { q });

                }
                else
                {
                     weightTypes[q.Weight].Add(q);  // спросить у Максима
                }
            }

            return weightTypes;
        }

        





    }
}
