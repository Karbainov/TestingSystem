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


        public Dictionary<int, List<QuestionWithListAnswersDTO>> PickQuestionsForAttempt(Dictionary<int, List<QuestionWithListAnswersDTO>> questions, TestDTO test)
        {
            Dictionary<int, List<QuestionWithListAnswersDTO>> attemptquestions = new Dictionary<int, List<QuestionWithListAnswersDTO>>();

            int totalQtyOfQuestions = 0;

            foreach (var q in questions)

            {
                totalQtyOfQuestions += q.Value.Count();
            }
            

            return attemptquestions;
        }

        private List<int> GetRandomIndexes (int upRange, int quantity)
        {
            List<int> randomIndexes = new List<int>();
            Random random = new Random();
            while(randomIndexes.Count() < quantity)
            {
                int index = random.Next(0, upRange + 1);
                if(!randomIndexes.Contains(index))
                {
                    randomIndexes.Add(index);
                }
            }
            return randomIndexes;

        }

        private List<QuestionWithListAnswersDTO> CutListbyIndexes(List<QuestionWithListAnswersDTO> questions, List<int> indexes)
        {
            List<QuestionWithListAnswersDTO> questionsCuttedVersion = new List<QuestionWithListAnswersDTO>();
            foreach (int i in indexes)
            {
                questionsCuttedVersion.Add(questions[i]);
            }

            return questionsCuttedVersion;
        }

        public List<QuestionWithListAnswersDTO> ConvertDictionaryToLIst(Dictionary<int, List<QuestionWithListAnswersDTO>> questions)
        {
            List<QuestionWithListAnswersDTO> attemptquestions = new List<QuestionWithListAnswersDTO>();
            foreach (int w in questions)

            {

            }

            return attemptquestions;
        }
    }
}
