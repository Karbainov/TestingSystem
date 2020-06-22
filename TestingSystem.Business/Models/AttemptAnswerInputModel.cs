namespace TestingSystem.Business.Models
{
    public class AttemptAnswerBusinessModel
    {
        public int? Id { get; set; }
        public string Value { get; set; }
        
        public AttemptAnswerBusinessModel(int? id, string value)
        {
            Id = id;
            Value = value;
        }
    }
}