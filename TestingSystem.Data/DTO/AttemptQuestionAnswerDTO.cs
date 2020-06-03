namespace TestingSystem.Data.DTO
{
    public class AttemptQuestionAnswerDTO
    {
        public int id { get; set; }
        public int attemptID { get; set; }
        public int questionID { get; set; }
        public int answerID { get; set; }

        public AttemptQuestionAnswerDTO(int _id, int _attemptID, int _questionID, int _answerID)
        {
            id = _id;
            attemptID = _attemptID;
            questionID = _questionID;
            answerID = _answerID;
        }

        public AttemptQuestionAnswerDTO()
        { 
        }
    }
}