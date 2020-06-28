using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Tests.MocsForStatistics
{
    public class QuestionExpectedMock
    {
        public QuestionExpectedMock () { }

        public Dictionary<int, int> CountNumberOfAnswersInAttemptByQuestionId(int questionId) 
        {
            Dictionary<int, int> mock = new Dictionary<int, int>();
            switch (questionId)
            {
                case 4:
                    mock.Add(1, 1);
                    mock.Add(2, 1);
                    mock.Add(3, 1);
                    mock.Add(33, 1);
                    return mock;
                case 6:
                    mock.Add(7, 1);
                    mock.Add(8, 3);
                    mock.Add(9, 3);
                    mock.Add(26, 3);
                    return mock;
                case 13:
                    mock.Add(22, 1);
                    return mock;
            }
            return mock;     
        }

        public Dictionary<int, double> GetPercentageOfPeopleChoosingAnswer(int questionId) 
        {
            Dictionary<int, double> mock = new Dictionary<int, double>();
            switch (questionId)
            {
                case 4:
                    mock.Add(1, 50);
                    mock.Add(2, 50);
                    mock.Add(3, 50);
                    mock.Add(33, 50);
                    return mock;
                case 6:
                    mock.Add(7, 25);
                    mock.Add(8, 75);
                    mock.Add(9, 75);
                    mock.Add(26, 75);
                    return mock;
                case 13:
                    mock.Add(22, 100);
                    return mock;
            }
            return mock;
        }

        public double GetPercentageOfCorrectlyAnswered(int questionId) 
        {
            switch (questionId)
            {
                case 4:
                    return 0 ;
                case 6:
                    return 0 ;
                case 13:
                    return 100 ;
            }
            return -1;
        }
    }
}
