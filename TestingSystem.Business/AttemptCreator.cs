using System;
using System.Collections.Generic;
using System.Linq;
using TestingSystem.Data.StoredProcedure.CRUD;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.DTO;
using TestingSystem.Data;
using TestingSystem.Business.Models;

namespace TestingSystem.Business
{
    public class AttemptCreator
    {

        public AttemptBusinessModel CreateAttempt(int userId, int testId)
        {
            StudentDataAccess student = new StudentDataAccess();
            var questions = CreateListOfQuestions(userId, testId);
            var sortedquestions = CreateDictionary(questions);
            var test = student.GetTestById(testId);
            var cuttedquestions = PickQuestionsForAttempt(sortedquestions, test);
            var attemptQuestions = ConvertDictionaryToList(cuttedquestions);
            var attemptId = AddQuestionsToAttemptInDatabase(userId, testId, attemptQuestions);
            AttemptBusinessModel attempt = new AttemptBusinessModel(attemptId, test.Name, test.DurationTime, attemptQuestions);
            return attempt;
        }

        private List<QuestionWithListAnswersDTO> CreateListOfQuestions(int userId, int testId)
        {
            List<QuestionWithListAnswersDTO> questions = new List<QuestionWithListAnswersDTO>();  // как будто вернули список вопросов с типом, а там внутри ответы
            StudentDataAccess student = new StudentDataAccess();
            return questions = student.GetQuestionsAndAnswers(testId);

        }


        private Dictionary<int, List<QuestionWithListAnswersDTO>> CreateDictionary(List<QuestionWithListAnswersDTO> questions)
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


        private Dictionary<int, List<QuestionWithListAnswersDTO>> PickQuestionsForAttempt(Dictionary<int, List<QuestionWithListAnswersDTO>> questions, TestDTO test)
        {
            Dictionary<int, List<QuestionWithListAnswersDTO>> attemptquestions = new Dictionary<int, List<QuestionWithListAnswersDTO>>();

            double totalQtyOfQuestions = (double) CountAllQuestionsInDictionary(questions);
            

            foreach (var question in questions)
            {
                var randomIndexes = GetRandomIndexes(question.Value.Count(), (int)test.QuestionNumber * (int)Math.Ceiling((double)question.Value.Count() / totalQtyOfQuestions));
                attemptquestions.Add(question.Key, CutListbyIndexes(question.Value, randomIndexes));
            }


            int currentQuantityOfQuestions = CountAllQuestionsInDictionary(attemptquestions);

            if (test.QuestionNumber >= attemptquestions.Count())
            {
                while (currentQuantityOfQuestions > test.QuestionNumber)
                {
                    foreach (var question in attemptquestions)
                    {
                        if (question.Value.Count() > 1)
                        {
                            question.Value.RemoveAt(0);
                            currentQuantityOfQuestions--;
                            if (currentQuantityOfQuestions <= test.QuestionNumber)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                while (currentQuantityOfQuestions > test.QuestionNumber)
                {
                    foreach (var question in attemptquestions)
                    {
                        
                            question.Value.RemoveAt(0);
                            currentQuantityOfQuestions--;
                            if (currentQuantityOfQuestions <= test.QuestionNumber)
                            {
                                break;
                            }
                        
                    }
                }
            }
            return attemptquestions;


        }
        private List<QuestionWithListAnswersDTO> ConvertDictionaryToList(Dictionary<int, List<QuestionWithListAnswersDTO>> dictionary)
        {
            List<QuestionWithListAnswersDTO> questions = new List<QuestionWithListAnswersDTO>();
            foreach(var question in dictionary)
            {
                questions.AddRange(question.Value);
            }
            return questions;
        }

        private int AddQuestionsToAttemptInDatabase(int userId, int testId, List<QuestionWithListAnswersDTO> questions)
        {
            StudentDataAccess student = new StudentDataAccess();
            int attemptId = student.AddAttemptForAttemptCreator(userId, testId);

            foreach(var question in questions)
            {
                student.AddQuestionToAttempt(attemptId, question.Id);
                
            }
            return attemptId;
        }

        private int CountAllQuestionsInDictionary (Dictionary<int, List<QuestionWithListAnswersDTO>> questions)
        {
            int quantity = 0;
            foreach (var q in questions)

            {
                quantity += q.Value.Count();
            }
            return quantity;
        }
        private List<int> GetRandomIndexes (int upRange, int quantity)
        {
            List<int> randomIndexes = new List<int>();
            Random random = new Random();
            while(randomIndexes.Count() != quantity)
            {
                int index = random.Next(0, upRange);
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
               
    }
}
