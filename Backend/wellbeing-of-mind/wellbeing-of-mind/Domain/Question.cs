using System.ComponentModel.DataAnnotations;

namespace wellbeing_of_mind.Domain
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string QuestionContent { get; set; } = string.Empty;
        public ICollection<Choice> Choices { get; set; }    
    }
}
