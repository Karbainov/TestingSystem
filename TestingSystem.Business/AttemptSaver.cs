using TestingSystem.Business.Models;
namespace TestingSystem.Business
{
    public class AttemptSaver
    {
        public void AttemptHandler(ConcreteAttemptBusinessModel concreteAttempt)
        {
            foreach (var q in concreteAttempt.Questions)
            {
                
                foreach (var a in q.Answers)
                {
                    if (a.Id.HasValue)
                    {
                        //метод добавления q.Id и a.Id в таблицу
                    }
                    else
                    {
                        //метод сравнения строк
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