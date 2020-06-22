using TestingSystem.Business.Models;
using TestingSystem.Data;

namespace TestingSystem.Business.Attempt
{
    public class AttemptSaver
    {
        public void CreateAttemptResult(ConcreteAttemptBusinessModel concreteAttempt)
        {
            //удалить строки из A_Q_A по AttemptId
            StudentDataAccess student = new StudentDataAccess();
            student.DeleteAttemptQuestionAnswerByAttemptId(concreteAttempt.AttemptId);
            foreach (var q in concreteAttempt.Questions)
            {
                
                foreach (var a in q.Answers)
                {
                    if (a.Id.HasValue)
                    {
                        //метод добавления q.Id и a.Id в таблицу
                        student.AddAttemptQuestionAnswer(concreteAttempt.AttemptId, q.Id, a.Id.Value);
                    }
                    else
                    {
                        //метод сравнения строк
                        student.GetQuestionTypeIdCorrectAnswerByQuestionId(q.Id);
                        /*
                        План действий:
                        1) Запрашиваем все строки правильных ответов с ID и типами вопросов
                        2) Сравниваем строки ответа пользователя с правильным ответом
                        3)  Совпали - добавляем по ID правильного ответа
                            Не совпали - создаем неправильный ответ в базе и возвращаем его ID
                        4) Вызываем добавление в Attempt_Question_Answer по трем ID
                         */
                    }
                }
            }
            // Отправка DurationTime в таблицу Attempt
        }
    }
}