using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wellbeing_of_mind.Domain
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string QuestionContent { get; set; } = string.Empty;
        public IEnumerable<Choice> Choices { get; set; } = new List<Choice>();

        public Test Test { get; set; }
        [ForeignKey(nameof(Test))]
        public int TestId { get; set; }
    }
}
